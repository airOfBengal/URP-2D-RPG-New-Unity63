using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] protected float maxHp = 100f;
    [SerializeField] protected bool isDead;
    EntityVfx entityVfx;

    private void Awake() 
    {
        entityVfx = GetComponent<EntityVfx>();    
    }

    public virtual void TakeDamage(float damage)
    {
        if(isDead) return;

        entityVfx?.ShowHitVfx();
        ReduceHp(damage);
    }

    protected void ReduceHp(float damage)
    {
        maxHp -= damage;
        if(maxHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
