using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterial : MonoBehaviour {
	public Material _material; 
	public List<Renderer> _rendererList = new List<Renderer>();

	void Start() {
		foreach (Renderer rd in _rendererList)
		{
			rd.sharedMaterial = _material;
		}
	}
}
