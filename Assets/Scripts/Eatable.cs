using UnityEngine;

public class Eatable : MonoBehaviour {
	public float _distance = 1f;
	public float _smoothTime = 0.3f;
	private Vector3 _currentVelocity;

	void Update() {
		Vector3 position = Player.PlayerTransform.position;
		
		if (Vector3.Distance(position, transform.position) < _distance) {
			transform.position = Vector3.SmoothDamp(transform.position, position, ref _currentVelocity, _smoothTime);
		}
		if (Vector3.Distance(position, transform.position) < _distance * 0.5f) {
			Destroy(gameObject);
		}
	}
}
