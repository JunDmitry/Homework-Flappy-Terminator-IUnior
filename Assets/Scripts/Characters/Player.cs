using Assets.Scripts;
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(PlayerCollisionHandler), typeof(ScoreCounter))]
public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private InputReader _inputReader;

    private PlayerMover _mover;
    private PlayerCollisionHandler _collisionHandler;
    private ScoreCounter _scoreCounter;

    public event Action GameEnded;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollisionDetected;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollisionDetected;
    }

    private void Update()
    {
        if (_inputReader.IsAttack())
            _weapon.TryShoot();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }

    private void OnCollisionDetected(IInteractable interactable)
    {
        if (IsDamageInteract(interactable))
            GameEnded?.Invoke();
        else if (interactable is ScoreZone)
            _scoreCounter.Add();
    }

    private bool IsDamageInteract(IInteractable interactable)
    {
        return interactable is Enemy || interactable is Ground || interactable is Bullet;
    }
}