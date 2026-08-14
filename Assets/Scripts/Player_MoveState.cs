using UnityEngine;

public class Player_MoveState : EntityState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();        

        // adjust left-right facing
        if(player.moveInput.x < 0)
        {
            player.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(player.moveInput.x > 0)
        {
            player.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        // add movement
        player.SetVelocity(player.moveInput.x * player.moveSpeed * Time.deltaTime, player.moveInput.y * player.moveSpeed * Time.deltaTime);
    }
}
