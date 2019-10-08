using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    [SerializeField] public int MaxFood = 30;
    [SerializeField] public float IntervalFood = 0.3f;

    private void Awake() {
        instance = this;
    }
}