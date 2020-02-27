using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;

[RequireComponent(typeof(Toggle))]
public class PlacePotsToggleScript : MonoBehaviour {

	private Toggle toggle;

	void Start() {
		toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(ToggleFunction);
		// ToggleFunction(toggle.isOn);
	}

	public static void ToggleFunction(bool toggleValue) {
		if (toggleValue) {
			CameraMaskModeScript.MainInstance.CurrentMaskMode = CameraMaskModeScript.MaskMode.PotSpots;
		} else {
			CameraMaskModeScript.MainInstance.CurrentMaskMode = CameraMaskModeScript.MaskMode.Plants;
			ChoosePotMenuScript.CloseStaticMenu();
		}
	}


}
