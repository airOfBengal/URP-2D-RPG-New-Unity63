using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public Stat maxHp;
    public Stat vitality;

    public float GetMaxHealth()
    {
        float baseHp = maxHp.GetValue();
        float bonusHp = vitality.GetValue() * 5f;

        return baseHp + bonusHp;
    }
}
