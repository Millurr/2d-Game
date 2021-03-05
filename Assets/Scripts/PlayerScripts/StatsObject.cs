using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Character Stats/Brawler")]
public class StatsObject : ScriptableObject
{
    public float health;
    public float stamina;

    // Damages
    public float attackDamage;

    // Range
    public float attackRange;

    // Buffs
    public float defenseBuff;
    public float enduranceBuff;
}
