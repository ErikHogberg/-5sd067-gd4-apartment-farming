using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashCounterScript : MonoBehaviour
{

	public static CashCounterScript MainInstance;

	private Text text;

	public string Prefix = "Cash: ";
	public string Suffix = "kr";

	private void Start() {
		MainInstance = this;
		text = GetComponent<Text>();
	}

	public void SetValue(float value){
		text.text = Prefix + value + Suffix;
	}

	public static void SetValueStatic(float value){
		MainInstance.SetValue(value);
	}

}
