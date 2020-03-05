using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlantMenuScript : MonoBehaviour {

	public static PlantMenuScript MainInstance;

	public Dropdown PlantMenuDropdown;
	public Button PlantAndWaterButton;
	public Text PlantAndWaterButtonText;
	public Button AddSoilButton;
	public Button HarvestButton;

	public FadePanelScript InspectFadePanel;

	public ClickPotScript currentPot;


	public UnityEvent OnOpenMenuAction;

	private static GameObject spawnedObject = null;


	void Start() {
		MainInstance = this;
		gameObject.SetActive(false);
	}

	public void CloseMenu() {
		if (!gameObject.activeSelf) {
			return;
		}

		if (InspectFadePanel != null) {
			InspectFadePanel.StartFadeIn();
		}
		gameObject.SetActive(false);
		ClearPot();
	}

	public void PopulateUI() {

		List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

		if (currentPot.Plant != null) {
			PlantAndWaterButton.interactable = !currentPot.HasBeenWatered;
			PlantAndWaterButtonText.text = "Water";
			PlantMenuDropdown.interactable = false;

			HarvestButton.interactable = currentPot.Plant.GrowthProgress > currentPot.Plant.HarvastableAtSize;

		} else {
			PlantAndWaterButtonText.text = "Plant";
			HarvestButton.interactable = false;

			foreach (Plant seed in Inventory.State.Seeds) {
				options.Add(new Dropdown.OptionData(seed.name));
			}
			bool outOfSeeds = options.Count < 1;

			PlantMenuDropdown.interactable = !outOfSeeds;
			PlantAndWaterButton.interactable = !outOfSeeds;

		}

		PlantMenuDropdown.options = options;

		if (currentPot.SoilAmount >= currentPot.Size) {
			AddSoilButton.interactable = false;
		} else {
			AddSoilButton.interactable = true;
		}

	}

	public static void ClearObject() {
		if (spawnedObject != null) {
			Destroy(spawnedObject);
			spawnedObject = null;
		}
		// PlantMenuScript.MainInstance.ClearPot();
	}

	public void InspectPot(ClickPotScript pot) {


		if (InspectFadePanel != null) {
			InspectFadePanel.StartFadeOut();
		}

		// TODO: different actions for different plant states (empty, only soil, has plant)
		currentPot = pot;
		PopulateUI();
		SetObject(currentPot);
		gameObject.SetActive(true);
		OnOpenMenuAction.Invoke();

		// TODO: water button, disable if watered already?

	}

	public void UpdateObject(ClickPotScript pot) {
		ClearObject();
		SetObject(pot);
	}

	public void UpdateObject() {
		UpdateObject(currentPot);
	}

	public void SetObject(ClickPotScript pot) {
		Vector3 spawnLocation = Camera.main.transform.position;

		if (spawnedObject == null) {
			GameObject prefabToInstantiate;//pot.PrefabToInstantiate;
			if (pot.Plant != null) {
				prefabToInstantiate = pot.Plant.PlantSettings.SeedBagPrefab;
			} else {
				prefabToInstantiate = Inventory.State.Seeds[PlantMenuDropdown.value].SeedBagPrefab;
			}

			spawnedObject = Instantiate(prefabToInstantiate, spawnLocation, Camera.main.transform.rotation);
			// Debug.Log("clicked pot size: " + Size + ", soil: " + SoilAmount);
		}
	}

	public void SetObject() {
		SetObject(currentPot);
	}

	public void ClearPot() {
		ClearObject();
		// CloseMenu();
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
		PlantMenuDropdown.value = 0;

		// PopulateDropdown();
		// CloseMenu();
	}

	public void DebugTimestep(float timeAmount) {
		ClickPotScript.TimeStep(timeAmount);
	}

	public void AddSoil(float SoilAmount) {
		currentPot.SoilAmount += SoilAmount;
		if (currentPot.SoilAmount > currentPot.Size) {
			currentPot.SoilAmount = currentPot.Size;
		}
	}


}
