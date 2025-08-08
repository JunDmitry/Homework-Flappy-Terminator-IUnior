using Assets.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private ScoreZonePool _scoreZonePool;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private SpawnPattern[] _spawnPatterns;

    private void OnEnable()
    {
        _enemyPool.Getted += OnGetted;
        _enemyPool.Released += OnReleased;
    }

    private void OnDisable()
    {
        _enemyPool.Getted -= OnGetted;
        _enemyPool.Released -= OnReleased;
    }

    private void OnDrawGizmosSelected()
    {
        float xPoint = transform.position.x;
        float step = 1f;
        float radius = 0.25f;

        foreach (SpawnPattern pattern in _spawnPatterns)
        {
            Gizmos.color = Color.red;

            foreach (float yPoint in pattern)
                Gizmos.DrawSphere(new Vector3(xPoint, yPoint, 0f), radius);

            xPoint += step;
        }
    }

    public void Spawn(float xPosition)
    {
        SpawnScoreZone(xPosition);

        SpawnPattern pattern = _spawnPatterns[Random.Range(0, _spawnPatterns.Length)];
        Vector2 position = new(xPosition, 0f);

        foreach (float yPosition in pattern)
        {
            Enemy enemy = _enemyPool.Get();

            position.y = yPosition;
            enemy.transform.position = position;
        }
    }

    public void Reset()
    {
        _enemyPool.Reset();
        _scoreZonePool.Reset();
        _bulletSpawner.Reset();
    }

    private void OnGetted(Enemy enemy)
    {
        enemy.Destroying += _enemyPool.Release;
        enemy.Initialize(_bulletSpawner);
    }

    private void OnReleased(Enemy enemy)
    {
        enemy.Destroying -= _enemyPool.Release;
        enemy.Reset();
    }

    private void SpawnScoreZone(float xPosition)
    {
        ScoreZone zone = _scoreZonePool.Get();
        zone.transform.position = new(xPosition, transform.position.y);
    }
}