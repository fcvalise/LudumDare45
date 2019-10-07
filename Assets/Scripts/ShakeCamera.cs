using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
	public static ShakeCamera instance = null;
	public float _speed = 1f;
	public float _drag = 0.9f;
	public float _maxAmount = 1f;
	public float _amount = 0f;
	private float _rotationSteer = 0f;

	public float _angle;

	private void Awake() {
		instance = this;
	}

	private void Update() {
		_rotationSteer = Mathf.Sin(Time.time) * _amount;
		_angle = _angle * _drag + _rotationSteer * Time.deltaTime * _speed;
		transform.rotation = Quaternion.Euler(0f, 0f, _angle);
	}

	public void AddAmount(float amount) {
		_amount = Mathf.Min(_amount + amount * 0.01f, _maxAmount);
	}
}
