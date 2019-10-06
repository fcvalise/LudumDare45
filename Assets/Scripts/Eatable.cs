using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour {
	public Transform _player;
	public float _distance = 1f;
	public float _smoothTime = 0.3f;
	private Vector3 _currentVelocity;

	void Update() {
		if (Vector3.Distance(_player.position, transform.position) < _distance) {
			transform.position = Vector3.SmoothDamp(transform.position, _player.position, ref _currentVelocity, _smoothTime);
		}
		if (Vector3.Distance(_player.position, transform.position) < _distance * 0.5f) {
			Destroy(gameObject);
		}
	}
}
