using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float timeDelay = 0f;
    public float repeatRate = 0f;

    public Vector3 spawnLocation;

    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWalls", timeDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWalls(){
        Instantiate(wall, spawnLocation, wall.transform.rotation);
    }
}
