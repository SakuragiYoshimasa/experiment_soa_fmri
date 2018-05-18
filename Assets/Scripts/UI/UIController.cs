using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController> {
	[SerializeField]
	private Text text;
	[SerializeField]
	private Image panel;

	public void setActive(bool isActive){
		text.gameObject.SetActive(isActive);
		panel.gameObject.SetActive(isActive);
	}

	public void setText(string str){
		text.text = str;
	}
}
