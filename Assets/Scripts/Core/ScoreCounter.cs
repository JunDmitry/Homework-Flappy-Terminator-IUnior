using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float _score = 0;

    public event Action<float> Changed;

    public void Add()
    {
        _score++;
        Changed?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        Changed?.Invoke(_score);
    }
}