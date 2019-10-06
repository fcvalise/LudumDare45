using UnityEngine;

public class EnemySearch : MonoBehaviour
{
	public enum State {
		Chill,
		Curious,
		Alert
	}

	public LayerMask _playerLayerMask;
	public float _alertDistance = 5f;
	public State _state = State.Chill;

	private CircleCollider2D _collider = null;
	private CharacterState _playerState = null;
	private Transform _player = null;
	
	private void Start() {
		Collider2D collider = Physics2D.OverlapCircle(transform.position, float.MaxValue, _playerLayerMask);
		_playerState = collider.GetComponent<CharacterState>();
		_collider = GetComponent<CircleCollider2D>();
	}
	
	private void Update() {
		Vector2 position = (Vector2)transform.position + _collider.offset.x * (Vector2)transform.right;
		Collider2D collider = Physics2D.OverlapCircle(position, _collider.radius, _playerLayerMask);

		if (collider != null && !_playerState._isInWater) {
			Transform player = collider.transform;
			float distance = Vector2.Distance(player.position, transform.position);

			if (distance < _alertDistance) {
				_state = State.Alert;
			} else {
				_state = State.Curious;
			}
		} else {
			_state = State.Chill;
		}
	}
}
