using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuScript : MonoBehaviour {

	public static InventoryMenuScript MainInstance;

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
	}

	public void CloseMenu() {
		gameObject.SetActive(false);
	}

	public void ToggleMenu() {
		gameObject.SetActive(!gameObject.activeSelf);
	}

}
