using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyScriptableObject", menuName ="ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    //Base stats for enemy
    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    float maxHealt;
    public float MaxHealt { get => maxHealt; private set => maxHealt = value; }

    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }

}
