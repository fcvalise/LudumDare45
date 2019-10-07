using UnityEngine;
using System.Collections;

public class Eatable : MonoBehaviour {
	public LayerMask _enemyLayerMask;
	public float _distance = 1f;
	public float _smoothTime = 0.3f;
	private Vector3 _currentVelocity;
	private bool _destroyed = false;

	private void Start() {
		_smoothTime = Random.Range(_smoothTime * 0.6f, _smoothTime * 1.4f);
		_distance = Random.Range(_distance * 0.6f, _distance * 1.4f);
		StartCoroutine(Appear());
	}

	private void Update() {
		if (_destroyed) {
			return;
		}
		// If not attached to a tree, can be eat by enemy
		Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.1f, _enemyLayerMask);
		if (collider != null && transform.parent == null) {
			transform.position = Vector3.SmoothDamp(transform.position, collider.transform.position, ref _currentVelocity, _smoothTime);
			if (Vector3.Distance(collider.transform.position, transform.position) < _distance * 0.5f) {
				StartCoroutine(Disappear());
				_destroyed = true;
			}
			return;
		}

		Vector3 position = Player.PlayerTransform.position;
		if (Vector3.Distance(position, transform.position) < _distance) {
			_smoothTime += Time.deltaTime * 0.05f;
			_distance += Time.deltaTime * 0.05f;
			transform.position = Vector3.SmoothDamp(transform.position, position, ref _currentVelocity, _smoothTime);
		}

		if (Vector3.Distance(position, transform.position) < _distance * 0.5f) {
			Player.FoodLevel++;
			transform.parent = null;
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
