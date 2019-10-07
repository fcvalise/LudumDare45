using UnityEngine;

public class Movement : MonoBehaviour {
	[SerializeField] private float _speed = 1f;
	[SerializeField] private Transform _target = null;

	private Rigidbody2D _rigidbody = null;

	private void Start() {
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		Vector2 targetPosition = _target.position;
		float distance = Vector3.Distance(transform.position, targetPosition);
		float step = Mathf.Min(_speed, distance) * Time.deltaTime;
		Vector2 force = (Vector2) transform.position + (targetPosition - (Vector2) transform.position).normalized * step;
		_rigidbody.MovePosition(force);
		transform.right = (Vector2) targetPosition - (Vector2) transform.position;
	}
}