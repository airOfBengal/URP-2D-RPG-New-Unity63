using System;
using UnityEngine;

[Serializable]
public class StatDefenceGroup
{
    // physical defence
    public Stat armor;
    public Stat evasion;

    // elemental resistance
    public Stat fireRes;
    public Stat iceRes;
    public Stat lightningRes;
}
