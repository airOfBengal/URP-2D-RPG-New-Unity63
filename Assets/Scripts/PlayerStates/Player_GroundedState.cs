using UnityEngine;

public class Player_GroundedState : PlayerState
{
    public Player_GroundedState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();        

        if(player.controls.Player.Jump.WasPerformedThisFrame())
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }        

        float moveAmount = Mathf.Abs(player.moveInput.x) + Mathf.Abs(player.moveInput.y);
        if(moveAmount > 0f)
        {
            player.stateMachine.ChangeState(player.moveState);
        }
        else if(this is Player_MoveState)
        {
            player.stateMachine.ChangeState(player.idleState);
        }
    }
}
