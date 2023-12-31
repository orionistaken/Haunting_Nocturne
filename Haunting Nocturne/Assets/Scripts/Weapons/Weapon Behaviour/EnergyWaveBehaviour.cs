using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWaveBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> damagedEnemy;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        damagedEnemy = new List<GameObject>();
    }

    // Update is called once per frame
    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy") && !damagedEnemy.Contains(col.gameObject))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage(), transform.position);

            damagedEnemy.Add(col.gameObject);
        }
        else if (col.CompareTag("Prop"))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable) && !damagedEnemy.Contains(col.gameObject))
            {
                breakable.TakeDamage(GetCurrentDamage());
                damagedEnemy.Add(col.gameObject);
            }
        }
    }
}
