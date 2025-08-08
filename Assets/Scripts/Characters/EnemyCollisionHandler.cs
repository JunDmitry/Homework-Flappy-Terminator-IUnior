using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyCollisionHandler : MonoBehaviour
    {
        public event Action<IInteractable> CollisionDetected;

        private void OnValidate()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
                CollisionDetected?.Invoke(interactable);
        }
    }
}