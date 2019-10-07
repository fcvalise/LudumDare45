using UnityEngine;

public class EnemyTargetMovement : MonoBehaviour {
	public float _maxDistanceFromSpawn = 15f;
	public float _maxTimer = 10f;
	public float _speed = 1f;
	[Range(0f, 1f)] public float _curiousSpeed = 0.3f;
	[Range(0f, 1f)] public float _alertSpeed = 1f;
	public EnemySearch _enemySearch = null;

	private float _timer = 0;
	private Vector2 _steer = Vector2.zero;
	private Vector2 _randomSteer = Vector2.zero;
	private Vector3 _originPosition = Vector2.zero;

	private void Start() {
		_originPosition = transform.position;
	}

	private void Update() {
		switch (_enemySearch._state) {
			case EnemySearch.State.Chill:
				_timer -= Time.deltaTime;

				float distance = Vector3.Distance(transform.position, _originPosition);
				if (distance > _maxDistanceFromSpawn) {
					_randomSteer = (_originPosition - transform.position).normalized;
				}

				if (_timer < 0f) {
					_timer = Random.value * _maxTimer;
					_randomSteer = Random.insideUnitSphere;
				}
				transform.position = (Vector2) transform.position + _randomSteer * Time.deltaTime * _speed;
				break;
			case EnemySearch.State.Alert:
			case EnemySearch.State.Curious:
				transform.position = _enemySearch._player.position;
				_timer = 0f;
				break;
		}
	}
}