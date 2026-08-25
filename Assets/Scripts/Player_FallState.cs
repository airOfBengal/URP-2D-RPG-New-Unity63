using UnityEngine;

public class Player_FallState : EntityState
{
    public Player_FallState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        // base.Enter();

        anim.SetBool(stateName, false);
        stateMachine.ChangeState(player.idleState);
    }
}
