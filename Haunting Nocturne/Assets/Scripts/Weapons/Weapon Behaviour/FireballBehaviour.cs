using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> damagedEnemies;


    protected override void Start()
    {
        base.Start();
        damagedEnemies = new List<GameObject>();
    }


    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !damagedEnemies.Contains(col.gameObject))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage(), transform.position);

            damagedEnemies.Add(col.gameObject);
        }
        else if (col.CompareTag("Prop") && !damagedEnemies.Contains(col.gameObject))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(GetCurrentDamage());
                damagedEnemies.Add(col.gameObject);
            }
        }
    }
}
