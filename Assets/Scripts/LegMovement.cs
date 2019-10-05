using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
	public Transform _legRef;
	public LegMovement _otherLeg;
	public float _maxDistance = 1f;
	public float _smoothTime = 0.3f;

	private bool _replace = false;
	private Vector3 _currentVelocity;
	private Vector3 _targetPosition;

	private void Update() {
		if (Vector3.Distance(transform.position, _legRef.position) > _maxDistance && !_otherLeg._replace) {
			_replace = true;
			_targetPosition = _legRef.position;
		}
		if (_replace == true) {
			transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, _smoothTime);
			if (Vector3.Distance(transform.position, _targetPosition) < 0.1f) {
				_replace = false;
			}
		}
	}
}
