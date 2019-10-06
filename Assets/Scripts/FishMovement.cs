using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {
	public float _radius = 10f;
	public float _maxTimer = 10f;
	public float _speed = 1f;
	public float _drag = 0.95f;

	private Vector3 _target = Vector3.zero;
	private float _timer = 0;
	private Vector3 _steer = Vector3.zero;

	private void Update() {
		_timer -= Time.deltaTime;
		if (_timer < 0f) {
			_target = Random.insideUnitSphere * _radius;
			_timer = Random.value * _maxTimer;
		}
		_steer = _steer * _drag + (_target - transform.localPosition) * _speed;
		Vector3 localPosition = transform.localPosition + _steer * Time.deltaTime;
		localPosition.z = -1f;
		transform.localPosition = localPosition;
		_steer.z = 0f;
		transform.right = _steer;
	}
}
