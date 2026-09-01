using UnityEngine;

public class Player_FallState : Player_AiredState
{
    public Player_FallState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        anim.SetBool(stateName, false);
    }

    public override void Update()
    {
        base.Update();

        anim.SetFloat("yVelocity", rb.linearVelocity.y);

        if(player.groundDetected)
        {
            player.stateMachine.ChangeState(player.idleState);
        }

        if(player.wallDetected)
        {
            player.stateMachine.ChangeState(player.wallSlideState);
        }
    }
}
