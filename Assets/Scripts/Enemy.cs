using UnityEngine;

public class Enemy : Entity
{
    public EnemyState idleState{ get; protected set; }
    public EnemyState moveState { get; protected set; }
    public EnemyState attackState { get; protected set; }
    public EnemyState battleState { get; protected set; }

    [Header("Movement Details")]
    public float idleTime = 2f;
    public float moveSpeed = 1.4f;

    [Header("Player detection")]
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

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + (transform.right.x * playerCheckDistance), playerCheck.position.y));
    }
}
