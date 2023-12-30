using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {

    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedFireball = Instantiate(weaponData.Prefab);
        spawnedFireball.transform.position = transform.position;
        spawnedFireball.transform.parent = transform;

    }
}