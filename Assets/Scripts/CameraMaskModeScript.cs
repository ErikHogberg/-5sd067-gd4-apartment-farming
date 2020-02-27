using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMaskModeScript : MonoBehaviour {

	public enum MaskMode {
		PotSpots,
		Plants
	}

	public static CameraMaskModeScript MainInstance;

	private Camera mainCamera;

	public LayerMask PotSpotMask;
	public LayerMask PlantMask;

	private MaskMode currentMaskMode;
	public MaskMode CurrentMaskMode {
		get {
			return currentMaskMode;
		}

		set {
			switch (value) {
				case MaskMode.PotSpots:
					mainCamera.cullingMask = PotSpotMask;
					break;
				case MaskMode.Plants:
					mainCamera.cullingMask = PlantMask;
					break;
				default:
					break;
			}

			currentMaskMode = value;
		}
	}

	void Start() {
		MainInstance = this;
		mainCamera = GetComponent<Camera>();
		CurrentMaskMode = MaskMode.Plants;
	}

	void Update() {

	}
}
