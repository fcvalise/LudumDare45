using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Transform _player;
	public float _speed = 5f;
	public Vector2 _startMovement;
	public Vector2 _endMovement;
	[Range(0f, 1f)] public float _maxDistance = 0.1f;
	public Transform _beginTouch;
	public Transform _endTouch;
	public float _touchSmoothDamp = 0.3f;

	private Vector2 _currentVelocity;
	private Vector2 _currentVelocityFeedback;

	private void Update() {
		// transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButton(0)) {
			if (Input.GetMouseButtonDown(0)) {
				_startMovement = Input.mousePosition;
			}
			if (Input.GetMouseButton(0)) {
				_endMovement = Input.mousePosition;
			}
			float distance = Vector2.Distance(_startMovement, _endMovement);
			if (distance > Screen.width * _maxDistance) {
				_startMovement = Vector2.SmoothDamp(_startMovement, _endMovement, ref _currentVelocity, _touchSmoothDamp);
			}
			Vector2 direction = (_endMovement - _startMovement).normalized;
			Vector3 position = _player.position + (Vector3) direction * _speed;
			position.y = Mathf.Clamp(position.y, -5, 5);
			transform.position = position;
			_beginTouch.position = Vector2.SmoothDamp(_beginTouch.position, Camera.main.ScreenToWorldPoint(_startMovement), ref _currentVelocityFeedback, 0.1f);
			_endTouch.position = Camera.main.ScreenToWorldPoint(_endMovement);
		} else {
			Vector2 direction = Vector2.zero;
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
				direction.y = 1f;
			}
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
				direction.y = -1f;
			}
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
				direction.x = -1f;
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
				direction.x = 1f;
			}
			Vector3 position = _player.position + (Vector3) direction * _speed;
			position.y = Mathf.Clamp(position.y, -5, 5);
			transform.position = position;
		}
	}
}