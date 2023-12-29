using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedAxe = Instantiate(weaponData.Prefab);
        spawnedAxe.transform.position = transform.position;
        spawnedAxe.GetComponent<AxeBehaviour>().DirectionChechker(-pm.lastMovedVector);
    }
}
