using Assets.Scripts;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BulletCollisionHandler))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField, Min(0)] private float _moveSpeed;
    [SerializeField, Min(0)] private float _lifeTime;

    private Rigidbody2D _rigidbody;
    private BulletCollisionHandler _handler;
    private float _enableTime;

    private Vector2 _flightDirection = Vector2.zero;

    public event Action<Bullet> Destroying;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _handler = GetComponent<BulletCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += OnCollisitonDetected;
        _enableTime = Time.time;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= OnCollisitonDetected;
    }

    private void Update()
    {
        if (_enableTime + _lifeTime <= Time.time)
        {
            Destroying?.Invoke(this);
            return;
        }

        _rigidbody.velocity = _moveSpeed * _flightDirection;
    }

    private void LateUpdate()
    {
        transform.right = _flightDirection;
    }

    public void Reset()
    {
        transform.rotation = Quaternion.identity;

        if (_rigidbody != null)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0;
        }
    }

    public void Initialize(Vector2 flightDirection)
    {
        _flightDirection = flightDirection;
    }

    private void OnCollisitonDetected(IInteractable interactable)
    {
        if (interactable is not Enemy && interactable is not Player)
            return;

        Destroying?.Invoke(this);
    }
}