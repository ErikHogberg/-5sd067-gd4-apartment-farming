using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMenuScript : MonoBehaviour {

	public static PlantMenuScript MainInstance;

	public Dropdown PlantMenuDropdown;
	public Text PlantAndWaterButtonText;
	public Button HarvestButton;

	public ClickPotScript currentPot;

	void Start() {
		MainInstance = this;
		gameObject.SetActive(false);

	}

	public void CloseMenu() {
		gameObject.SetActive(false);
		ClickPotScript.ClearObject();
	}

	public void PopulateUI() {

		List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

		if (currentPot.Plant != null) {
			PlantMenuDropdown.interactable = false;
			PlantAndWaterButtonText.text = "Plant";
		} else {
			foreach (Plant seed in Inventory.State.Seeds) {
				options.Add(new Dropdown.OptionData(seed.name));
			}

			PlantMenuDropdown.interactable = options.Count > 0;
			PlantAndWaterButtonText.text = "Water";
		}

		PlantMenuDropdown.options = options;
		
	}

	public void InspectPot(ClickPotScript pot) {
		// TODO: different actions for different plant states (empty, only soil, has plant)
		currentPot = pot;
		PopulateUI();
		gameObject.SetActive(true);

		// TODO: water button, disable if watered already?

	}

	public void ClearPot() {
		CloseMenu();
		currentPot = null;
	}

	public void PlantOrWater() {
		if (currentPot.Plant == null) {
			PlantPlant();
		} else {
			WaterPlant();
		}
		PopulateUI();

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

		currentPot.GetComponent<ClickPotScript>().Plant = newPlant.GetComponent<PlantPrefabScript>();
		Inventory.State.Seeds.RemoveAt(PlantMenuDropdown.value);

		// PopulateDropdown();
		// CloseMenu();
	}

	public void DebugTimestep(float timeAmount) {
		ClickPotScript.TimeStep(timeAmount);
	}


}
