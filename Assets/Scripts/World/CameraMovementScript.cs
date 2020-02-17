using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovementScript : MonoBehaviour {

	public static CameraMovementScript MainInstance = null;

	// public static Camera MainCamera = null;
	private Camera MainCamera = null;

	public float CameraMovementSpeed = 1.0f;
	public float CameraTurningSpeed = 1.0f;

	[Tooltip("If next camera spot is first spot when at last spot in the list, or if it stops at last spot")]
	public bool LoopSpots = true;
	public int CurrentSpot = 0;

	public List<GameObject> CameraSpots;

	void Start() {
		MainCamera = GetComponent<Camera>();
		MainInstance = this;

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

	public void NextCameraInternal() {
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
