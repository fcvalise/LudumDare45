using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] private float _speed = 1f;
	[SerializeField] private Transform _target = null;

	private void Update() {
		Vector2 targetPosition = _target.position;
		float distance = Vector3.Distance(transform.position, targetPosition);
		float step = Mathf.Min(_speed, distance) * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
		transform.right = (Vector3)targetPosition - transform.position;
	}
}
