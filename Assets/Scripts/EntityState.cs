using UnityEngine;

public class EntityState
{
    protected StateMachine stateMachine;
    protected string stateName;
    protected Player player;
    Animator anim;
    Rigidbody2D rb;

    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
        this.anim = player.anim;
        this.rb = player.rb;
    }

    public virtual void Enter()
    {
        anim.SetBool(this.stateName, true);
    }

    public virtual void Update()
    {
        float moveAmount = Mathf.Abs(player.moveInput.x) + Mathf.Abs(player.moveInput.y);
        if(moveAmount > 0f)
        {
            player.stateMachine.ChangeState(player.moveState);
        }
        else
        {
            player.stateMachine.ChangeState(player.idleState);
        }
    }

    public virtual void Exit()
    {
        anim.SetBool(this.stateName, false);
    }
}
