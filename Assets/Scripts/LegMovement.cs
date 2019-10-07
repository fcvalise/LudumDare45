using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour {
	public Transform _legRef;
	public LegMovement _otherLeg;
	public float _maxDistance = 1f;
	public float _smoothTime = 0.3f;
	public GameObject _step;
	public bool _shakeCamera;
	public AudioSource _audioSource;

	private bool _replace = false;
	private Vector3 _currentVelocity;
	private Vector3 _targetPosition;
	private List<Step> _stepList = new List<Step>();

	private void Start() {
		_audioSource = GetComponent<AudioSource>();
	}

	private void Update() {
		float distance = Vector3.Distance(transform.position, _legRef.position);

		if (distance > _maxDistance && !_otherLeg._replace && !_replace) {
			MakeStep();
		}
		if (distance > _maxDistance * 1.5f && !_replace) {
			MakeStep();
		}
		if (_replace == true) {
			transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, _smoothTime);
			if (Vector3.Distance(transform.position, _targetPosition) < 0.1f) {
				_replace = false;
			}
		}
	}

	private void MakeStep() {
		_replace = true;
		_targetPosition = _legRef.position;
		if (_audioSource) {
			_audioSource.Play();
		}
		if (_shakeCamera) {
			// CameraFollow.instance.StepShake(_targetPosition);
		}
		CreateStep();
	}

	private void CreateStep() {
		Vector3 position = transform.position + new Vector3(0f, 0f, 0.2f);
		foreach (Step step in _stepList) {
			if (step.Reset(position)) {
				return;
			}
		}
		GameObject go = Instantiate(_step, position, Quaternion.identity);
		go.GetComponent<Renderer>().sharedMaterial = transform.GetComponent<Renderer>().sharedMaterial;
		go.hideFlags = HideFlags.HideInHierarchy;
		_stepList.Add(go.GetComponent<Step>());

	}
}