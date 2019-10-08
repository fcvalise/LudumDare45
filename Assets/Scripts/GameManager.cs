using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    [SerializeField] public int MaxFood = 30;
    [SerializeField] public float IntervalFood = 0.3f;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            IntervalFood = 0.22f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            IntervalFood = 0.3f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            IntervalFood = 0.35f;
        }
    }
}