using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats player;
    CircleCollider2D playerCollector;
    public float pullSpeed;
    List<Rigidbody2D> attractedRigidbodies = new List<Rigidbody2D>();
    [SerializeField] private AudioSource collectSoundEffect;

    void Start()
    {
        player = FindAnyObjectByType<PlayerStats>();
        playerCollector= GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        playerCollector.radius = player.CurrentMagnet;
        List<int> toRemove = new List<int>();

        for (int i = 0; i < attractedRigidbodies.Count; i++)
        {
          
            if (attractedRigidbodies[i] == null)
            {
                
                continue;
            }

            
            Vector2 forceDirection = (transform.position - attractedRigidbodies[i].transform.position).normalized;
           
            attractedRigidbodies[i].AddForce(forceDirection * pullSpeed);
        }

        
        attractedRigidbodies.Clear();
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.TryGetComponent(out ICollectable collectable))
        {
            collectSoundEffect.Play();
            attractedRigidbodies.Add(col.gameObject.GetComponent<Rigidbody2D>());

            collectable.Collect();
        }
    }
}
