using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(EnemyCollisionHandler))]
    public class Enemy : MonoBehaviour, IInteractable
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private EnemyAnimatorHandler _enemyAnimator;

        private EnemyCollisionHandler _collisionHandler;

        public event Action<Enemy> Destroying;

        private void Awake()
        {
            _collisionHandler = GetComponent<EnemyCollisionHandler>();
        }

        private void OnEnable()
        {
            _collisionHandler.CollisionDetected += OnCollisionDetected;
            _enemyAnimator.Destroying += InvokeDestroying;
        }

        private void OnDisable()
        {
            _collisionHandler.CollisionDetected -= OnCollisionDetected;
            _enemyAnimator.Destroying -= InvokeDestroying;
        }

        private void Update()
        {
            _weapon.TryShoot();
        }

        public void Initialize(BulletSpawner bulletSpawner)
        {
            _weapon.Initialize(bulletSpawner);
        }

        public void Reset()
        {
            _weapon.Reset();
        }

        private void InvokeDestroying()
        {
            Destroying?.Invoke(this);
        }

        private void OnCollisionDetected(IInteractable interactable)
        {
            if (interactable is Bullet)
                _enemyAnimator.Die();
        }
    }
}