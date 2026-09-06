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

    public float GetEvasion()
    {
        float baseEvasion = defence.evasion.GetValue();
        float bonusEvasion = majorStats.agility.GetValue() * 0.5f;

        return baseEvasion + bonusEvasion;
    }
}
