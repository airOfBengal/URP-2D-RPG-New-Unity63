using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;
    protected float moveSpeedMultiplier = 1f;

    public EnemyState(Enemy enemy, StateMachine stateMachine, string stateName) : base(stateMachine, stateName)
    {
        this.enemy = enemy;
        rb = enemy.rb;
        anim = enemy.anim;
    }

    public override void Update()
    {
        base.Update();

        anim.SetFloat("xVelocity", rb.linearVelocityX);
        anim.SetFloat("moveSpeedMultiplier", moveSpeedMultiplier);
    }
}
