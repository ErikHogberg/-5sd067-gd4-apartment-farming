using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuScript : MonoBehaviour {

	public static InventoryMenuScript MainInstance;

	public Text TextBox;

	void Start() {
		MainInstance = this;
		gameObject.SetActive(false);
	}

	public void OpenMenu() {
		PopulateMenu();
		PlantMenuScript.MainInstance.CloseMenu();
		ChoosePotMenuScript.MainInstance.CloseMenu();
		gameObject.SetActive(true);
	}

	public void PopulateMenu() {

		string outText = "";

		outText += "Pots";
		foreach (GameObject item in Inventory.State.Pots) {
			outText += Environment.NewLine + item.GetComponent<ClickPotScript>().MenuName;
		}

		outText += Environment.NewLine + Environment.NewLine + "Seeds";
		foreach (GameObject item in Inventory.State.Seeds) {
			outText += Environment.NewLine
				+ item.GetComponent<PlantPrefabScript>().MenuName
				// + " (" + item.GetComponent<PlantPrefabScript>().Description + ")"
			;
		}

		TextBox.text = outText;

	}

	public void CloseMenu() {
		gameObject.SetActive(false);
	}

	public void ToggleMenu() {
		// gameObject.SetActive(!gameObject.activeSelf);
		if (gameObject.activeSelf) {
			CloseMenu();
		} else {
			OpenMenu();
		}
	}

}
