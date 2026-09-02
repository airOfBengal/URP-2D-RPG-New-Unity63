using UnityEngine;

public class Enemy : Entity
{
    public EnemyState idleState{ get; protected set; }
    public EnemyState moveState { get; protected set; }
    public EnemyState attackState { get; protected set; }
    public EnemyState battleState { get; protected set; }
    public EnemyState deadState { get; protected set; }

    [Header("Battle Details")]
    public float battleMoveSpeed = 1f;
    public float attackDistance = 2f;
    public float attackCheckDistance = 0.1f;

    [Header("Movement Details")]
    public float idleTime = 2f;
    public float moveSpeed = 1.4f;

    [Header("Player Detection")]
    [SerializeField] LayerMask playerLayerMask;
    [SerializeField] Transform playerCheck;
    [SerializeField] float playerCheckDistance = 3f;

    public RaycastHit2D PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCheck.position, transform.right, playerCheckDistance, playerLayerMask | groundLayerMask);
        if(hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return default;
        }

        return hit;
    }

    public override void EntityDeath()
    {
        base.EntityDeath();

        stateMachine.ChangeState(deadState);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + (transform.right.x * playerCheckDistance), playerCheck.position.y));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + (transform.right.x * attackCheckDistance), playerCheck.position.y));
    }
}
