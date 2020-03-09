using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextDayMenuScript : MonoBehaviour {

	public Slider DaySlider;
	public Button EndDayButton;

	public Text DayText;

	public FadePanelScript FadePanel;

	public Text WaterText;
	public Button NextEventButton;
	public Text NextEventDayText;

	public Scene nextScene; // IDEA: stay in same scene instead, make new ui state for end screen?

	void Start() {

		gameObject.SetActive(false);

	}

	void Update() {

	}

	public void UpdateUI() {

		(bool anyPlantsHarvestableInFuture, float daysUntilClosestHarvest) = GetDaysToNextEvent();
		if (anyPlantsHarvestableInFuture) {
			NextEventDayText.text = daysUntilClosestHarvest.ToString();
		} else {
			NextEventDayText.text = "No events";
		}
		NextEventButton.interactable = anyPlantsHarvestableInFuture;


		bool allPlantsWatered = CheckAllWatered();
		WaterText.gameObject.SetActive(!allPlantsWatered);
		EndDayButton.interactable = allPlantsWatered;

	}

	private (bool, float) GetDaysToNextEvent() {

		bool anyPlants = false;
		float closestEvent = float.MaxValue;

		foreach (ClickPotScript pot in ClickPotScript.Pots) {
			if (pot.Plant != null && pot.Plant.HarvastableAtSize < pot.SoilAmount) {
				float daysUntilHarvest = pot.Plant.HarvastableAtSize - pot.Plant.GrowthProgress;
				if (daysUntilHarvest > 0 && daysUntilHarvest < closestEvent) {
					closestEvent = daysUntilHarvest;
					anyPlants = true;
				}
			}
		}

		return (anyPlants, closestEvent);
	}

	public void SetSliderToNextEvent() {
		(bool anyPlantsHarvestableInFuture, float daysUntilClosestHarvest) = GetDaysToNextEvent();
		if (anyPlantsHarvestableInFuture) {
			DaySlider.value = daysUntilClosestHarvest;
		}
	}

	private bool CheckAllWatered() {

		if (ClickPotScript.Pots.Any(pot => pot.Plant != null && !pot.HasBeenWatered)) {
			return false;
		}

		return true;
	}

	public void NextDay() {
		// TODO: get slider value
		// TODO: fade out
		// TODO: increase time
	}

	public void SetSliderToRecommended() {
		// DaySlider.value
	}

	public void CloseMenu() {
		gameObject.SetActive(false);
	}

	public void ToggleMenu() {
		gameObject.SetActive(!gameObject.activeSelf);
		if (gameObject.activeSelf) {
			UpdateUI();
		}
	}

	public void SetDayText(Single value) {
		DayText.text = value.ToString();
	}

	public void StartDayChange() {
		foreach (ClickPotScript pot in ClickPotScript.Pots) {
			pot.HasBeenWatered = false;
		}
		FadePanel.StartFadeOut();
	}

	public void ApplyDayChange() {
		ClickPotScript.TimeStep(DaySlider.value);
	}

}
