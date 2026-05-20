using UnityEngine;

public class Player : MonoBehaviour
{
   public StateMachine stateMachine { get; private set; }
   private Player_IdleState idleState;
   private Player_MoveState moveState;
   private InputControls controls;
   public InputControls InputControl => controls;

   private void Awake() 
   {
        stateMachine = new StateMachine();
        idleState = new Player_IdleState(stateMachine, "Idle");
        moveState = new Player_MoveState(stateMachine, "Move");
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
        controls.Player.Jump.performed += context =>
        {
            stateMachine.ChangeState(moveState);
        };
        controls.Player.Jump.canceled += context => {};
   }

   private void OnEnable() {
        controls.Enable();
   }

   private void Update() 
   {
        stateMachine.currentState.Update(); 
   }

   private void OnDisable() {
        controls.Disable();
   }
}
