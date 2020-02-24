using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPotScript : MonoBehaviour {

	public static List<ClickPotScript> Pots = new List<ClickPotScript>();

	public GameObject PrefabToInstantiate;

	private static GameObject spawnedObject = null;


	void Start() {
		Pots.Add(this);
	}

	private void OnDestroy() {
		Pots.Remove(this);
	}

	void Update() {

	}

	private void OnMouseDown() {
		Debug.Log("clicked pot");

		Vector3 spawnLocation = Camera.main.transform.position;

		// IDEA: remove old object instead, only if different?
		// IDEA: spawn as child of camera so it follows when changing rooms? better if it stays?
		// TODO: remove object when changing camera spot
		if (spawnedObject == null) {
			spawnedObject = Instantiate(PrefabToInstantiate, spawnLocation, Camera.main.transform.rotation);
			PlantMenuScript.MainInstance.InspectPot(this);
		}
	}

	public static void ClearObject() {
		if (spawnedObject != null) {
			Destroy(spawnedObject);
			spawnedObject = null;
		}
		// PlantMenuScript.MainInstance.ClearPot();
	}

}
