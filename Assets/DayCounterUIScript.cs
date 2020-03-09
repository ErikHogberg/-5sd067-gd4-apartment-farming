using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounterUIScript : MonoBehaviour {

	public static DayCounterUIScript MainInstance;

	private static float dayInitValue = 0;
	private static float dayLimitInitValue = 0;

	private Text text;

	public string Prefix = "Day ";
	public string Infix = " out of ";
	public string Suffix = "!";

	private void Start() {
		MainInstance = this;
		text = GetComponent<Text>();
		SetValue(dayInitValue, dayLimitInitValue);
	}

	public void SetValue(float dayValue, float dayLimitValue) {
		text.text = Prefix + dayValue + Infix + dayLimitValue + Suffix;
	}

	public static void SetValueStatic(float dayValue, float dayLimitValue) {
		dayInitValue = dayValue;
		dayLimitInitValue = dayLimitValue;
		
		if (MainInstance != null) {
			MainInstance.SetValue(dayValue, dayLimitValue);
		}
	}
}
