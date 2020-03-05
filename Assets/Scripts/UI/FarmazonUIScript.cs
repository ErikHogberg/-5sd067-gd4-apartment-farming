using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmazonUIScript : MonoBehaviour
{
    void Start()
    {
        
    }

	public void BuySeed(GameObject seedPrefab) {
		Inventory.State.Cash -= seedPrefab.GetComponent<PlantPrefabScript>().Price;
		Inventory.State.Seeds.Add(seedPrefab);
		InventoryMenuScript.MainInstance.PopulateMenu();
	}

	public void BuyPot(GameObject seedPrefab) {
		Inventory.State.Cash -= seedPrefab.GetComponent<PlantPrefabScript>().Price;
		Inventory.State.Pots.Add(seedPrefab);
		InventoryMenuScript.MainInstance.PopulateMenu();
	}

}
