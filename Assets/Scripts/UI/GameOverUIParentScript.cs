using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIParentScript : MonoBehaviour {

	public static GameOverUIParentScript MainInstance;

	public GameObject StandardMenu;

	void Start() {

		MainInstance = this;
		CloseMenu();

	}

	public void OpenMenu(){
		StandardMenu.SetActive(false);
		gameObject.SetActive(true);
	}

	public void CloseMenu(){
		StandardMenu.SetActive(true);
		gameObject.SetActive(false);
	}

}
