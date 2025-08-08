using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offset;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _player.transform.position.x + _offset;

        transform.position = position;
    }
}