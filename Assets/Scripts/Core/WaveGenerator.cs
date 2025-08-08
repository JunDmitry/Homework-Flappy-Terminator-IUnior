using System.Collections;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private Difficulty _difficulty;
    [SerializeField] private WaveSpawner _spawner;

    private Coroutine _coroutine;

    public void Reset()
    {
        _spawner.Reset();
    }

    public void Restart()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _difficulty.Reset();
        _coroutine = StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_difficulty.SpawnInterval);

            _spawner.Spawn(transform.position.x);
        }
    }
}