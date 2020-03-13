using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LaptopScripCollection : MonoBehaviour {

	[Serializable]
	public struct DropdownData {
		public string entry;
		public GameObject menu;

	}

	public TMP_Dropdown MenuDropdown;
	public int DefaultEntry = 0;

	public List<DropdownData> entries;


	void Start() {
		MenuDropdown.value = DefaultEntry;
		DropdownValueChange(DefaultEntry);
		List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
		foreach (DropdownData entry in entries) {
			options.Add(new TMP_Dropdown.OptionData(entry.entry));
		}
		MenuDropdown.options = options;
	}

	public void DropdownValueChange (int value){
		HideAll();
		if (entries[value].menu == null) {
			return;
		}
		entries[value].menu.gameObject.SetActive(true);
	}

	public void Reset() {
		MenuDropdown.value = DefaultEntry;
		//HideAll();
		DropdownValueChange(MenuDropdown.value);
	}

	private void HideAll() {
		foreach (DropdownData entry in entries) {
			if (entry.menu == null) {
				continue;
			}
			entry.menu.gameObject.SetActive(false);
		}
	}



}
