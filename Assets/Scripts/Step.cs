using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour {
	public float _time = 1f;
	private float _duration = 0f;

	private void Start() {
		_duration = _time;
	}

	private void Update() {
		_time -= Time.deltaTime;
		if (_time >= 0f) {
			transform.localScale = Vector3.one * (_time / _duration);
		}
	}

	public bool Reset(Vector3 position) {
		if (_time < 0f) {
			_time = _duration;
			transform.position = position;
			return true;
		}
		return false;
	}
}
