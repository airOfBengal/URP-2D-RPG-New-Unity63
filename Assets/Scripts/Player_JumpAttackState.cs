using UnityEngine;

public class Player_JumpAttackState : EntityState
{
    float animTime;
    bool groundTouched;

    public Player_JumpAttackState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        animTime = 0f;
        groundTouched = false;
    }

    public override void Update()
    {
        base.Update();

        if(player.groundDetected)
        {
            if(!groundTouched)
            {
                groundTouched = true;
                anim.SetTrigger("jumpAttackTrigger");
                player.SetVelocity(0f, rb.linearVelocity.y);
            }

            animTime += Time.deltaTime;
            if(animTime > anim.GetCurrentAnimatorStateInfo(0).length)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
