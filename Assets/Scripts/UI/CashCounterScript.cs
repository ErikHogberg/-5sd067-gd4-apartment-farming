using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashCounterScript : MonoBehaviour {

	public static List<CashCounterScript> MainInstances = new List<CashCounterScript>();
	private static float initValue = 0;

	private Text text;

	public string Prefix = "Cash: ";
	public string Suffix = "kr";

	private void Start() {
		MainInstances.Add(this);
		text = GetComponent<Text>();
		SetValue(initValue);
	}

	public void SetValue(float value) {
		text.text = Prefix + value + Suffix;
	}

	public static void SetValueStatic(float value) {
		initValue = value;
		foreach (CashCounterScript instance in MainInstances) {
			instance.SetValue(value);
		}
	}

}
