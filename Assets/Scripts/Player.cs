using UnityEngine;

public class Player : MonoBehaviour
{
     public StateMachine stateMachine { get; private set; }
     public Player_IdleState idleState { get; private set; }
     public Player_MoveState moveState { get; private set; }
     public Player_JumpState jumpState { get; private set; }
     public Player_FallState fallState { get; private set; }
     public Player_WallSlideState wallSlideState { get; private set; }
     public Player_WallJumpState wallJumpState { get; private set; }
     public Player_DashState dashState { get; private set; }
     public Player_BasicAttackState basicAttackState { get; private set; }
     public Player_JumpAttackState jumpAttackState { get; private set; }

     public InputControls controls { get; private set; }
     public InputControls InputControl => controls;
     public Animator anim { get; private set; }
     public Rigidbody2D rb { get; private set; }
     public volatile bool isInBasicAttack;

     [Header("Movement Details")]
     [field: SerializeField] public float moveSpeed { get; private set; } = 8f;
     public Vector2 moveInput { get; private set; }
     [field: SerializeField] public float jumpForce { get; private set; } = 5f;
     [Range(0f,1f)]
     [field: SerializeField] public float inAirMoveSpeed { get; private set; } = 0.7f;
     [Range(0f,1f)]
     [field: SerializeField] public float wallSlideSpeed { get; private set; } = 0.4f;
     [field: SerializeField] public Vector2 wallJumpVelocity = new Vector2(6f, 12f);
     [Space]
     [field: SerializeField] public float dashDuration = 0.25f;
     [field: SerializeField] public float dashSpeed = 20f;

     [Header("Collision Detection")]
     [SerializeField] float groundCheckDistance;
     [SerializeField] float wallCheckDistance;
     [SerializeField] LayerMask groundLayerMask;
     [field: SerializeField] public bool groundDetected {get; private set;}
     [field: SerializeField] public bool wallDetected {get; private set;}

     [Header("Attack Details")]
     [field: SerializeField] public float comboAttackResetTime { get; private set; } = 1f;
     

     private void Awake()
     {
          anim = GetComponentInChildren<Animator>();
          rb = GetComponent<Rigidbody2D>();
          stateMachine = new StateMachine();
          idleState = new Player_IdleState(this, stateMachine, "idle");
          moveState = new Player_MoveState(this, stateMachine, "move");
          jumpState = new Player_JumpState(this, stateMachine, "jumpFall");
          fallState = new Player_FallState(this, stateMachine, "jumpFall");
          wallSlideState = new Player_WallSlideState(this, stateMachine, "wallSlide");
          wallJumpState = new Player_WallJumpState(this, stateMachine, "jumpFall");
          dashState = new Player_DashState(this, stateMachine, "dashMove");
          basicAttackState = new Player_BasicAttackState(this, stateMachine, "basicAttack");
          jumpAttackState = new Player_JumpAttackState(this, stateMachine, "jumpAttack");

          controls = new InputControls();
     }

     private void Start()
     {
          stateMachine.Initialize(idleState);

          controls.Player.Move.performed += context =>
          {
               moveInput = context.ReadValue<Vector2>();
          };
          controls.Player.Move.canceled += context =>
          {
               moveInput = Vector2.zero;
          };
     }

     private void OnEnable()
     {
          controls.Enable();
     }

     private void Update()
     {
          HandleCollisionDetection();
          stateMachine.UpdateActiveState();
     }

     private void OnDisable()
     {
          controls.Disable();
     }

     public void SetVelocity(float xVelocity, float yVelocity)
     {
          rb.linearVelocity = new Vector2(xVelocity, yVelocity);
     }

     public void JumpWall()
     {
          SetVelocity(wallJumpVelocity.x * -transform.right.x, wallJumpVelocity.y);
     }

     void HandleCollisionDetection()
     {
          groundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
          wallDetected = Physics2D.Raycast(transform.position, transform.right, wallCheckDistance, groundLayerMask);
     }

     private void OnDrawGizmos()
     {
          Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
          Gizmos.DrawLine(transform.position, transform.position + transform.right * wallCheckDistance);
     }
}
