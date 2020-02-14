using UnityEngine;

public class RotateScript : MonoBehaviour {

	public float RotationSpeed = 1.0f;

	public bool EnableMouse = true;

	public float MouseRotationSpeed = 1.0f;

	private float mouseBuffer;

    public Space RelativeSpace = Space.Self;

	void Start() {

	}

	void Update() {

		if (Input.GetMouseButtonDown(0)) {
			mouseBuffer = Input.mousePosition.x;
		} 
        // else if (Input.GetMouseButtonUp(0)) {}

		if (EnableMouse && Input.GetMouseButton(0)) {
			transform.Rotate(Vector3.up, (Input.mousePosition.x - mouseBuffer) * MouseRotationSpeed, RelativeSpace);
			mouseBuffer = Input.mousePosition.x;
		} else {
			transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime, RelativeSpace);
		}

	}
}
