using System;
using UnityEngine;

public class EntityCombat : MonoBehaviour
{

    [Header("Target Detection")]
    [SerializeField] Transform targetCheck;
    [SerializeField] float targetCheckRadius;
    [SerializeField] LayerMask targetLayerMask;

    public void PerformAttack()
    {
        GetDetectedColliders();

        foreach(var target in GetDetectedColliders())
        {
            Debug.Log("Attacking " + target.name);
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
