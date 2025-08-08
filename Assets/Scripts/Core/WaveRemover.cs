using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WaveRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private ScoreZonePool _scoreZonePool;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemyPool.Release(enemy);
        else if (collision.TryGetComponent(out ScoreZone zone))
            _scoreZonePool.Release(zone);
    }
}