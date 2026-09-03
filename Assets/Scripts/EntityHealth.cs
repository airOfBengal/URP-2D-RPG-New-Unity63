using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IDamagable
{
    public event Action OnHealthUpdate;

    [field: SerializeField] public float maxHp { get; private set; } = 100f;
    [SerializeField] protected bool isDead;
    public float currentHp { get; private set; }

    [Header("On Damage")]
    [SerializeField] Vector2 knockbackPower = new Vector2(1.5f, 2.5f);
    [SerializeField] float knockbackDuration = 0.2f;

    [Header("On Heavy Damage")]
    [SerializeField] Vector2 heavyKnockbackPower = new(7, 7);
    [SerializeField] float heavyKnockbackDuration = 0.5f;
    [SerializeField] float heavyDamageThreshold = 0.3f;


    EntityVfx entityVfx;
    Entity entity;

    private void Awake() 
    {
        entityVfx = GetComponent<EntityVfx>();    
        entity = GetComponent<Entity>();

        currentHp = maxHp;
    }

    public virtual void TakeDamage(float damage, Transform damageDealer)
    {
        if(isDead) return;

        Vector2 power = CalculateKnockbackPower(damageDealer);
        entity?.Knockback(power, knockbackDuration);
        entityVfx?.ShowHitVfx();
        ReduceHp(damage);
    }

    private Vector2 CalculateKnockbackPower(Transform damageDealer)
    {
        int direction = transform.position.x > damageDealer.position.x ? 1 : -1;
        return new Vector2(knockbackPower.x * direction, knockbackPower.y);
    }

    protected void ReduceHp(float damage)
    {
        currentHp -= damage;
        OnHealthUpdate?.Invoke();
        if(currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        entity.EntityDeath();
    }
}
