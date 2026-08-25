using UnityEngine;

public class Player_JumpState : EntityState
{
    public Player_JumpState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(player.moveInput.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        if(rb.linearVelocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }
        
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }
}
