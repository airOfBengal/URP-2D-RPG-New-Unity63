using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IDamagable
{
    public event Action OnHealthUpdate;

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
    public EntityStats stats { get; private set; }

    private void Awake() 
    {
        entityVfx = GetComponent<EntityVfx>();    
        entity = GetComponent<Entity>();
        stats = GetComponent<EntityStats>();

        currentHp = stats.GetMaxHealth();
    }

    public virtual void TakeDamage(float damage, Transform damageDealer)
    {
        if(isDead) return;

        Vector2 power = CalculateKnockbackPower(damage, damageDealer);
        float duration = CalculateKnockbackDuration(damage);
        entity?.Knockback(power, knockbackDuration);
        entityVfx?.ShowHitVfx();
        ReduceHp(damage);
    }

    private Vector2 CalculateKnockbackPower(float damage, Transform damageDealer)
    {
        int direction = transform.position.x > damageDealer.position.x ? 1 : -1;

        Vector2 knockback = IsHeavyDamage(damage) ? heavyKnockbackPower : knockbackPower;
        knockback.x *= direction;

        return knockback;
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

    private float CalculateKnockbackDuration(float damage) => IsHeavyDamage(damage) ? heavyKnockbackDuration : knockbackDuration;
    private bool IsHeavyDamage(float damage) => damage / stats.GetMaxHealth() > heavyDamageThreshold;
}
