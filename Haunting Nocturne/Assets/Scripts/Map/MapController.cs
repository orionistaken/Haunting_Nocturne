using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    Vector3 playerLastPosition;
    

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist; //Must be greater than the length and width of the tilemap
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;


    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        playerLastPosition = player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimzer();
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }

        Vector3 moveDir = player.transform.position - playerLastPosition;
        playerLastPosition = player.transform.position;

        string directionName = GetDirectionName(moveDir);

        CheckAndSpawnChunk(directionName);

        if (directionName.Contains("Up"))
        {
            CheckAndSpawnChunk("Up");
        }
        if (directionName.Contains("Left"))
        {
            CheckAndSpawnChunk("Left");
        }
        if (directionName.Contains("Right"))
        {
            CheckAndSpawnChunk("Right");
        }
        if (directionName.Contains("Down"))
        {
            CheckAndSpawnChunk("Down");
        }
    }

    void CheckAndSpawnChunk(string dir)
    {
        if(!Physics2D.OverlapCircle(currentChunk.transform.Find(dir).position, checkerRadius, terrainMask))
        {
            SpawnChunk(currentChunk.transform.Find(dir).position);
        }
    }

    string GetDirectionName(Vector3 dir)
    {
        dir = dir.normalized;

        if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if(dir.y > 0.5f)
            {
                return dir.x > 0 ? "Right Up" : "Left Up";
            }
            else if(dir.y < -0.5f)
            {
                return dir.x > 0 ? "Right Down" : "Left Down";
            }
            else
            {
                return dir.x > 0 ? "Right" : "Left";
            }
        }
        else
        {
            if (dir.x > 0.5f)
            {
                return dir.y > 0 ? "Right Up" : "Left Up";
            }
            else if (dir.x < -0.5f)
            {
                return dir.y > 0 ? "Left Up" : "Left Down";
            }
            else
            {
                return dir.y > 0 ? "Up" : "Down";
            }
        }
    }
    void SpawnChunk(Vector3 spawnPosition)
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], spawnPosition, Quaternion.identity);
        //spawnedChunks.Add(latestChunk);

    }
    void ChunkOptimzer()
    {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;   //Check every 1 second to save cost, change this value to lower to check more times
        }
        else
        {
            return;
        }
        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
