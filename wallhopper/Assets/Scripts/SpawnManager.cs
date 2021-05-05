using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float timeDelay = 0f;
    public float repeatRate = 0f;

    public Vector3 spawnLocation;

    public GameObject wall;

    public bool isWallSpawningOnLeft = true; //A rudimentary flip-flop so we don't spawn on the same side.
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWalls", timeDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO: Create something that will make a 'playlist' of wall locations.

    void SpawnWalls(){
    
        if(isWallSpawningOnLeft){
            Instantiate(wall, spawnLocation, wall.transform.rotation);
            isWallSpawningOnLeft = false;
        }
        else{
            Vector3 otherSpawnLocation = new Vector3(-spawnLocation.x, spawnLocation.y, spawnLocation.z);
            Instantiate(wall, otherSpawnLocation , wall.transform.rotation);
            isWallSpawningOnLeft = true;
        }
    }
}
