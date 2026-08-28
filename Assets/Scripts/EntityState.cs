using UnityEngine;

public class EntityState
{
    protected StateMachine stateMachine;
    protected string stateName;
    protected Player player;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected float stateTimer;

    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
        anim = player.anim;
        rb = player.rb;
    }

    public virtual void Enter()
    {
        anim.SetBool(stateName, true);
    }

    public virtual void Update()
    {
        Flip();
        stateTimer -= Time.deltaTime;        
    }

    protected void Flip()
    {
        // adjust left-right facing
        if (rb.linearVelocity.x < 0)
        {
            player.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (rb.linearVelocity.x > 0)
        {
            player.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    public virtual void Exit()
    {
        anim.SetBool(stateName, false);
    }
}
