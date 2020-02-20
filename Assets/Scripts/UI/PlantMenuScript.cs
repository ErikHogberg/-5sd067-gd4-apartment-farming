using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMenuScript : MonoBehaviour {

	public static PlantMenuScript MainInstance;

	private ClickPotScript currentPot;

	void Start() {
		MainInstance = this;
	}

	void Update() {

	}

	public void InspectPot(ClickPotScript pot) {
		// TODO: show menu
		// TODO: populate menu
		currentPot = pot;
	}

	public void ClearPot(){
		// TODO: hide menu
		currentPot = null;
	}

}
