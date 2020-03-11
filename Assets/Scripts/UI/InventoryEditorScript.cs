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

	public float StartCash = 1000f;

	private float cash = 0f;
	public float Cash {
		get { return cash; }
		set {
			cash = value;
			CashCounterScript.SetValueStatic(cash);
		}
	}

	public List<GameObject> Pots = new List<GameObject>();
	public List<GameObject> Seeds = new List<GameObject>();

	public int DayLimit = 100;
	
	private int daysPassed = 0;
	public int DaysPassed {
		get { return daysPassed; }
		set {
			daysPassed = value;
			DayCounterUIScript.SetValueStatic(daysPassed, DayLimit);
		}
	}

	public InventoryState() {
		Cash = StartCash;
		DayCounterUIScript.SetValueStatic(DaysPassed, DayLimit);
		// Debug.Log("Called inventory init! " + StartCash );
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

