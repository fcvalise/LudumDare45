using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float _speed = 1f;
	public Transform _target;

	private void Update() {
		Vector2 targetPosition = Vector2.zero;
		if (_target == null) {
			targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		} else {
			targetPosition = _target.position;
		}
		float distance = Vector3.Distance(transform.position, targetPosition);
		float step = Mathf.Min(_speed, distance) * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
		transform.right = (Vector3)targetPosition - transform.position;
	}
}
