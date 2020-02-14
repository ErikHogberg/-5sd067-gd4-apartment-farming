using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDeleteScript : MonoBehaviour {

	public GameObject ObjectToDelete;

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
