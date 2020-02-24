using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMenuScript : MonoBehaviour {

	public static PlantMenuScript MainInstance;

	private ClickPotScript currentPot;

	void Start() {
		MainInstance = this;
		gameObject.SetActive(false);

	}

	public void CloseMenu() {
		gameObject.SetActive(false);
	}

	public void PopulateDropdown() {
		// TODO: get seeds in inventory
	}

	public void InspectPot(ClickPotScript pot) {
		// TODO: show menu
		// TODO: populate menu
		currentPot = pot;
		gameObject.SetActive(true);

	}

	public void ClearPot() {
		// TODO: hide menu
		currentPot = null;
	}

	public void WaterPlant() {

	}


}
