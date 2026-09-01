using UnityEngine;

public class EntityAnimationTriggers : MonoBehaviour
{
    private EntityCombat entityCombat;

    private void Awake()
    {
        entityCombat = GetComponentInParent<EntityCombat>();
    }

    private void AttackTrigger()
    {
        entityCombat.PerformAttack();
    }
}
