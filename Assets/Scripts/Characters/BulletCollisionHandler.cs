using Assets.Scripts;
using System;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision.collider);
    }

    private void ProcessCollision(Collider2D collider)
    {
        if (collider.TryGetComponent(out IInteractable interactable))
            CollisionDetected?.Invoke(interactable);
    }
}