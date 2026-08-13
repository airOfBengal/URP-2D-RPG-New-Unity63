using UnityEngine;

public class EntityState
{
    protected StateMachine stateMachine;
    protected string stateName;
    Animator anim;

    public EntityState(Animator anim, StateMachine stateMachine, string stateName)
    {
        this.stateMachine = stateMachine;
        this.stateName = stateName;
        this.anim = anim;
    }

    public virtual void Enter()
    {
        anim.SetBool(this.stateName, true);
    }

    public virtual void Update()
    {
        Debug.Log("I run update of " + stateName);
    }

    public virtual void Exit()
    {
        anim.SetBool(this.stateName, false);
    }
}
