using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
    public float _radius = 10f;
    public float _maxTimer = 10f;
    public float _speed = 1f;
    public float _drag = 0.95f;
    public LayerMask _playerLayerMask;

    private Vector3 _target = Vector3.zero;
    private Transform _player = null;
    private float _timer = 0;
    private Vector3 _steer = Vector3.zero;

    private void FixedUpdate() {
        _timer -= Time.deltaTime;
        if (_timer < 0f) {
            _target = Random.insideUnitSphere * _radius;
            _timer = Random.value * _maxTimer;
        }
        if (_player != null) {
            Vector3 playerTarget = (_player.transform.position - transform.position).normalized * _radius;
            _steer = _steer * _drag + (playerTarget + _target - transform.localPosition) * _speed;
        } else {
            _steer = _steer * _drag + (_target - transform.localPosition) * _speed;
        }
        Vector3 localPosition = transform.localPosition + _steer * Time.fixedDeltaTime;
        localPosition.z = -1f;
        transform.localPosition = localPosition;
        _steer.z = 0f;
        transform.right = _steer;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (((1 << other.gameObject.layer) & _playerLayerMask) != 0) {
            if (_player == null) {
                _speed *= 2f;
            }
            _player = other.transform;
            // _steer += (transform.position - other.transform.position) * _speed;
            // Destroy(gameObject.transform.parent.gameObject);
        }

    }
}