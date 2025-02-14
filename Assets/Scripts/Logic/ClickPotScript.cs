﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPotScript : MonoBehaviour {

	public static List<ClickPotScript> Pots = new List<ClickPotScript>();
	// public static List<GameObject> Pots = new List<GameObject>();

	// public GameObject PrefabToInstantiate;
	public GameObject PlantSpawnLocation;
	public GameObject SoilModel;

	[Tooltip("Name in menus")]
	public string MenuName;
	[Tooltip("Text shown when inspecting")]
	public string Description;
	// public float GrowthProgress; // less than 0 means no soil
	[Tooltip("How much a plant can grow in this pot (how much soil fits in it)")]
	public float Size = 0; // max soil amount
	[Tooltip("How much the pot costs to buy")]
	public float Price = 1; // max soil amount
	[Tooltip("Sound effect when placing pot")]
	public string PlacePotSoundEffect;

	// public float StartSoilAmount = 0;
	private float soilAmount;
	public float SoilAmount {
		get { return soilAmount; }
		set {
			soilAmount = value;
			if (SoilModel != null) {
				if (soilAmount > 0) {
					SoilModel.SetActive(true);
				} else {
					SoilModel.SetActive(false);
				}
			}
		}
	}

	public PlantPrefabScript Plant = null;
	public bool HasBeenWatered = false;
	public GameObject PotSpot;
	// public Prefab OriginalPrefab;


	void Start() {
		Pots.Add(this);
		SoilAmount = Size;
	}

	private void OnDestroy() {
		Pots.Remove(this);
	}

	private void OnMouseDown() {
		if (!PlantMenuScript.MainInstance.gameObject.activeSelf) {
			PlantMenuScript.MainInstance.InspectPot(this);
		}
	}

	public void RemovePlant() {
		if (Plant == null)
		{
			return;
		}

		Destroy(Plant.gameObject);
		Plant = null;
	}

	public static void TimeStep() {
		TimeStep(5);
	}

	public static void TimeStep(float time) {

		foreach (ClickPotScript pot in Pots) {
			if (pot.Plant != null) {
				pot.Plant.IncreaseGrowthProgress(time, pot.SoilAmount);
			}
		}
		
	}

	public void TimeStepInstantiated(float time = 5) {
		TimeStep(time);
	}

}
