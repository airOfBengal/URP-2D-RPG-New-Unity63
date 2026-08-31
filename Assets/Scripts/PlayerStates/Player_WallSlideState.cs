using UnityEngine;

public class Player_WallSlideState : PlayerState
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

        if (player.groundDetected)
        {
            player.stateMachine.ChangeState(player.idleState);
        }

        HandleWallSlide();   

        if(player.controls.Player.Jump.WasPerformedThisFrame())
        {
            player.stateMachine.ChangeState(player.wallJumpState);
        }       
    }

    private void HandleWallSlide()
    {
        if (player.moveInput.y < 0)
        {
            player.SetVelocity(player.moveInput.x * player.moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            player.SetVelocity(player.moveInput.x * player.moveSpeed, rb.linearVelocity.y * player.wallSlideSpeed);
        }
    }
}
