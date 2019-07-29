using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] Obstacles;
    
    private Transform _spawnPoint;

    private bool mustSpawn;

    void Start()
    {
        _spawnPoint = transform;
    }
    
    public void Spawn()
    {
        Instantiate(Obstacles[Random.Range(0, Obstacles.Length)],
            _spawnPoint.position,
            transform.rotation);
    }
}