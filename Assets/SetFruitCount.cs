using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetFruitCount : MonoBehaviour {
    public TextMeshPro _textMeshPro;

    private void Start() {
        Player.FoodLevel = 0;
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update() {
        _textMeshPro.text = (Mathf.Clamp(Player.FoodLevel, 0, 40)).ToString();
    }
}