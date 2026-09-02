using UnityEngine;

public class Enemy_DeadState : EnemyState
{
    Collider2D collider;

    public Enemy_DeadState(Enemy enemy, StateMachine stateMachine, string stateName) : base(enemy, stateMachine, stateName)
    {
        collider = enemy.GetComponent<Collider2D>();
    }

    public override void Enter()
    {        
        anim.enabled = false;
        collider.enabled = false;

        rb.gravityScale = 12;
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 15);

        stateMachine.SwitchOffStateMachine();
    }

    public override void Update()
    {
        if(enemy.transform.position.y <= -50f)
        {
            enemy.EntityDestroy();
        }
    }
}
