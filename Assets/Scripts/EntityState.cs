using UnityEngine;

public class EntityState
{
    protected StateMachine stateMachine;
    protected string stateName;
    protected Player player;
    protected Animator anim;
    protected Rigidbody2D rb;

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
        anim.SetBool(this.stateName, true);
    }

    public virtual void Update()
    {
        Flip();
    }

    protected void Flip()
    {
        // adjust left-right facing
        if (player.moveInput.x < 0)
        {
            player.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (player.moveInput.x > 0)
        {
            player.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    public virtual void Exit()
    {
        anim.SetBool(this.stateName, false);
    }
}
