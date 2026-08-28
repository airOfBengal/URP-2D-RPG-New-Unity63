using UnityEngine;

public class Player_WallJumpState : EntityState
{
    public Player_WallJumpState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpWall();
    }

    public override void Update()
    {
        base.Update();

        if(rb.linearVelocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }
    }
}
