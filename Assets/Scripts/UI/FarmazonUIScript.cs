using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmazonUIScript : MonoBehaviour {

	public string BuySoundEffect;

	public void BuySeed(GameObject seedPrefab) {
		PlantPrefabScript seed = seedPrefab.GetComponent<PlantPrefabScript>();
		if (Inventory.State.Cash < seed.Price) {
			return;
		}
		
		Inventory.State.Cash -= seed.Price;
		Inventory.State.Seeds.Add(seedPrefab);
		InventoryMenuScript.MainInstance.PopulateMenu();

		AudioManager.instance.Play(BuySoundEffect);
	}

	public void BuyPot(GameObject potPrefab) {
		ClickPotScript pot = potPrefab.GetComponent<ClickPotScript>();
		if (Inventory.State.Cash < pot.Price) {
			return;
		}

		Inventory.State.Cash -= pot.Price;
		Inventory.State.Pots.Add(potPrefab);
		InventoryMenuScript.MainInstance.PopulateMenu();

		AudioManager.instance.Play(BuySoundEffect);
	}

}
