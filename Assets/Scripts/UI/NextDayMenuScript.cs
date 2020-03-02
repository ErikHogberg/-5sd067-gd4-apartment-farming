using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDayMenuScript : MonoBehaviour {

	public Button EndDayButton;

	void Start() {

	}

	void Update() {

	}

	public void UpdateUI(){
		// TODO: check if all plants are watered
		// TODO: disable end day button if not all plants are watered
		// TODO: show text feedback telling you to water all plants
		// IDEA: show how many days until next harvest
	}

	public void NextDay(){
		// TODO: get slider value
		// TODO: fade out
		// TODO: increase time
	}

	public void ToggleMenu() {
		gameObject.SetActive(!gameObject.activeSelf);
	}

}
