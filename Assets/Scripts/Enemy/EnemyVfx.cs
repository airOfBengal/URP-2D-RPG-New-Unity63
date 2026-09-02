using UnityEngine;

public class EnemyVfx : EntityVfx
{
    [Header("Counter Attack Window")]
    [SerializeField] Color attackColor;
    Color originalColor;

    protected override void Awake()
    {
        base.Awake();

        originalColor = spriteRenderer.color;
    }

    public void EnableAttackAlert(bool enable)
    {
        spriteRenderer.color = enable ? attackColor : originalColor;
    }
}
