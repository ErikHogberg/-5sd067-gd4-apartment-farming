using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedFollowRotationScript : MonoBehaviour {

	public GameObject ObjectToFollow;

	private Quaternion initialDirection;

	void Start() {
		initialDirection = transform.rotation;
	}

	void Update() {

		transform.rotation =
			Quaternion.Inverse( ObjectToFollow.transform.rotation);
			// Quaternion.Euler(Vector3.Reflect(
			// 	ObjectToFollow.transform.rotation.eulerAngles,
			// 	initialDirection.eulerAngles
			// ));
	}

}
