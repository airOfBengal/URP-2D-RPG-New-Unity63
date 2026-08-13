using UnityEngine;

public class Player : MonoBehaviour
{
   public StateMachine stateMachine { get; private set; }
   private Player_IdleState idleState;
   private Player_MoveState moveState;
   private InputControls controls;
   public InputControls InputControl => controls;
   Animator anim;

   private void Awake() 
   {
        anim = GetComponentInChildren<Animator>();
        stateMachine = new StateMachine();
        idleState = new Player_IdleState(anim, stateMachine, "idle");
        moveState = new Player_MoveState(anim, stateMachine, "move");
        controls = new InputControls();
   }

   private void Start() 
   {
        stateMachine.Initialize(idleState);
        
        controls.Player.Interact.performed += context =>
        {
            stateMachine.ChangeState(idleState);
        };
        controls.Player.Interact.canceled += context => {};
        controls.Player.Move.performed += context =>
        {
            stateMachine.ChangeState(moveState);
        };
        controls.Player.Move.canceled += context =>
        {
             stateMachine.ChangeState(idleState);
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
}
