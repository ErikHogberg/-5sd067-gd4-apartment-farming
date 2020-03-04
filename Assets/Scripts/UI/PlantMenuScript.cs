using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMenuScript : MonoBehaviour {

	public static PlantMenuScript MainInstance;

	public Dropdown PlantMenuDropdown;
	// public Button PlantButton;

	public ClickPotScript currentPot;

	void Start() {
		MainInstance = this;
		gameObject.SetActive(false);

	}

	public void CloseMenu() {
		gameObject.SetActive(false);
	}

	public void PopulateDropdown() {
		// TODO: get seeds in inventory

		List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();


		foreach (Plant seed in Inventory.State.Seeds) {
			options.Add(new Dropdown.OptionData(seed.name));
		}

		PlantMenuDropdown.interactable = options.Count > 0;
		PlantMenuDropdown.options = options;
	}

	public void InspectPot(ClickPotScript pot) {
		// TODO: populate menu
		// TODO: different actions for different plant states (empty, only soil, has plant)
		currentPot = pot;
		PopulateDropdown();
		gameObject.SetActive(true);

		// TODO: water button, disable if watered already?

	}

	public void ClearPot() {
		CloseMenu();
		currentPot = null;
	}

	public void WaterPlant() {
		currentPot.HasBeenWatered = true;

	}

	public void PlantPlant() {
		GameObject plantPrefab = Inventory.State.Seeds[PlantMenuDropdown.value].PlantPrefab;
		GameObject newPlant = Instantiate(
			plantPrefab,
			// currentPot.PlantSpawnLocation.transform.position,
			currentPot.transform.position,
			currentPot.transform.rotation,
			currentPot.transform
		);

		currentPot.Plant = newPlant.GetComponent<PlantPrefabScript>();
		Inventory.State.Seeds.RemoveAt(PlantMenuDropdown.value);
	}


}
