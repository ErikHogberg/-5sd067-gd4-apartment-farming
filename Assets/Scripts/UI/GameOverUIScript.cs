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

	void Start() {
		MainInstance = this;
		CloseMenu();
	}

	public void OpenMenu() {
		gameObject.SetActive(true);
		GameOverText.text = Prefix + Inventory.State.Cash + Suffix;
	}

	public void CloseMenu() {
		gameObject.SetActive(false);
	}

	public void ToggleMenu() {
		if (gameObject.activeSelf) {
			CloseMenu();
		} else {
			OpenMenu();
		}
	}

	public void RestartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}

}
