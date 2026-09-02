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
        foreach(var target in GetDetectedColliders())
        {
            IDamagable damagable = target.GetComponent<IDamagable>();
            damagable?.TakeDamage(damage, transform);

            // if player attacks behind side, enemy flips.
            if(damagable is EntityHealth && transform.right == target.transform.right)
            {
                target.transform.Rotate(new Vector3(0, 180, 0));
            }
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
