using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPrefabScript : MonoBehaviour {

	public float StartGrowthProgress = 0;
	public Plant PlantSettings;

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

		for (int i = 0; i < PlantSettings.GrowthStates.Count; i++) {

			PlantGrowthState state = PlantSettings.GrowthStates[i];

			state.Prefab.SetActive(false);

			if (state.GrowthValue > growthProgress) {
				continue;
			}

			if (state.GrowthValue > highestValidValue) {
				highestValidValue = state.GrowthValue;
				highestValidValueIndex = i;
			}

		}

		PlantSettings.GrowthStates[highestValidValueIndex].Prefab.SetActive(true);

	}


}
