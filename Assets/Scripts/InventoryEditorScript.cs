using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryEditorScript : MonoBehaviour {

	public bool GetGlobals = true;

	public InventoryState State;

	private void Start() {
		if (GetGlobals) {
			State = Inventory.State;
		} else {
			Inventory.State = State;
		}
	}

}


public static class Inventory {

	public static InventoryState State;



}

[Serializable]
public class InventoryState {

	public List<Pot> Pots = new List<Pot>();
	public List<Plant> Seeds = new List<Plant>();

	public InventoryState() {

	}

	public void Reset() {
		Pots = new List<Pot>();
		Seeds = new List<Plant>();
	}

}

[Serializable]
public struct Pot {
	[Tooltip("Name in menus")]
	public string name;
	[Tooltip("Pot model prefab")]
	public GameObject PotPrefab;
	[Tooltip("How much a plant can grow in this pot")]
	public int PotSize;
}

[Serializable]
public struct PlantGrowthState {
	[Tooltip("Growth amount needed to change to this model")]
	public float GrowthValue;
	[Tooltip("Model prefab to change to")]
	public GameObject Prefab;
}

[Serializable]
public struct Plant {
	[Tooltip("Name in menus")]
	public string name;
	[Tooltip("Seed bag to show when inspecting")]
	public GameObject SeedBagPrefab;
	[Tooltip("Text shown when inspecting")]
	public string Description;
	[Tooltip("All growth state with models for the plant when growing")]
	public List<PlantGrowthState> GrowthStates;
}

