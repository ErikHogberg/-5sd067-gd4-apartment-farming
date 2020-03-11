using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIScript : MonoBehaviour {

	public static GameOverUIScript MainInstance;

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
