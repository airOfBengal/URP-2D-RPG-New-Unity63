using UnityEngine;

public class Enemy_BattleState : EnemyState
{
    private Transform player;
    private bool WithinAttackRange() => DistanceToPlayer() < enemy.attackDistance;

    public Enemy_BattleState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if(player == null)
        {
            player = enemy.PlayerDetected().transform;
        }
    }

    public override void Update()
    {
        base.Update();

        if(WithinAttackRange())
        {
            stateMachine.ChangeState(enemy.attackState);
        }
        else
        {
            enemy.SetVelocity(enemy.battleMoveSpeed * enemy.transform.right.x, rb.linearVelocityY);
        }

    }

    private float DistanceToPlayer()
    {
        if(player == null) return float.MaxValue;

        return Mathf.Abs(player.position.x - enemy.transform.position.x);
    }
}
