using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy_MoveState : Enemy_GroundedState
{
    public Enemy_MoveState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if(enemy.wallDetected || !enemy.groundDetected)
        {
            enemy.Flip();
        }
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.transform.right.x , rb.linearVelocity.y);

        if(enemy.wallDetected || !enemy.groundDetected)
        {
            stateMachine.ChangeState(enemy.idleState);            
        }

        if(Keyboard.current.fKey.wasPressedThisFrame)
        {
            stateMachine.ChangeState(enemy.attackState);
        }
    }
}
