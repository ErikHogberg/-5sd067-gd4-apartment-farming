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

	private bool updateValueFromStatic = false;

	private void Start() {
		MainInstances.Add(this);
		text = GetComponent<Text>();
		SetValue(initValue);
	}

	private void OnDestroy() {
		MainInstances.Remove(this);
	}

	private void Update() {
		if (updateValueFromStatic)
		{
			SetValue(initValue);
			updateValueFromStatic = false;
		}
	}

	public void SetValue(float value) {
		text.text = Prefix + value + Suffix;		
	}

	public static void SetValueStatic(float value) {
		initValue = value;
		foreach (CashCounterScript instance in MainInstances) {
			// instance.SetValue(value);
			instance.updateValueFromStatic = true;
		}
	}

}
