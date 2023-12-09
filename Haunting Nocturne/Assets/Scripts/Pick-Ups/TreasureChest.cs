using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{

    InventoryManager inventory;


    void Start()
    {
        inventory = FindAnyObjectByType<InventoryManager>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            OpenTreasureChest();
            Destroy(gameObject);
        }
    }

    public void OpenTreasureChest()
    {
        if (inventory.GetPossibleEvolutions().Count <= 0)
        {
            Debug.LogWarning("No Available Evolutions"); 
            return;
        }

        WeaponEvoulationBlueprint toEvolve = inventory.GetPossibleEvolutions()[Random.Range(0, inventory.GetPossibleEvolutions().Count)];
        inventory.EvolvedWeapon(toEvolve);

    }
}
