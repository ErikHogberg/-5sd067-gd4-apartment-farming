using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIParentScript : MonoBehaviour {

	public static GameOverUIParentScript MainInstance;

	public GameObject StandardMenu;

	public static bool OpenOnStart = false;

	void Start() {

		MainInstance = this;
		if (OpenOnStart) {
			OpenMenu();
		} else {
			CloseMenu();
		}

	}

	private void OnDestroy() {
		OpenOnStart = false;
	}

	public void OpenMenu() {
		StandardMenu.SetActive(false);
		CameraMaskModeScript.SetMaskModeStatic(CameraMaskModeScript.MaskMode.Plants);
		gameObject.SetActive(true);
	}

	public void CloseMenu() {
		StandardMenu.SetActive(true);
		gameObject.SetActive(false);
	}

	public static void OpenMenuStatic() {
		OpenOnStart = true;
		if (MainInstance != null) {
			MainInstance.OpenMenu();
		}
	}

	public static void CloseMenuStatic() {
		OpenOnStart = false;
		if (MainInstance != null) {
			MainInstance.CloseMenu();
		}
	}

}
