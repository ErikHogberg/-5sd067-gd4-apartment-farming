using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPrefabScript : MonoBehaviour {

	public float StartGrowthProgress = 0;

	[Tooltip("How much the plant must have grown to be able to be harvested")]
	public float HarvastableAtSize;

	[Tooltip("How much growth the plant loses when harvested")]
	public float SizeReductionOnHarvest;
	[Tooltip("If plant is consumed/destroyed on harvest")]
	public bool ConsumeOnHarvest = false;

	[Tooltip("Value of each harvest yield (1 fruit)")]
	public float HarvestValue;

	// public Plant PlantSettings;
	[Tooltip("Price to buy in store")]
	public float Price;
	[Tooltip("Name in menus")]
	public string MenuName;
	[Tooltip("Seed bag to show when inspecting")]
	public GameObject SeedBagPrefab;
	[Tooltip("Text shown when inspecting")]
	public string Description;

	[Tooltip("All growth state with models for the plant when growing")]
	public List<PlantGrowthState> GrowthStates;


	private float growthProgress;
	public float GrowthProgress {
		get {
			return growthProgress;
		}
		set {
			growthProgress = value;
			UpdateGrowthProgress();
		}
	}

	private void Start() {
		GrowthProgress = StartGrowthProgress;
	}

	private void Update() {

	}

	private void UpdateGrowthProgress() {

		float highestValidValue = 0;
		int highestValidValueIndex = 0;

		for (int i = 0; i < GrowthStates.Count; i++) {

			PlantGrowthState state = GrowthStates[i];

			state.Prefab.SetActive(false);

			if (state.GrowthValue > growthProgress) {
				continue;
			}

			if (state.GrowthValue > highestValidValue) {
				highestValidValue = state.GrowthValue;
				highestValidValueIndex = i;
			}

		}

		GrowthStates[highestValidValueIndex].Prefab.SetActive(true);

	}

	public bool IncreaseGrowthProgress(float amount, float maxSize) {
		bool belowMax = true;
		float resultSize = growthProgress + amount;
		if (resultSize > maxSize) {
			resultSize = maxSize;
			belowMax = false;
		}
		GrowthProgress = resultSize;
		// Debug.Log("growth: " + GrowthProgress + ", max: " + maxSize);
		return belowMax;
	}

	public bool CheckIfHarvestable() {
		return GrowthProgress > HarvastableAtSize;
	}

	public void Harvest() {
		if (CheckIfHarvestable()) {
			// TODO: ability to either harvest multiple times or get multiple fruit when harvesting
			GrowthProgress -= SizeReductionOnHarvest;
			// TODO: add harvest value to money saved
		}
	}


}
