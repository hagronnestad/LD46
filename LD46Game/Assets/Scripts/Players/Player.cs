using Assets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Players {
    public class Player : EnemyBase {

        Vector2 movementVector;

        public Animator animator;

        Rigidbody2D playerRigidbody;
        BoxCollider2D playerCollider;

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

            SetHealth(1f);
        }

        void Update() {

            movementVector.x = Input.GetAxisRaw("Horizontal");
            movementVector.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movementVector.x);
            animator.SetFloat("Vertical", movementVector.y);
            animator.SetFloat("Speed", movementVector.sqrMagnitude);
        }

        void FixedUpdate() {
            playerRigidbody.MovePosition(playerRigidbody.position + movementVector * moveSpeed * Time.fixedDeltaTime);
        }

        void OnTriggerEnter2D(Collider2D collision) {
            if(collision.gameObject.tag == "Enemy") {
                Damage(0.2f);
            }
        }
    }
}