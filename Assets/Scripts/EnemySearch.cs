using UnityEngine;

public class EnemySearch : MonoBehaviour {
	public enum State {
		Chill,
		Curious,
		Alert
	}

	public LayerMask _playerLayerMask;
	public float _alertDistance = 5f;
	public State _state = State.Chill;

	private CharacterState _playerState = null;
	public Transform _player = null;

	private void OnTriggerStay2D(Collider2D other) {
		if (((1 << other.gameObject.layer) & _playerLayerMask) != 0) {
			_player = other.transform;
			_playerState = _player.GetComponent<CharacterState>();
			if (!_playerState._isInWater) {
				_state = State.Curious;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		// _state = State.Chill;
		// _playerState = null;
		// _player = null;
	}

	private void Update() {
		if (_playerState != null && _playerState._isInWater) {
			_state = State.Chill;
		}

		switch (_state) {
			case State.Alert:
			case State.Curious:
				float distance = Vector2.Distance(_player.position, transform.position);

				if (distance < _alertDistance) {
					_state = State.Alert;
				}
				AudioManager.instance.PlaySongRandom();
				break;
			default:
				break;
		}
	}
}