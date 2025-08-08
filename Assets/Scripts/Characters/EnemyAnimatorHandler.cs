using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimatorHandler : MonoBehaviour
    {
        private const string Death = nameof(Death);

        private readonly int _deathHash = Animator.StringToHash(Death);
        private Animator _animator;

        public event Action Destroying;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Die()
        {
            _animator.SetTrigger(_deathHash);
        }

        public void InvokeDestroying()
        {
            Destroying?.Invoke();
        }
    }
}