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
	public Text RemovePlantButtonText;

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

	public void UpdateUI() {

		List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

		if (currentPot.Plant != null) {
			PlantAndWaterButton.interactable = !currentPot.HasBeenWatered;
			PlantAndWaterButtonText.text = "Water";
			PlantMenuDropdown.interactable = false;

			HarvestButton.interactable = currentPot.Plant.GrowthProgress > currentPot.Plant.HarvastableAtSize;

		} else {
			PlantAndWaterButtonText.text = "Plant";
			HarvestButton.interactable = false;

			foreach (GameObject seed in Inventory.State.Seeds) {
				options.Add(new Dropdown.OptionData(seed.GetComponent<PlantPrefabScript>().MenuName));
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

		HarvestButton.interactable = IsHarvestable();

		if (currentPot.Plant != null) {
			RemovePlantButtonText.text = "Remove Plant";
		} else {
			RemovePlantButtonText.text = "Remove Pot";
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

		ChoosePotMenuScript.CloseStaticMenu();

		if (InspectFadePanel != null) {
			InspectFadePanel.StartFadeOut();
		}

		currentPot = pot;
		SetObject(currentPot);
		gameObject.SetActive(true);
		ChoosePotMenuScript.MainInstance.CloseMenu();
		InventoryMenuScript.MainInstance.CloseMenu();
		OnOpenMenuAction.Invoke();
		UpdateUI();

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
				prefabToInstantiate = pot.Plant.SeedBagPrefab;
			} else if (Inventory.State.Seeds.Count - 1 > PlantMenuDropdown.value) {
				PlantPrefabScript menuPlant = Inventory.State.Seeds[PlantMenuDropdown.value].GetComponent<PlantPrefabScript>();
				prefabToInstantiate = menuPlant.SeedBagPrefab;
			} else {
				return;
			}

			spawnedObject = Instantiate(
				prefabToInstantiate, 
				spawnLocation, 
				Camera.main.transform.rotation,
				Camera.main.transform
			);
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
		// UpdateUI();

	}

	public void WaterPlant() {
		currentPot.HasBeenWatered = true;
		UpdateUI();
		WaterParticleScript.MainInstance.StartSpray();
	}

	public void PlantPlant() {
		GameObject plantPrefab = Inventory.State.Seeds[PlantMenuDropdown.value];
		GameObject newPlant = Instantiate(
			plantPrefab,
			currentPot.PlantSpawnLocation.transform.position,
			// currentPot.transform.position,
			currentPot.transform.rotation,
			currentPot.transform
		);

		currentPot.GetComponent<ClickPotScript>().Plant = newPlant.GetComponent<PlantPrefabScript>();
		Inventory.State.Seeds.RemoveAt(PlantMenuDropdown.value);
		PlantMenuDropdown.value = 0;

		UpdateUI();
		// PopulateDropdown();
		// CloseMenu();
	}

	public void Harvest() {
		if (IsHarvestable()) {
			if (currentPot.Plant.ConsumeOnHarvest) {
				RemovePlant();
			} else {
				currentPot.Plant.GrowthProgress -= currentPot.Plant.HarvastableAtSize;
			}
			Inventory.State.Cash += currentPot.Plant.HarvestValue;
		}
		UpdateUI();
	}

	public bool IsHarvestable() {
		return
			currentPot.Plant != null
			&& currentPot.Plant.GrowthProgress >= currentPot.Plant.HarvastableAtSize
		;

	}

	public void RemovePlant() {
		if (currentPot.Plant != null) {
			currentPot.RemovePlant();
			ClearObject();
			UpdateUI();
		} else {
			// TODO: remove pot, close this menu
		}
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
