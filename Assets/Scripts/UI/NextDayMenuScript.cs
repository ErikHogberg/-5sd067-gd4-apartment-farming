using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDayMenuScript : MonoBehaviour {

	public Slider DaySlider;
	public Button EndDayButton;

	public Text DayText;

	public FadePanelScript FadePanel;

	public Text WaterText;

	void Start() {

		gameObject.SetActive(false);

	}

	void Update() {

	}

	public void UpdateUI() {
		// IDEA: show how many days until next harvest

		bool allPlantsWatered = CheckAllWatered();
		WaterText.gameObject.SetActive(!allPlantsWatered);
		EndDayButton.interactable = allPlantsWatered;


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
