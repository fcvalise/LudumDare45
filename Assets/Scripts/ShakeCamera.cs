using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
	public static ShakeCamera instance = null;
	public float _speed = 1f;
	public float _drag = 0.9f;
	public float _maxAmount = 20f;
	public float _amount = 0f;
	private float _rotationSteer = 0f;

	private void Awake() {
		instance = this;
	}

	private void Update() {
		_rotationSteer = Mathf.Sin(Time.time) * _amount;
		float angle = transform.rotation.eulerAngles.z * _drag + _rotationSteer * Time.deltaTime * _speed;
		transform.rotation = Quaternion.Euler(0f, 0f, angle);
	}

	public void AddAmount(float amount) {
		_amount = Mathf.Min(_amount + amount, _maxAmount);
	}
}
