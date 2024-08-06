using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  EnemyType: Scriptable Object that contains set information about an Enemy Object. 
 */
[CreateAssetMenu(menuName = "Enemies", fileName = "New Enemy")]
public class EnemyType : ScriptableObject
{
    public float startingSpeed = 10;
    public float startingHealth = 100;
    public int worth = 50;
    public int damage = 1;
}
