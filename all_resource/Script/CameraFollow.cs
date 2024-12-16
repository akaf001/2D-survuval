using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;
    private Vector3 _tempPosition;

    [SerializeField] private float _max, _min;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (_player == null)
            return;
        _tempPosition = transform.position;
        _tempPosition.x = _player.position.x;
        transform.position = _tempPosition;

        if (_tempPosition.x < _min )
        {
            _tempPosition.x = _min;
        }
        if (_tempPosition.x > _max)
        {
            _tempPosition.x = _max;
        }
        transform.position = _tempPosition;
    }
}
