using Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.Extensions;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Players {
    public class Player : MonoBehaviour {

        Vector2 movementVector;

        public Animator animator;

        Rigidbody2D playerRigidbody;
        BoxCollider2D playerCollider;

        public ParticleSystem chargedAttackParticleSystem;

        public State state;

        public float moveSpeed;
        public float moveSpeedInAir;
        public float maxMoveVelocity;
        public float jumpVelocity;

        public enum State {
            Idle,
            Moving,
            MovingInAir,
            Jumping,
            Falling
        }

        void Awake() {
           
            playerRigidbody = transform.GetComponent<Rigidbody2D>();
            playerCollider = transform.GetComponent<BoxCollider2D>();
      
            // default the player to idle
            state = State.Idle;
        }

        void Update() {

            movementVector.x = Input.GetAxisRaw("Horizontal");
            movementVector.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movementVector.x);
            animator.SetFloat("Vertical", movementVector.y);
            animator.SetFloat("Speed", movementVector.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.Space)) {
                UseChargeAttack();
            }
        }

        void FixedUpdate() {
            playerRigidbody.MovePosition(playerRigidbody.position + movementVector * moveSpeed * Time.fixedDeltaTime);
        }

        void OnTriggerEnter2D(Collider2D collision) {
            //if(collision.gameObject.tag == "Enemy") {
            //    Damage(0.2f);
            //}
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
        }
    }
}