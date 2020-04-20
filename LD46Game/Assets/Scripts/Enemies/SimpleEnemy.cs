using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies {

    public class SimpleEnemy : EnemyBase {
        [SerializeField] Transform rayCastPoint;

        Vector2 movement;
        public float speed = 1f;
        public float sightRange;
        public Transform player;
        bool agro;
        bool facingRight;
        Rigidbody2D enemyRigidBody;

        void Start() {
            enemyRigidBody = this.GetComponent<Rigidbody2D>();
            player = FindObjectOfType<Players.Player>().transform;
        }

        void Update() {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
            FlipSprite(-movement.x);
        }

        void FixedUpdate() {
            if (agro) {
                Move(movement);
            }
        }

        void Move(Vector2 direction) {
            enemyRigidBody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }

        void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "Player") {
                agro = true;
            }
        }
        void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "Basic Attack") {
                Damage(0.5f);
                GameManager.Instance.GainWizardEnergy(0.1f);
                
                if (Health <= 0) {
                    Destroy(this.gameObject);
                }
            }
        }
        void FlipSprite(float moveVec) {
            if (moveVec > 0 && !facingRight || moveVec < 0 && facingRight) {
                facingRight = !facingRight;
                Vector2 spriteScale = transform.localScale;
                spriteScale.x *= -1;
                transform.localScale = spriteScale;
            }
        }
        // line of sight code, might come in handy later
        //bool HasSight(float distance) {
        //    bool sightValue = false;
        //    float rayDistance = distance;
        //    Vector2 rayEndPoint = rayCastPoint.position + Vector3.right * distance;
        //    RaycastHit2D hit = Physics2D.Linecast(rayCastPoint.position, rayEndPoint, 1 << LayerMask.NameToLayer("Action"));
        //    Debug.DrawLine(rayCastPoint.position, hit.point, Color.red);
        //    if(hit.collider != null) {
        //        if(hit.collider.gameObject.CompareTag("Player")) {
        //            sightValue = true;
        //        } else {
        //            sightValue = false;
        //        }
        //    }
        //    return sightValue;
        //}
    }
}
