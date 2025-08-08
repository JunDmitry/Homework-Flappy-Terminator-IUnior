using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;

    private void OnEnable()
    {
        _bulletPool.Getted += OnGetted;
        _bulletPool.Released += OnReleased;
    }

    private void OnDisable()
    {
        _bulletPool.Getted -= OnGetted;
        _bulletPool.Released -= OnReleased;
    }

    public void Spawn(Vector3 position, Vector3 direction)
    {
        Bullet bullet = _bulletPool.Get();
        bullet.Initialize(direction);

        bullet.transform.position = position;
    }

    public void Reset()
    {
        _bulletPool.Reset();
    }

    private void OnGetted(Bullet bullet)
    {
        bullet.Destroying += OnDestroying;
    }

    private void OnReleased(Bullet bullet)
    {
        bullet.Destroying -= OnDestroying;
        bullet.Reset();
    }

    private void OnDestroying(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }
}