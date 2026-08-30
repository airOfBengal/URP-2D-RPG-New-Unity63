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

        if(player.controls.Player.Attack.WasPressedThisFrame() && !player.isInBasicAttack)
        {
            player.isInBasicAttack = true;
            stateMachine.ChangeState(player.basicAttackState);
        }

        if(player.controls.Player.Dash.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.dashState);            
        }
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
        anim.SetBool(stateName, false);
    }
}
