using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDeleteScript : MonoBehaviour {

	public GameObject ObjectToDelete;

	[Tooltip("0 = left click, 1 = right click, 2 = middle click, 3+ is next/back buttons, mmo buttons, etc.")]
	public int Button = 1;


	void Start() {

	}

	void Update() {

	}

	private void OnMouseOver() {
		if (Input.GetMouseButton(Button)) {
			Destroy(ObjectToDelete);
		}
	}





}
