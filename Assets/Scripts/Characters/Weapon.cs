using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField, Min(0)] private float _secondsToAttack;

    private float _lastShootTime;

    private void Awake()
    {
        _lastShootTime = Time.time;
    }

    public void Initialize(BulletSpawner spawner)
    {
        _spawner = spawner;
    }

    public void Reset()
    {
        _lastShootTime = Time.time;
    }

    public bool TryShoot()
    {
        if (_spawner == null)
            return false;

        if (_lastShootTime + _secondsToAttack > Time.time)
            return false;

        _lastShootTime = Time.time;
        Vector3 direction = (transform.rotation * Vector2.right).normalized;

        Shoot(direction);

        return true;
    }

    private void Shoot(Vector3 direction)
    {
        _spawner.Spawn(transform.position, direction);
    }
}