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
		gameObject.SetActive(true);
	}

	public void PopulateMenu() {
		// TODO: get soil instead if pot is not filled
		// TODO: get seeds from inventory if there is soil
		// TODO: water plant if plant exists
		// TODO: harvest plant if ready to harverst

		string outText = "";

		outText += "Pots";
		foreach (Pot item in Inventory.State.Pots) {
			outText += Environment.NewLine + item.name;
		}

		outText += Environment.NewLine + Environment.NewLine + "Seeds";
		foreach (Plant item in Inventory.State.Seeds) {
			outText += Environment.NewLine + item.name + " (" + item.Description + ")";
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
