using UnityEngine;

public class Player : MonoBehaviour
{
   public StateMachine stateMachine { get; private set; }
   public Player_IdleState idleState { get; private set; }
   public Player_MoveState moveState { get; private set; }
   private InputControls controls;
   public InputControls InputControl => controls;
   public Animator anim { get; private set; }
   public Rigidbody2D rb { get; private set; }
   [field: SerializeField] public float moveSpeed { get; private set; } = 8f;
   public Vector2 moveInput { get; private set; }

   private void Awake() 
   {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine = new StateMachine();
        idleState = new Player_IdleState(this, stateMachine, "idle");
        moveState = new Player_MoveState(this, stateMachine, "move");
        controls = new InputControls();
   }

   private void Start() 
   {
        stateMachine.Initialize(idleState);
        
        controls.Player.Interact.performed += context =>
        {
            
        };
        controls.Player.Interact.canceled += context => {};
        controls.Player.Move.performed += context =>
        {
            moveInput = context.ReadValue<Vector2>();
        };
        controls.Player.Move.canceled += context =>
        {
             moveInput = Vector2.zero;
        };
   }

   private void OnEnable() {
        controls.Enable();
   }

   private void Update() 
   {
        stateMachine.UpdateActiveState();
   }

   private void OnDisable() {
        controls.Disable();
   }

   public void SetVelocity(float xVelocity, float yVelocity)
     {
          rb.linearVelocity = new Vector2(xVelocity, yVelocity);
     }
}
