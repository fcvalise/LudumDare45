using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnClick : MonoBehaviour {
	public GameObject _prefab;
	void Update() {
		if (Input.GetMouseButton(0)) {
			Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			position.z = 0;
			GameObject go = Instantiate(_prefab, position, Quaternion.identity);
		}
	}
}
