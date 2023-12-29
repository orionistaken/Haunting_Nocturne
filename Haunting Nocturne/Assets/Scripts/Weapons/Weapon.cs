using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("a",false)]
public class Weapon : MonoBehaviour
{
    public WeaponData data;
    public int currentLevel = 1;
    float currentCooldown;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        currentCooldown = data.GetCooldown(currentLevel);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = data.GetCooldown(currentLevel);
    }
}
