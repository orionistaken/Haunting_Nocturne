using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))       //if it so closeto the player destroy the gem
        {
            Destroy(gameObject);
        }
    }
}
