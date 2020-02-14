using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPotScript : MonoBehaviour {

	public GameObject PrefabToInstantiate;

	private static GameObject spawnedObject = null;

	void Start() {

	}

	void Update() {

	}

	private void OnMouseDown() {
		Debug.Log("clicked pot");

		Vector3 spawnLocation = Camera.main.transform.position;

		// IDEA: remove old object instead, only if different?
		if (spawnedObject == null) {
			spawnedObject = Instantiate(PrefabToInstantiate, spawnLocation, Camera.main.transform.rotation);
		}
	}

}
