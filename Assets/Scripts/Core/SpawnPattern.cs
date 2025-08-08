using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnPattern
{
    [SerializeField] private float[] _spawnPoints;

    public IEnumerable<float> Positions => _spawnPoints;

    public IEnumerator<float> GetEnumerator()
    {
        return Positions.GetEnumerator();
    }
}