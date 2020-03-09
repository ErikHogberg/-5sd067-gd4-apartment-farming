using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounterUIScript : MonoBehaviour {

	public static DayCounterUIScript MainInstance;

	private static float initValue = 0;

	private Text text;

	public string Prefix = "Day ";
	public string Infix = " out of ";
	public string Suffix = "!";

	private void Start() {
		MainInstance = this;
		text = GetComponent<Text>();
		SetValue(initValue);
	}

	public void SetValue(float value) {
		text.text = Prefix + value + Infix + Inventory.State.DayLimit + Suffix;
	}

	public static void SetValueStatic(float value) {
		initValue = value;
		if (MainInstance != null) {
			MainInstance.SetValue(value);
		}
	}
}
