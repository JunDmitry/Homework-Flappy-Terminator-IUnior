using UnityEngine;

public class Difficulty : MonoBehaviour
{
    private const float MaxValue = 1f;

    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField, Min(0f)] private float _secondsToEnd;
    [SerializeField, Min(0f)] private float _baseSpawnInterval;

    private float _expiredSeconds;

    public float SpawnInterval => _baseSpawnInterval / _animationCurve.Evaluate(Mathf.Min(_expiredSeconds / _secondsToEnd, MaxValue));

    private void Update()
    {
        _expiredSeconds += Time.deltaTime;
    }

    public void Reset()
    {
        _expiredSeconds = 0f;
    }
}