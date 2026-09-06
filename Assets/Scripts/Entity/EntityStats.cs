using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public Stat maxHp;
    public StatMajorGroup majorStats;
    public StatOffenseGroup offense;
    public StatDefenceGroup defence;

    public float GetMaxHealth()
    {
        float baseHp = maxHp.GetValue();
        float bonusHp = majorStats.vitality.GetValue() * 5f;

        return baseHp + bonusHp;
    }
}
