using UnityEngine;

public class Enemy_GroundedState : EnemyState
{
    public Enemy_GroundedState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        moveSpeedMultiplier = 1f;
    }

    public override void Update()
    {
        base.Update();

        if(enemy.PlayerDetected())
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
