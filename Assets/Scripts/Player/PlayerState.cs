using UnityEngine;

public class PlayerState : EntityState
{
    protected Player player;

    public PlayerState(Player player, StateMachine stateMachine, string stateName) : base(stateMachine, stateName)
    {
        this.player = player;
        anim = player.anim;
        rb = player.rb;
    }

    public override void Update()
    {
        base.Update();

        // Flip();

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

    void Flip()
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
}
