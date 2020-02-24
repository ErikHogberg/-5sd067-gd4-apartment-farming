﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpotScript : MonoBehaviour {

	void Start() {

	}

	private void OnMouseDown() {
		if (CameraMaskModeScript.MainInstance.CurrentMaskMode == CameraMaskModeScript.MaskMode.PotSpots) {
			// ChoosePotMenuScript.MainInstance.gameObject.SetActive(true);
			ChoosePotMenuScript.OpenStaticMenu(this);
		}
	}

}
