using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask groundLayerMask;
    Controls controls;
    Vector2 move;
    Rigidbody2D playerRigidbody;
    BoxCollider2D playerCollider;
    public State state;
    public float moveSpeed;
    public float jumpVelocity;

    public enum State
    {
        Idle,
        Moving,
        Jumping,
        Falling
    }
    void Awake()
    {
        // instantiate controls on startup
        controls = new Controls();
        playerRigidbody = transform.GetComponent<Rigidbody2D>();
        playerCollider = transform.GetComponent<BoxCollider2D>();
        // when movement is performed, push context (direction, weight) to move
        controls.PlayerControls.Move.performed += ctx => Move(ctx);
        // reset when not moving
        controls.PlayerControls.Move.canceled += ctx => Move(ctx);
        controls.PlayerControls.Jump.performed += ctx => Jump();
        controls.PlayerControls.Jump.canceled += ctx => Jump();
        // default the player to idle
        state = State.Idle;
    }
    void Update()
    {
        if (state == State.Moving)
        {
            // store movements in new var - frame independent due to deltatime multiplication
            Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
            transform.Translate(m * moveSpeed, Space.World);

        }
        if (state == State.Jumping && Grounded())
        {
            playerRigidbody.velocity = Vector2.up * jumpVelocity;
        }
        if(Grounded() && state != State.Moving)
        {
            state = State.Idle;
        }
    }
    void Move(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
        if (Mathf.Abs(move.x) > 0.25f)
        {
            state = State.Moving;
        }
        else
        {
            move = Vector2.zero;
            state = State.Idle;
        }
    }
    void Jump()
    {
        if (Grounded())
        {
            state = State.Jumping;
        }
        else
        {
            state = State.Falling;
        }
    }
    bool Grounded()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        Debug.Log(rayHit.collider);
        return rayHit.collider != null;
    }
    private void OnEnable()
    {
        controls.PlayerControls.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerControls.Disable();
    }
}
