﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleButton : MonoBehaviour {

	[SerializeField] private GameObject _placeholder;
	[SerializeField] private Material _moduleMaterial;
	public bool isModule = false;

	public void Activated() {
		_placeholder.GetComponent<MeshRenderer> ().material = _moduleMaterial;
		//isModule = true;
		Debug.Log(_placeholder.name + " is now a module.");
	}
}
