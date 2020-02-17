using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Camera))]
public class CameraMovementScript : MonoBehaviour {

	private static CameraMovementScript mainInstance = null;
	private static CameraMovementScript MainInstance {
		get {

			if (mainInstance == null) {
				mainInstance = Camera.main.GetComponent<CameraMovementScript>();
			}

			// Crash if camera has no movement script
			Assert.AreNotEqual(mainInstance, null);

			return mainInstance;
		}
	}

	// public static Camera MainCamera = null;
	private Camera mainCamera = null;

	public float CameraMovementSpeed = 1.0f;
	public float CameraTurningSpeed = 1.0f;

	[Tooltip("If next camera spot is first spot when at last spot in the list, or if it stops at last spot")]
	public bool LoopSpots = true;
	public int CurrentSpot = 0;

	public List<GameObject> CameraSpots;

	void Start() {
		mainCamera = GetComponent<Camera>();
		mainInstance = this;

	}

	void Update() {

		transform.position = Vector3.Lerp(
			transform.position,
			CameraSpots[CurrentSpot].transform.position,
			CameraMovementSpeed * Time.deltaTime
		);

		transform.rotation = Quaternion.Slerp(
			transform.rotation,
			CameraSpots[CurrentSpot].transform.rotation,
			CameraTurningSpeed * Time.deltaTime
		);


	}

	private static void ClearSelected(){
		ClickPotScript.ClearObject();
	}

	public void NextCameraInternal() {
		ClearSelected();

		CurrentSpot++;

		if (CurrentSpot >= CameraSpots.Count) {
			if (LoopSpots) {
				CurrentSpot = 0;
			} else {
				CurrentSpot = CameraSpots.Count - 1;
			}
		}
	}

	public static void NextCamera() {
		MainInstance.NextCameraInternal();
	}

	public void PrevCameraInternal() {
		ClearSelected();
		
		CurrentSpot--;

		if (CurrentSpot < 0) {
			if (LoopSpots) {
				CurrentSpot = CameraSpots.Count - 1;
			} else {
				CurrentSpot = 0;
			}
		}

	}

	public static void PrevCamera() {
		MainInstance.PrevCameraInternal();
	}

}
