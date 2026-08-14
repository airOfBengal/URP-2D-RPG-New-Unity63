using UnityEngine;

public class Player_MoveState : EntityState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();        

        player.SetVelocity(player.moveInput.x * player.moveSpeed * Time.deltaTime, player.moveInput.y * player.moveSpeed * Time.deltaTime);
    }
}
