using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour {
    public static float _timer;

    public enum State {
        Tree,
        Player,
        Enemy,
        Destroyed
    }

    public static List<Eatable> _playerEatable = new List<Eatable>();
    public LayerMask _playerLayerMask;
    public LayerMask _enemyLayerMask;
    public LayerMask _waterLayerMask;
    public float _smoothTime = 0.3f;
    public AnimationCurve _animationCurve;
    public float _minScale = 0.3f;
    public float _maxScale = 1.5f;

    private State _state = State.Tree;
    private Vector3 _currentVelocity;
    private Transform _target = null;
    private CircleCollider2D _collider = null;
    public bool _isInWater = false;
    private AudioSource _audioSource = null;
    public AudioClip _eatAudioClip = null;
    public List<AudioClip> _destroyAudioClip = null;

    private void Start() {
        _collider = GetComponent<CircleCollider2D>();
        _smoothTime = Random.Range(_smoothTime * 0.6f, _smoothTime * 1.4f);
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(Appear());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (((1 << other.gameObject.layer) & _playerLayerMask) != 0) {
            if (_state == State.Tree && _playerEatable.Count < GameManager.instance.MaxFood) {
                _audioSource.clip = _eatAudioClip;
                _audioSource.Play();
                transform.parent = null;
                _playerEatable.Add(this);
                _state = State.Player;
                _target = other.transform;
                _collider.radius = 0.4f;
            }
        }
        if (((1 << other.gameObject.layer) & _waterLayerMask) != 0) {
            _isInWater = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (!_isInWater && _state == State.Player && ((1 << other.gameObject.layer) & _enemyLayerMask) != 0) {
            if (_state == State.Player && _timer < 0f) {
                _audioSource.clip = _destroyAudioClip[(int) Random.Range(0, _destroyAudioClip.Count)];
                _audioSource.pitch = Random.Range(0.7f, 1f);
                _audioSource.Play();
                _timer = GameManager.instance.IntervalFood;
                _state = State.Enemy;
                _target = other.transform;
                _smoothTime = 0.3f;
                _playerEatable.Remove(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (((1 << other.gameObject.layer) & _waterLayerMask) != 0) {
            _isInWater = false;
        }
    }

    private void Update() {
        for (int i = 0; i < _playerEatable.Count; i++) {
            _playerEatable[i]._smoothTime = Mathf.Lerp(0.05f, 0.99f, _animationCurve.Evaluate((float) i / (float) GameManager.instance.MaxFood));
            _playerEatable[i].transform.localScale = Mathf.Max(_minScale, _playerEatable[i]._smoothTime * _maxScale) * Vector3.one;
        }

        switch (_state) {
            case State.Tree:
                break;
            case State.Player:
                transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _currentVelocity, _smoothTime);
                break;
            case State.Enemy:
                transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _currentVelocity, _smoothTime);
                if (Vector3.Distance(transform.position, _target.position) < 0.3f) {
                    StartCoroutine(Disappear());
                    _state = State.Destroyed;
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator Appear() {
        Vector3 scale = transform.localScale;
        float timer = 0f;
        float duration = 2f;

        transform.localScale = Vector3.zero;
        while (timer <= duration) {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, scale, timer / duration);
            yield return null;
        }
        yield return null;
    }

    private IEnumerator Disappear() {
        Vector3 scale = transform.localScale;
        float timer = 0f;
        float duration = 1f;

        transform.localScale = Vector3.zero;
        while (timer <= duration) {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(scale, Vector3.zero, timer / duration);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }
}