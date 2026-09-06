using UnityEngine;

public interface IDamagable
{
    bool TakeDamage(float damage, Transform damageDealer);
}
