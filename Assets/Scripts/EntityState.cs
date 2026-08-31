using UnityEngine;

public class EntityState
{
    protected StateMachine stateMachine;
    protected string stateName;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected float stateTimer;

    public EntityState(StateMachine stateMachine, string stateName)
    {
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }

    public virtual void Enter()
    {
        anim.SetBool(stateName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;        
    }

    public virtual void Exit()
    {
        anim.SetBool(stateName, false);
    }
}
