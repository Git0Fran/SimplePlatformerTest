using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Script : MonoBehaviour
{
    [SerializeField] private bool isPlayer2 = false;




    [SerializeField]
    private Animator animator = null;
    [SerializeField] private GroundCheck groundCheck = null;

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpSpeed = 10.0f;
    [SerializeField] private Rigidbody2D rigidbody = null;
    private float desiredSpeed = 0.0f;
    private float direction = 1.0f;
    private Vector3 lastSafePosition = Vector3.zero;

    private PlayerInput playerInput = null;
    private PlayerInput2 playerInput2 = null;


    private InputAction moveAction = null;
    private InputAction jumpAction = null;
    private bool isJumping = false;
    private bool isFalling = false;


    //private void Awake()
    //{
    //    playerInput = new PlayerInput();
    //    moveAction = playerInput.Player.Move;
    //    jumpAction = playerInput.Player.Jump;
    //    lastSafePosition = transform.position;

    //    animator.SetFloat("Direction", direction);
    //    animator.SetFloat("Speed", 0.0f);

    //}
    private void Awake()
    {
        if (isPlayer2)
        {
            playerInput2 = new PlayerInput2();
            moveAction = playerInput2.Player.Move;
            jumpAction = playerInput2.Player.Jump;
        }
        else
        {
            playerInput = new PlayerInput();
            moveAction = playerInput.Player.Move;
            jumpAction = playerInput.Player.Jump;
        }

        lastSafePosition = transform.position;

        animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", 0.0f);
    }










    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        jumpAction.performed += OnJump;
    }

    private void OnDisable()
    {
        jumpAction.performed -= OnJump;
        moveAction.Disable();
        jumpAction.Disable();
    }

    private void Update()
    {
        desiredSpeed = moveAction.ReadValue<Vector2>().x * moveSpeed;

        if (groundCheck.IsGrounded())
        {
            lastSafePosition = transform.position;
            if (rigidbody.linearVelocityY < 0.1f)
            {
                isFalling = false;
            }
        }
        else if (rigidbody.linearVelocityY < 0.0)
        {
            isFalling = true;
            isJumping = false;
        }

        if (desiredSpeed < 0.0f)
        {
            direction = -1.0f;
        }
        else if (desiredSpeed > 0.0f)
        {
            direction = 1.0f;
        }

        float currentSpeed = rigidbody.linearVelocityX;
        animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocityX = desiredSpeed;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsGrounded() && rigidbody.linearVelocityY < 0.1f)
        {
            rigidbody.linearVelocityY = jumpSpeed;
            isJumping = true;
        }
     
    }

    public void RespawnPlayer()
    {
        Vector3 spawnPosition = lastSafePosition;
        if (CheckpointManager.Instance.TryGetLastCheckpointPosition(out spawnPosition))
        {
            transform.position = spawnPosition;
        }
        transform.position = spawnPosition;
        rigidbody.linearVelocity = Vector2.zero;
    }

















    [SerializeField] private float bigScale = 1.5f;
    private bool isBig = false;
    public bool IsBig { get { return isBig; } }

    public void Grow()
    {
        if (isBig) return;
        isBig = true;
        transform.localScale *= bigScale;
    }
}