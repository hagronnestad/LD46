using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Players {
    public class Player : MonoBehaviour {
        [SerializeField] LayerMask groundLayerMask;
        Controls controls;

        Vector2 movementVector;

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
            // instantiate controls on startup
            controls = new Controls();
            playerRigidbody = transform.GetComponent<Rigidbody2D>();
            playerCollider = transform.GetComponent<BoxCollider2D>();

            // when movement is performed, push context (direction, weight) to move
            controls.PlayerControls.Move.performed += ctx => MovePerformed(ctx);
            controls.PlayerControls.Move.canceled += ctx => MovePerformed(ctx);
            controls.PlayerControls.Jump.performed += ctx => JumpPerformed();

            // default the player to idle
            state = State.Idle;
        }

        void Update() {
            UpdatePlayerState();

            // Handles movement when idle or when already moving
            if (state == State.Idle || state == State.Moving) {
                if (Mathf.Abs(playerRigidbody.velocity.x) < maxMoveVelocity) {
                    var m = new Vector2(movementVector.x, 0);
                    playerRigidbody.AddForce(m * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
                }
            }

            // Handles movement during a jump, when falling and when already moving in air
            if (state == State.Jumping || state == State.Falling || state == State.MovingInAir) {
                if (Mathf.Abs(playerRigidbody.velocity.x) < maxMoveVelocity) {
                    var m = new Vector2(movementVector.x, 0);
                    playerRigidbody.AddForce(m * moveSpeedInAir * Time.deltaTime, ForceMode2D.Impulse);
                }
            }
        }

        void UpdatePlayerState() {

            if (Mathf.Abs(playerRigidbody.velocity.x) > 0.1f && Mathf.Abs(playerRigidbody.velocity.y) > 0.1f) state = State.MovingInAir;
            else if (Mathf.Abs(playerRigidbody.velocity.x) > 0.5f && Mathf.Abs(playerRigidbody.velocity.y) < 0.1f) state = State.Moving;
            else if (playerRigidbody.velocity.y > 0.5f) state = State.Jumping;
            else if (playerRigidbody.velocity.y < -0.5f) state = State.Falling;
            else state = State.Idle;

        }

        void MovePerformed(InputAction.CallbackContext ctx) {
            movementVector = ctx.ReadValue<Vector2>();
        }

        void JumpPerformed() {
            if (state != State.Jumping && state != State.Falling && state != State.MovingInAir) {
                playerRigidbody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }

        bool Grounded() {
            RaycastHit2D rayHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
            Debug.Log(rayHit.collider);
            return rayHit.collider != null;
        }

        private void OnEnable() {
            controls.PlayerControls.Enable();
        }

        private void OnDisable() {
            controls.PlayerControls.Disable();
        }
    }
}