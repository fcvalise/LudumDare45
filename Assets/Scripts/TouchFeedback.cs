using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFeedback : MonoBehaviour {
    public Transform _begin;
    public Transform _end;
    public int _count = 7;
    public float _maxScale = 3f;
    public float _minScale = 0.3f;
    public GameObject _prefab;
    public float _timer = 0f;

    private List<Transform> _touchList = new List<Transform>();

    private void Start() {
        for (int i = 0; i < _count; i++) {
            GameObject go = Instantiate(_prefab, -Vector3.up, Quaternion.identity);
            go.transform.localScale = Vector3.one * Mathf.Max(_minScale, (float) i / (float) _count * _maxScale);
            // go.transform.parent = transform;
            _touchList.Add(go.transform);
        }
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            _timer = Mathf.Min(_timer + Time.deltaTime, 1f);
        } else {
            _timer = Mathf.Max(_timer - Time.deltaTime, 0f);
        }
        for (int i = 0; i < _count; i++) {
            if (Input.GetMouseButton(0)) {
                _touchList[i].position = Vector2.Lerp(_end.position, _begin.position, (float) i / (float) _count);
            }
            _touchList[i].localScale = Vector3.one * Mathf.Max(_minScale, (float) i / (float) _count * _maxScale) * _timer;
        }
    }
}