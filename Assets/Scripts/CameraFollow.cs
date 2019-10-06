using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public static CameraFollow instance = null;

	public Transform _target;
	public Vector3 _offset = -Vector3.forward;
	public float _smoothTime = 0.3f;
	public float _stepShakeDuration = 0.1f;

	private Vector3 _currentVelocity;
	private Vector3 _stepShake;
	private float _timer = 0f;

	private void Awake() {
		instance = this;
	}

	private void Update() {
		if (_target != null) {
			_timer += Time.deltaTime;
			_stepShake = Vector3.Lerp(_stepShake, Vector3.zero, Mathf.Min(_timer / _stepShakeDuration, 1f));
			Vector3 targetPosition = _target.position + _offset + _stepShake;
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, _smoothTime);
		}
	}

	public void StepShake(Vector3 position) {
		_stepShake = _target.position - position;
		_timer = 0f;
	}
}
