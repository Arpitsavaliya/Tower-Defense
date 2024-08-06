using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Turrets", fileName = "New Turret")]
public class ScriptableTurret : ScriptableObject
{
    [Header("Basic Attributes")]
    public float fireRate = 2f;
    public float range = 3f;
    public float damage = 100f;
    [Header("Extra Behaviour")]
    public int extraGold = 0;
    public float slowPct = 0;
}
