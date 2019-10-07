using UnityEngine;

public class Player : MonoBehaviour {
	public static Transform PlayerTransform = null;
	public static int FoodLevel = 5;
	public static CharacterState CharacterState;

	private void Awake() {
		PlayerTransform = transform;
	}
}