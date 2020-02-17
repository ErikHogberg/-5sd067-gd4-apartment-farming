using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDeleteScript : MonoBehaviour {

	[Tooltip("[Not used if Spawned By Click Script is true] Should be set to the top-most parent object that will be deleted, setting this to the wrong object might fill the scene with garbage clone objects")]
	public GameObject ObjectToDelete;
	[Tooltip("Enable this only if this is a prefab/object spawned by a ClickPotScript, this changes how the object is deleted")]
	public bool SpawnedByClickScript = true;

	[Tooltip("0 = left click, 1 = right click, 2 = middle click, 3+ is next/back, mmo buttons, etc.")]
	public int Button = 1;


	void Start() {

	}

	void Update() {

	}

	private void OnMouseOver() {
		if (Input.GetMouseButton(Button)) {
			if (SpawnedByClickScript) {
				ClickPotScript.ClearObject();
			} else {
				if (ObjectToDelete == null) {
					Destroy(this.gameObject);
				} else {
					Destroy(ObjectToDelete);
				}
			}
		}
	}





}
