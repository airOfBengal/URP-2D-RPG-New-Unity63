using UnityEngine;

public class EntityAnimationTriggers : MonoBehaviour
{
    private EntityCombat entityCombat;

    protected virtual void Awake()
    {
        entityCombat = GetComponentInParent<EntityCombat>();
    }

    private void AttackTrigger()
    {
        entityCombat.PerformAttack();
    }
}
