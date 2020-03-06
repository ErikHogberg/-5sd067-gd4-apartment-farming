using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashCounterScript : MonoBehaviour {

	public static CashCounterScript MainInstance;
	private static float initValue = 0;

	private Text text;

	public string Prefix = "Cash: ";
	public string Suffix = "kr";

	private void Start() {
		MainInstance = this;
		text = GetComponent<Text>();
		SetValue(initValue);
	}

	public void SetValue(float value) {
		text.text = Prefix + value + Suffix;
	}

	public static void SetValueStatic(float value) {
		if (MainInstance != null) {
			MainInstance.SetValue(value);
		} else {
			initValue = value;
		}
	}

}
