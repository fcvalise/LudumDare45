using UnityEngine;

public class MouseFollow : MonoBehaviour {
	private void Update() {
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}