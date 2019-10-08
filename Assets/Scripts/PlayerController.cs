using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Transform _player;
	public float _speed = 5f;

	private void Update() {
		// transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector2 direction = Vector2.zero;
		if (Input.GetKey(KeyCode.W)) {
			direction.y = 1f;
		}
		if (Input.GetKey(KeyCode.S)) {
			direction.y = -1f;
		}
		if (Input.GetKey(KeyCode.A)) {
			direction.x = -1f;
		}
		if (Input.GetKey(KeyCode.D)) {
			direction.x = 1f;
		}
		Vector3 position = _player.position + (Vector3) direction * _speed;
		position.y = Mathf.Clamp(position.y, -5, 5);
		transform.position = position;
	}
}