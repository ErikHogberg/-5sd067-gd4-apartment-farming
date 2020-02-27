using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRefTestScript : MonoBehaviour {

	public static List<ObjectRefTestScript> instances = new List<ObjectRefTestScript>();
	public static List<GameObject> objects = new List<GameObject>();

	public int testInt = 0;
	public string testString;

	void Start() {
		instances.Add(this);
		objects.Add(gameObject);
	}

	private void OnDestroy() {
		instances.Remove(this);
		objects.Remove(gameObject);
	}

	void Update() {

	}

	public void Check() {
		foreach (ObjectRefTestScript item in instances) {
			Debug.Log("int: " + item.testInt + ", string: " + item.testString);
		}

		foreach (GameObject item in objects) {

		}
	}

	private void OnMouseDown() {
		Check();
	}
}
