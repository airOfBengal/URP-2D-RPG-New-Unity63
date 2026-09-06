using System;
using UnityEngine;

[Serializable]
public class StatOffenseGroup
{
    // physical damage
    public Stat damage;
    public Stat critPower;
    public Stat critChance;

    // elemental damage
    public Stat fireDamage;
    public Stat iceDamage;
    public Stat lightningDamage;
}
