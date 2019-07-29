using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    public SpawnObstacles middle;
    public float minDist = 50f;
    public float maxDist = 300f;
    public float maxDistDecreaseRate = 1f;
    private float _dist;

    private void Start()
    {
        _dist = Random.Range(minDist, maxDist);
    }

    private void Update()
    {
        _dist -= Hand.CurrentSpeed * Time.deltaTime;
        if (_dist <= 0)
        {
            maxDist -= maxDistDecreaseRate;
            maxDist = Mathf.Max(maxDist, minDist);
            _dist = Random.Range(minDist, maxDist);
            middle.Spawn();
        }
    }
}