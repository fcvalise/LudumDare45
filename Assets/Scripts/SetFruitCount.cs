using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetFruitCount : MonoBehaviour {
    public TextMeshPro _textMeshPro;

    private void Start() {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update() {
        _textMeshPro.text = (Mathf.Clamp(Eatable._playerEatable.Count, 0, GameManager.instance.MaxFood)).ToString();
    }
}