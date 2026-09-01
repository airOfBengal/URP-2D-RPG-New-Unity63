using System;
using UnityEngine;

public class EntityCombat : MonoBehaviour
{
    public float damage  = 10f;

    [Header("Target Detection")]
    [SerializeField] Transform targetCheck;
    [SerializeField] float targetCheckRadius;
    [SerializeField] LayerMask targetLayerMask;

    public void PerformAttack()
    {
        GetDetectedColliders();

        foreach(var target in GetDetectedColliders())
        {
            EntityHealth health = target.GetComponent<EntityHealth>();
            health.TakeDamage(damage);
        }
    }

    private Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position, targetCheckRadius, targetLayerMask);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(targetCheck.position, targetCheckRadius);
    }
}
