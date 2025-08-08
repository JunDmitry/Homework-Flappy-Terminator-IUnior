using Assets.Scripts;
using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnValidate()
    {
        if (TryGetComponent(out Collider2D collider))
            collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IInteractable interactable))
            CollisionDetected?.Invoke(interactable);
    }
}