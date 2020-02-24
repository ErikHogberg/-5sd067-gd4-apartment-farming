﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePotMenuScript : MonoBehaviour {

	public Dropdown PotMenuDropdown;
	// public Button PlacePotButton;

	public static ChoosePotMenuScript MainInstance;

	private PotSpotScript currentPotSpot;

	public List<GameObject> PotPrefabs;

	void Start() {
		MainInstance = this;
		gameObject.SetActive(false);
	}

	void Update() {

	}

	public void OpenMenu(PotSpotScript potSpot) {
		gameObject.SetActive(true);

		currentPotSpot = potSpot;
		PopulateDropDown();

	}

	private void PopulateDropDown() {
		List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

		// TODO: choose pots from inventory instead
		// IDEA: disable dropdown if inventory is empty

		foreach (GameObject potPrefab in PotPrefabs) {
			options.Add(new Dropdown.OptionData(potPrefab.name));
		}


		PotMenuDropdown.interactable = options.Count > 0;
		PotMenuDropdown.options = options;

	}

	public static void OpenStaticMenu(PotSpotScript potSpot) {
		MainInstance.OpenMenu(potSpot);
	}

	public void CloseMenu() {
		gameObject.SetActive(false);
	}
	public static void CloseStaticMenu() {
		if (MainInstance != null) {
			MainInstance.CloseMenu();
		}
	}

	public void PlacePot() {
		CloseMenu();
		if (currentPotSpot == null) {
			return;
		}

		Instantiate(PotPrefabs[PotMenuDropdown.value],
			currentPotSpot.transform.position, // TODO: better/more consistent pos
			currentPotSpot.transform.rotation,
			currentPotSpot.transform.parent
		);

		Destroy(currentPotSpot.gameObject);



	}

}
