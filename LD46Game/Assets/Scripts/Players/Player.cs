using Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.Extensions;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using Assets.Scripts.Managers;
using Unity.Mathematics;

namespace Assets.Scripts.Players {
    public class Player : MonoBehaviour {

        Vector2 movementVector;
        Vector2 mousePos;

        public Animator animator;

        Rigidbody2D playerRigidbody;
        BoxCollider2D playerCollider;
        public Transform attackPoint;
        public GameObject attackPrefab;

        public float attackForce;

        public ParticleSystem chargedAttackParticleSystem;

        public float moveSpeed;

        public Camera cam;

        void Awake() {
           
            playerRigidbody = transform.GetComponent<Rigidbody2D>();
            playerCollider = transform.GetComponent<BoxCollider2D>();
        }

        void Update() {

            movementVector.x = Input.GetAxisRaw("Horizontal");
            movementVector.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            animator.SetFloat("Horizontal", movementVector.x);
            animator.SetFloat("Vertical", movementVector.y);
            animator.SetFloat("Speed", movementVector.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1) || Input.GetKeyDown("joystick 1 button 1")) {
                UseChargeAttack();
            }
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick 1 button 0")) {
                UseBasicAttack();
            }
        }

        void FixedUpdate() {
            playerRigidbody.MovePosition(playerRigidbody.position + movementVector * moveSpeed * Time.fixedDeltaTime);

            if (Mathf.Abs(movementVector.x) > 0.1 || Mathf.Abs(movementVector.y) > 0.1) {
                GameManager.Instance.UseWizardEnergy(0.001f);
            }

            Vector2 lookDirection = mousePos - playerRigidbody.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            playerRigidbody.rotation = angle;

            Vector3 playerLocalScale = Vector3.one;
            if(angle > 90 || angle < -90) {
                playerLocalScale.y = -1f;
            } else {
                playerLocalScale.y = +1f;
            }
            transform.localScale = playerLocalScale;
            Debug.Log(angle);
        }

        void OnCollisionEnter2D(Collision2D collision) {
            if(collision.gameObject.tag == "Enemy") {
                GameManager.Instance.UseWizardEnergy(0.05f);
            }
        }

        void UseBasicAttack() {
            GameObject attackObject =  Instantiate(attackPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D attackObjectRB = attackObject.GetComponent<Rigidbody2D>();
            attackObjectRB.AddForce(attackPoint.right * attackForce, ForceMode2D.Impulse);

            GameManager.Instance.UseWizardEnergy(0.05f);
        }
        void UseChargeAttack() {
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

            chargedAttackParticleSystem.Play();

            //// Debug circle to show radius
            //var go2 = new GameObject { name = "Circle2" };
            //go2.transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
            //go2.transform.Rotate(90f, 0, 0);
            //go2.DrawCircle(radius, 0.1f);


            GameManager.Instance.UseWizardEnergy(0.1f);
        }
    }
}