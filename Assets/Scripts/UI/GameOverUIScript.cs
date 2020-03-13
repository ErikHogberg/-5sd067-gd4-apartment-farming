using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIScript : MonoBehaviour {

	public static GameOverUIScript MainInstance;

	public Text GameOverText;

	public string Prefix;
	public string Suffix;

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
		gameObject.SetActive(true);
		GameOverText.text = Prefix + Inventory.State.Cash + Suffix;
	}

	public void CloseMenu() {
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


	public void ToggleMenu() {
		if (gameObject.activeSelf) {
			CloseMenu();
		} else {
			OpenMenu();
		}
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}

}
