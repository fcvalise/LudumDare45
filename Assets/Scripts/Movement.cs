using UnityEngine;

public class Movement : MonoBehaviour {
	[SerializeField] private float _speed = 1f;
	[SerializeField] private Transform _target = null;
	[SerializeField] private Vector2 _constraint = Vector2.one;

	private Rigidbody2D _rigidbody = null;

	private void Start() {
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		Vector2 targetPosition = _target.position;
		float distance = Vector3.Distance(transform.position, targetPosition);
		float step = Mathf.Min(_speed, distance) * Time.fixedDeltaTime;
		Vector2 force = (Vector2) transform.position + (targetPosition - (Vector2) transform.position).normalized * step * _constraint;
		_rigidbody.MovePosition(force);
		transform.right = (Vector2) targetPosition - (Vector2) transform.position;
		Vector3 rot = transform.rotation.eulerAngles;
		if (rot.y == 180) {
			rot.y = 0;
			rot.z = 180;
		}
		transform.rotation = Quaternion.Euler(rot);
	}
}