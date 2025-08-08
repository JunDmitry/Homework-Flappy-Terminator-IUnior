using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField, Min(0)] private float _jumpForce;
    [SerializeField, Min(0)] private float _moveSpeed;
    [SerializeField, Min(0)] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Rigidbody2D _rigidbody;
    private Vector3 _startPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _minRotation = Quaternion.Euler(0f, 0f, _minRotationZ);
        _maxRotation = Quaternion.Euler(0f, 0f, _maxRotationZ);

        Reset();
    }

    private void FixedUpdate()
    {
        if (_inputReader.IsJump())
        {
            _rigidbody.velocity = new Vector2(_moveSpeed, _jumpForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.fixedDeltaTime);
    }

    public void Reset()
    {
        transform.SetPositionAndRotation(_startPosition, Quaternion.identity);
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
    }
}