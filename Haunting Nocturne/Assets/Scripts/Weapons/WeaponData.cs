using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObjects/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [System.Serializable]
    public struct LevelData
    {
        public GameObject spawnedPrefab;

        [Header("Damage")]
        public int baseDamage; 
        public int variance;

        [Header("Stats")]
        public float cooldown;
        public int piercing;
        public float speed;

    }

    public Sprite icon;
    public LevelData[] levels;

    public int GetDamage(int level)
    {
        if(level >= levels.Length)
        {
            return 0;
        }
        LevelData d = levels[level -1 ];
        return d.baseDamage + d.variance;
           
    }

    public float GetCooldown(int level)
    {
        if (level >= levels.Length)
        {
            return 0;
        }

        return levels[level-1].cooldown;
    }

}
