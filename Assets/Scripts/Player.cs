using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public static CharacterState CharacterState;
    public LayerMask _enemyLayerMask;
    public ParticleSystem _particleDeath;
    public AudioClip _deathClip;
    private AudioSource _audioSource;
    private bool _soundPlayed = false;

    private void Awake() {
        _particleDeath.transform.position = transform.position;
        _audioSource = GetComponent<AudioSource>();
        Eatable._playerEatable.Clear();
    }

    private void Update() {
        Eatable._timer -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (((1 << other.gameObject.layer) & _enemyLayerMask) != 0) {
            if (Eatable._playerEatable.Count <= 0 && !_soundPlayed) {
                StartCoroutine(Restart());
                gameObject.GetComponent<Movement>().enabled = false;
                _particleDeath.Play();
                _particleDeath.transform.position = transform.position;
                _audioSource.clip = _deathClip;
                _audioSource.Play();
                _soundPlayed = true;
            }
        }
    }

    private IEnumerator Restart() {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Game");
    }
}