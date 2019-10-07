using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager instance;
	public float _duration = 1f;
	public AudioClip[] _songList = null;

	private AudioSource _audioSource = null;
	private float _timer = 0f;

	private void Awake() {
		instance = this;
		_timer = float.MaxValue;
	}

	private void Start() {
		_audioSource = GetComponent<AudioSource>();
	}

	private void Update() {
		_timer += Time.deltaTime;
		_audioSource.volume -= Time.deltaTime;
	}

	public void PlaySongRandom() {
		if (_timer > _duration) {
			int index = (int)(Random.Range(0, _songList.Length));
			_audioSource.clip = _songList[index];
			_duration = _songList[index].length / 16f; // Export Mistake + play twice
			_timer = 0f;
			_audioSource.Play();
		}
		_audioSource.volume = 1f;
	}
}