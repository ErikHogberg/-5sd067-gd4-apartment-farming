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
			// Inventory.DaysPassed = 0;
		}
	}

}


public static class Inventory {

	public static InventoryState State;

}

[Serializable]
public class InventoryState {

	public float StartCash = 1000000f;

	private float cash = 1000000f;
	public float Cash {
		get { return cash; }
		set {
			cash = value;
			CashCounterScript.SetValueStatic(cash);
		}
	}
	
	public List<GameObject> Pots = new List<GameObject>();
	public List<GameObject> Seeds = new List<GameObject>();

	public int DaysPassed = 0;
	public int DayLimit = 100;

	public InventoryState() {
		Cash = StartCash;
	}

	public void Reset() {
		Pots = new List<GameObject>();
		Seeds = new List<GameObject>();
	}

}

// [Serializable]
// public struct Pot {
// 	[Tooltip("Name in menus")]
// 	public string name;
// 	[Tooltip("Pot model prefab")]
// 	public GameObject PotPrefab;
// 	[Tooltip("How much a plant can grow in this pot")]
// 	public int PotSize;
// }

[Serializable]
public struct PlantGrowthState {
	[Tooltip("Growth amount needed to change to this model")]
	public float GrowthValue;
	[Tooltip("Model prefab to change to")]
	public GameObject Prefab;
}

/*
[Serializable]
public struct Plant {
	[Tooltip("Name in menus")]
	public string name;
	[Tooltip("Seed bag to show when inspecting")]
	public GameObject SeedBagPrefab;
	[Tooltip("Plant to spawn")]
	public GameObject PlantPrefab;
	[Tooltip("Text shown when inspecting")]
	public string Description;

}
*/

