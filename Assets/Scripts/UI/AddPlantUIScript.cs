using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlantUIScript : MonoBehaviour
{

	// IDEA: define cost to subtract
	public Plant PlantToAdd;

    void Start()
    {
        
    }

	public void AddPlant(){
		Inventory.State.Seeds.Add(PlantToAdd);
	}
}
