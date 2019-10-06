using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMovement : MonoBehaviour {
	void Start() {

	}

	void Update() {
		Vector3 position = (transform.parent.position - Camera.main.transform.position).normalized * 0.5f;
		position.z = -0.1f;
		transform.localPosition = position;
	}
}
