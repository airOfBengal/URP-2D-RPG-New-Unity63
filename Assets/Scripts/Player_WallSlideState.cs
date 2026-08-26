using UnityEngine;

public class Player_WallSlideState : EntityState
{
    public Player_WallSlideState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (!player.wallDetected)
        {
            player.stateMachine.ChangeState(player.fallState);
        }

        if(player.groundDetected)
        {
            player.stateMachine.ChangeState(player.idleState);            
        }

        if(player.moveInput.y < 0)
        {
            player.SetVelocity(player.moveInput.x * player.moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            player.SetVelocity(player.moveInput.x * player.moveSpeed, rb.linearVelocity.y * player.wallSlideSpeed);
        }
    }

}
