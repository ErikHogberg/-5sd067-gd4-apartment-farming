using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Camera))]
public class CameraMovementScript : MonoBehaviour {

	public enum CameraSpotType {
		CameraSpot,
		InbetweenSpot,
		InbetweenSpotWaitOnlyForPosition,
		InbetweenSpotWaitOnlyForAngle,
	}

	[Serializable]
	public struct CameraSpot {
		public Transform Spot;
		public CameraSpotType Type;
	}

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

	// if transitioning to next spot, instead of previous
	private bool next = true;

	// [Header("test header")]
	[Tooltip("Scale speed depending on distance between the 2 points, use this if you want the time taken to move between camera spots to always be the same")]
	public bool UseRelativeSpeed = false;

	private float distanceBuffer;

	[Tooltip("If next camera spot is first spot when at last spot in the list, or if it stops at last spot")]
	public bool LoopSpots = true;
	public int CurrentSpot = 0;

	public List<CameraSpot> CameraSpots;


	void Start() {
		mainCamera = GetComponent<Camera>();
		mainInstance = this;

	}

	void Update() {

		float moveSpeed = CameraMovementSpeed * Time.deltaTime;
		float turnSpeed = CameraTurningSpeed * Time.deltaTime;

		if (UseRelativeSpeed) {
			moveSpeed *= distanceBuffer;
			turnSpeed *= distanceBuffer;
		}

		transform.position = Vector3.MoveTowards(
			transform.position,
			CameraSpots[CurrentSpot].Spot.transform.position,
			moveSpeed
		);

		transform.rotation = Quaternion.RotateTowards(
			transform.rotation,
			CameraSpots[CurrentSpot].Spot.transform.rotation,
			turnSpeed
		);

		bool shouldChangeSpot = false;
		switch (CameraSpots[CurrentSpot].Type) {
			case CameraSpotType.CameraSpot:
				shouldChangeSpot = false;
				break;
			case CameraSpotType.InbetweenSpot:
				shouldChangeSpot =
					transform.position == CameraSpots[CurrentSpot].Spot.transform.position
					&& transform.rotation == CameraSpots[CurrentSpot].Spot.transform.rotation
				;
				break;
			case CameraSpotType.InbetweenSpotWaitOnlyForAngle:
				shouldChangeSpot =
					transform.rotation == CameraSpots[CurrentSpot].Spot.transform.rotation
				;
				break;
			case CameraSpotType.InbetweenSpotWaitOnlyForPosition:
				shouldChangeSpot =
					transform.position == CameraSpots[CurrentSpot].Spot.transform.position
				;
				break;
		}

		if (shouldChangeSpot) {
			if (next) {
				NextCameraInternal();
			} else {
				PrevCameraInternal();
			}
		}

	}

	private static void ClearSelected() {
		ClickPotScript.ClearObject();
	}

	private void SetDistance(int targetIndex) {
		distanceBuffer = Vector3.Distance(transform.position, CameraSpots[targetIndex].Spot.transform.position);
	}

	private void SetDistance() {
		SetDistance(CurrentSpot);
	}


	public void NextCameraInternal() {
		ClearSelected();

		next = true;
		CurrentSpot++;

		if (CurrentSpot >= CameraSpots.Count) {
			if (LoopSpots) {
				CurrentSpot = 0;
			} else {
				CurrentSpot = CameraSpots.Count - 1;
			}
		}
		SetDistance();
	}

	public static void NextCamera() {
		MainInstance.NextCameraInternal();
	}

	public void PrevCameraInternal() {
		ClearSelected();

		next = false;
		CurrentSpot--;

		if (CurrentSpot < 0) {
			if (LoopSpots) {
				CurrentSpot = CameraSpots.Count - 1;
			} else {
				CurrentSpot = 0;
			}
		}
		SetDistance();

	}

	public static void PrevCamera() {
		MainInstance.PrevCameraInternal();
	}

}
