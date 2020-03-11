using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePotMenuScript : MonoBehaviour {

	public Dropdown PotMenuDropdown;

	public static ChoosePotMenuScript MainInstance;

	private PotSpotScript currentPotSpot;

	public bool EnableSound = false;

	void Start() {
		MainInstance = this;
		gameObject.SetActive(false);
	}

	public void OpenMenu(PotSpotScript potSpot) {
		gameObject.SetActive(true);
		PlantMenuScript.MainInstance.CloseMenu();

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

		Instantiate(
			potToPlace,
			spawnTranform.position,
			spawnTranform.rotation,
			spawnTranform.parent // TODO: better parent object
		);

		if (EnableSound) {
			AudioManager.instance.Play(
				potToPlace.GetComponent<ClickPotScript>().PlacePotSoundEffect
			);
		}

		Inventory.State.Pots.RemoveAt(PotMenuDropdown.value);

		Destroy(currentPotSpot.gameObject);



	}

}
