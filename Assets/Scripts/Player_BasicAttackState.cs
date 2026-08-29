using System;
using UnityEngine;

public class Player_BasicAttackState : EntityState
{
    const int FIRST_COMBO_INDEX = 1;
    const int COMBO_LIMIT = 3;
    int comboIndex = 1;
    
    public Player_BasicAttackState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        ResetComboIndexIfNeeded();
        anim.SetInteger("basicAttackIndex", comboIndex);
        stateTimer = anim.GetCurrentAnimatorStateInfo(0).length;
    }

    private void ResetComboIndexIfNeeded()
    {
        if(comboIndex > COMBO_LIMIT)
        {
            comboIndex = FIRST_COMBO_INDEX;
        }
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.isInBasicAttack = false;
        comboIndex++;
    }
}
