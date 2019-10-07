using UnityEngine;

public class Level1EnemyTarget : MonoBehaviour {
    public float _maxDistanceFromSpawn = 15f;
    public float _speed = 1f;
    public float _amplitude = 3f;
    public EnemySearch _enemySearch = null;
    public Vector2 _constraint = Vector2.one;

    private float _timerDelay;
    private Vector3 _originPosition = Vector2.zero;
    private Vector3 _currentVelocity;

    private void Start() {
        _originPosition = transform.position;
        _speed += Random.value * 0.2f;
        _timerDelay = Random.value;
    }

    private void Update() {
        switch (_enemySearch._state) {
            case EnemySearch.State.Chill:
                float value = Mathf.Sin(Time.time * _speed) * _amplitude;
                transform.position = Vector3.SmoothDamp(transform.position, _originPosition + new Vector3(value * _constraint.x, value * _constraint.y, 0f), ref _currentVelocity, 0.3f);
                break;
            case EnemySearch.State.Alert:
            case EnemySearch.State.Curious:
                transform.position = Vector3.SmoothDamp(transform.position, _enemySearch._player.position, ref _currentVelocity, 0.3f);
                break;
        }
    }
}