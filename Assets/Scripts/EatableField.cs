﻿using System.Collections.Generic;
using UnityEngine;

public class EatableField : MonoBehaviour {
	public GameObject _prefabTree = null;
	public GameObject _prefabFruit = null;
	public int _countTree = 5;
	public int _countFruit = 5;
	public float _duration = 4f;
	public float _radiusTree = 4f;
	public float _radiusFruit = 1f;

	private float _timer = 0f;
	private List<Transform> _treeList = new List<Transform>();

	private void Start() {
		for (int i = 0; i < _countTree; i++) {
			Vector3 position = transform.position + (Vector3) Random.insideUnitCircle * _radiusTree;
			GameObject tree = Instantiate(_prefabTree, position, Quaternion.identity);
			_treeList.Add(tree.transform);
		}
		foreach (Transform tree in _treeList) {
			for (int i = 0; i < _countFruit; i++) {
				Vector3 position = tree.position + (Vector3) Random.insideUnitCircle * _radiusFruit;
				Instantiate(_prefabFruit, position, Quaternion.identity, tree);
			}
		}
	}

	private void Update() {

		if (_timer > _duration) {
			foreach (Transform tree in _treeList) {
				if (tree.childCount == 0) {
					_timer += Time.deltaTime;
					for (int i = 0; i < _countFruit; i++) {
						Vector3 position = tree.position + (Vector3) Random.insideUnitCircle * _radiusFruit;
						Instantiate(_prefabFruit, position, Quaternion.identity, tree);
					}
					break;
				}
			}
			_timer = 0f;
		}
	}
}