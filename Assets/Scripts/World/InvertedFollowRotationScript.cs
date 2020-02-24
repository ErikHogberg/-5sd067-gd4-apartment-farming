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

		// Vector3 lookDir = (ObjectToFollow.transform.position - transform.position).normalized;
		Quaternion fromTo = Quaternion.FromToRotation(ObjectToFollow.transform.position, transform.position);

		// transform.rotation =
		// Quaternion.Inverse( ObjectToFollow.transform.rotation);
		// Quaternion.Euler(Vector3.Reflect(
		// 	ObjectToFollow.transform.rotation.eulerAngles,
		// 	initialDirection.eulerAngles
		// ));

		// Matrix4x4 mat = Matrix4x4.identity
		// 	* Matrix4x4.Rotate(fromTo)
		// 	* Matrix4x4.
		// ;

		transform.rotation = Quaternion.Inverse(fromTo);
		// transform.rotation = fromTo;
		// transform.Rotate(Vector3.up, Mathf.PI, Space.Self);
		

		// transform.Rotate


	}

}
