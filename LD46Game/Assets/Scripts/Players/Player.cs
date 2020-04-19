using Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.Extensions;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using Assets.Scripts.Managers;
using Unity.Mathematics;
using Assets.Scripts.Systems;

namespace Assets.Scripts.Players {
    public class Player : MonoBehaviour {
        Controls controls;

        Vector2 movementVector;
        Vector2 attackVector;
        bool facingRight;
        public Animator animator;

        Rigidbody2D playerRigidbody;
        BoxCollider2D playerCollider;
        public Transform attackPoint;
        public GameObject attackPrefab;

        public float attackForce;
        float attackTimer = .25f;

        public GameObject chargedAttackParticleSystem;

        public float moveSpeed;

        public Camera cam;

        void Awake() {
            facingRight = true;
            controls = new Controls();
            controls.PlayerActions.Move.performed += ctx => movementVector = ctx.ReadValue<Vector2>();
            controls.PlayerActions.BasicAttack.performed += ctx => attackVector = ctx.ReadValue<Vector2>();
            controls.PlayerActions.ChargedAttack.performed += ctx => UseChargeAttack();
            playerRigidbody = transform.GetComponent<Rigidbody2D>();
            playerCollider = transform.GetComponent<BoxCollider2D>();
        }

        void Update() {
           
            animator.SetFloat("Horizontal", movementVector.x);
            animator.SetFloat("Vertical", movementVector.y);
            animator.SetFloat("Speed", movementVector.sqrMagnitude);
            Debug.Log(movementVector);
        }

        void FixedUpdate() {
            playerRigidbody.MovePosition(playerRigidbody.position + movementVector * moveSpeed * Time.fixedDeltaTime);

            if (Mathf.Abs(movementVector.x) > 0.1 || Mathf.Abs(movementVector.y) > 0.1) {
                GameManager.Instance.UseWizardEnergy(0.001f);
            }

            float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;

            FlipPlayer(movementVector.x,attackVector.x);
            if (attackTimer < 0 || attackTimer > .5f) {
                attackTimer = 0;
            } else {
                attackTimer -= Time.deltaTime;
            }
            if (attackVector.magnitude > 0.1f && attackTimer == 0f) {
                UseBasicAttack();
                attackTimer = .25f;
            }
        }

        void OnCollisionEnter2D(Collision2D collision) {
            if(collision.gameObject.tag == "Enemy") {
                GameManager.Instance.UseWizardEnergy(0.05f);
            }
        }

        public void UseBasicAttack() {
            GameObject attackObject =  Instantiate(attackPrefab, attackPoint.position, Quaternion.identity);
            Rigidbody2D attackObjectRB = attackObject.GetComponent<Rigidbody2D>();
            attackObjectRB.AddForce(transform.localRotation.eulerAngles * attackForce, ForceMode2D.Impulse);

            GameManager.Instance.UseWizardEnergy(0.05f);
        }
        void UseChargeAttack() {

            if (GameManager.Instance.WizardHealthBar.Health < 1.0f) {
                // TODO: Add a sound indicating you don't have enough energy
                return;
            }

            var radius = 1.5f;

            var enemies = new List<EnemyBase>();

            var enemyColliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (var collider in enemyColliders) {
                var enemy = collider.gameObject.GetComponent<EnemyBase>();
                if (enemy != null) {

                    var heading = (enemy.transform.position - transform.position).normalized;
                    var hits = Physics2D.RaycastAll(transform.position, heading, radius);

                    foreach (var hit in hits) {
                        Debug.DrawLine(transform.position, hit.point, Color.red, 3);

                        var confirmedEnemy = hit.collider.gameObject.GetComponent<EnemyBase>();
                        if (confirmedEnemy != null) {
                            enemies.Add(enemy);
                        }

                        var tilemapCollider = hit.collider.gameObject.GetComponent<TilemapCollider2D>();
                        if (tilemapCollider != null) {
                            break;
                        }
                    }
                }
            }
            Debug.Log($"enemies.Length: {enemies.Count}");

            enemies.ForEach(x => x.Damage(1.0f));

            var caps = Instantiate(chargedAttackParticleSystem, transform).GetComponent<ChargedAttackParticleSystem>();
            caps.Play();

            //// Debug circle to show radius
            //var go2 = new GameObject { name = "Circle2" };
            //go2.transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
            //go2.transform.Rotate(90f, 0, 0);
            //go2.DrawCircle(radius, 0.1f);


            GameManager.Instance.UseWizardEnergy(0.1f);

            Camera.main.GetComponent<CameraShake>().DoShake();
        }
        void FlipPlayer(float moveVec, float attVec) {
            if(moveVec > 0 && !facingRight || moveVec < 0 && facingRight || attVec > 0 && !facingRight || attVec < 0 && facingRight) {
                facingRight = !facingRight;
                Vector3 playerScale = transform.localScale;
                playerScale.x *= -1;
                transform.localScale = playerScale;
            }
        }

        void OnEnable() {
            controls.Enable();
        }
        void OnDisable() {
            controls.Disable();
        }
    }
}