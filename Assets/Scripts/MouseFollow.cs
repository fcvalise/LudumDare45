using UnityEngine;

public class MouseFollow : MonoBehaviour {
	public Transform _player;

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
		transform.position = _player.position + (Vector3) direction * 5f;
	}
}