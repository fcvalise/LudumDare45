using UnityEngine;

public class CharacterState : MonoBehaviour {
	public LayerMask _waterLayerMask;
	public bool _isInWater = false;
	private AudioSource _audioSource = null;

	private void Start() {
		_audioSource = GetComponent<AudioSource>();
	}

	private void Update() {
		bool wasInWater = _isInWater;
		_isInWater = Physics2D.OverlapCircle(transform.position, 0.1f, _waterLayerMask);
		if (_isInWater != wasInWater && _audioSource != null) {
			if (_isInWater) {
				_audioSource.pitch = 1f;
			} else {
				_audioSource.pitch = 0.7f;
			}
			_audioSource.Play();
		}
	}
}