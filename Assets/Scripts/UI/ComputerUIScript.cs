using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUIScript : MonoBehaviour {

	public static ComputerUIScript MainInstance;

	void Start() {
		MainInstance = this;
        CloseMenu();
	}

	public void OpenMenu() {
		gameObject.SetActive(true);
	}

	public void CloseMenu() {
		gameObject.SetActive(false);
	}

}
