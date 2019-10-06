using UnityEngine;

public class Player : MonoBehaviour {
	public static Transform PlayerTransform = null;

	private void Awake() {
		PlayerTransform = transform;
	}
}