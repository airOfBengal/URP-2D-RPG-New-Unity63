using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player_DashState : EntityState
{
    float originalGravityScale;

    public Player_DashState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        originalGravityScale = rb.gravityScale;
        rb.gravityScale = 0f;
        stateTimer = player.dashDuration;
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashSpeed * player.transform.right.x, 0f);

        if(stateTimer < 0f)
        {
            if(player.groundDetected)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else
            {
                stateMachine.ChangeState(player.fallState);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, 0);
        rb.gravityScale = originalGravityScale;
    }
}
