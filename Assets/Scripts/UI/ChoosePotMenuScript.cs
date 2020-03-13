using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePotMenuScript : MonoBehaviour {

	public Dropdown PotMenuDropdown;

	public static ChoosePotMenuScript MainInstance;

	private PotSpotScript currentPotSpot;


	void Start() {
		MainInstance = this;
		gameObject.SetActive(false);
	}

	public void OpenMenu(PotSpotScript potSpot) {
		gameObject.SetActive(true);

		PlantMenuScript.MainInstance.CloseMenu();
		InventoryMenuScript.MainInstance.CloseMenu();

		currentPotSpot = potSpot;
		PopulateDropDown();

	}

	private void PopulateDropDown() {
		List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

		foreach (GameObject pot in Inventory.State.Pots) {
			options.Add(new Dropdown.OptionData(pot.GetComponent<ClickPotScript>().MenuName));
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

		if (Inventory.State.Pots.Count < PotMenuDropdown.value - 1) {
			return;
		}

		GameObject potToPlace = Inventory.State.Pots[PotMenuDropdown.value];

		Transform spawnTranform = currentPotSpot.SpawnTransform;
		if (spawnTranform == null) {
			spawnTranform = currentPotSpot.transform;
		}

		GameObject newPotObject = Instantiate(
			potToPlace,
			spawnTranform.position,
			spawnTranform.rotation,
			spawnTranform.parent // TODO: better parent object
		);
		ClickPotScript newPot = newPotObject.GetComponent<ClickPotScript>();
		newPot.PotSpot = currentPotSpot.gameObject;

		AudioManager.instance.Play(
			newPot.PlacePotSoundEffect
		);

		Inventory.State.Pots.RemoveAt(PotMenuDropdown.value);
		PotMenuDropdown.value = 0;

		// Destroy(currentPotSpot.gameObject);
		currentPotSpot.gameObject.SetActive(false);



	}

}
