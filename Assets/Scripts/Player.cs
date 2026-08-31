using System;
using UnityEngine;

public class Player : Entity
{
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

     

     [Header("Attack Details")]
     [field: SerializeField] public float comboAttackResetTime { get; private set; } = 1f;
     

     protected override void Awake()
     {
          base.Awake();
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

     protected override void Start()
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

     public void JumpWall()
     {
          SetVelocity(wallJumpVelocity.x * -transform.right.x, wallJumpVelocity.y);
          Flip();
     }


}
