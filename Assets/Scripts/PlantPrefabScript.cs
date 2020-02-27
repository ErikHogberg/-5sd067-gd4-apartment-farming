using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPrefabScript : MonoBehaviour {

	public float StartGrowthProgress = 0;
	public Plant PlantSettings;
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
		Debug.Log("growth: " + GrowthProgress + ", max: " + maxSize);
		return belowMax;
	}


}
