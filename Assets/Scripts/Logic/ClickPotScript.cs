using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPotScript : MonoBehaviour {

	public static List<ClickPotScript> Pots = new List<ClickPotScript>();
	// public static List<GameObject> Pots = new List<GameObject>();

	public GameObject PrefabToInstantiate;
	public GameObject PlantSpawnLocation;

	private static GameObject spawnedObject = null;

	public float SoilAmount = 0;
	public float Size = 0; // max soil amount
	public PlantPrefabScript Plant = null;

	// public float GrowthProgress; // less than 0 means no soil
	public bool HasBeenWatered = false;



	void Start() {
		Pots.Add(this);
		// Pots.Add(gameObject);
		Debug.Log("pot init size: " + Size + ", soil: " + SoilAmount);

	}

	private void OnDestroy() {
		Pots.Remove(this);
		// Pots.Remove(gameObject);
	}

	void Update() {

	}

	private void OnMouseDown() {
		Debug.Log("clicked pot");

		Vector3 spawnLocation = Camera.main.transform.position;

		if (spawnedObject == null) {
			spawnedObject = Instantiate(PrefabToInstantiate, spawnLocation, Camera.main.transform.rotation);
			Debug.Log("clicked pot size: " + Size + ", soil: " + SoilAmount);
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

	public static void TimeStep() {
		// TimeStep(5);
		foreach (ClickPotScript pot in Pots) {
			// foreach (GameObject potObject in Pots) {
			// ClickPotScript pot = potObject.GetComponent<ClickPotScript>();
			if (pot.Plant != null) {
				pot.Plant.IncreaseGrowthProgress(5, pot.SoilAmount);
			}
		}
	}

	public static void TimeStep(float time) {

		foreach (ClickPotScript pot in Pots) {
			// foreach (GameObject potObject in Pots) {
			// ClickPotScript pot = potObject.GetComponent<ClickPotScript>();
			if (pot.Plant != null) {
				pot.Plant.IncreaseGrowthProgress(time, pot.SoilAmount);
			}
		}
	}

	public void TimeStepInstantiated(float time = 5) {
		TimeStep(time);
	}

}
