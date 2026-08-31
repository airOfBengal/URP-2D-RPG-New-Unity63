using UnityEngine;

public class Enemy : Entity
{
    public EnemyState idleState;
    public EnemyState moveState;
    public EnemyState attackState;

    [Header("Movement Details")]
    public float idleTime = 2f;
    public float moveSpeed = 1.4f;

    protected override void Awake()
    {
        base.Awake();
    }
}
