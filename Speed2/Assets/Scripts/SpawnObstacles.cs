using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public float ObjectsPerMeter = 0.5f;
    public GameObject[] Obstacles;
    public float HorizontalVariance = 3f;


    private Transform _spawnPoint;
    private float _dist;

    void Start()
    {
        _spawnPoint = transform;
    }

    void Update()
    {
        _dist += Hand.CurrentSpeed * Time.deltaTime;
        if (_dist > 0.5f / ObjectsPerMeter)
        {
            _dist = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(Obstacles[Random.Range(0, Obstacles.Length)],
            _spawnPoint.position +
            new Vector3(Random.Range(-HorizontalVariance / 2f, HorizontalVariance / 2f), 0, 0),
            Quaternion.identity);
    }
}