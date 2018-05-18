using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ButtonTask;

public class InputHolder : Singleton<InputHolder> {

	[SerializeField]
	public Vector2 joystckAxis = new Vector2();
	public string answerButtonCode;
	public bool answerButton;

	[SerializeField]
	private int touchedPanelIndex = 0;
	public int TouchedPanelIndex {
		get {
			return touchedPanelIndex;
		}
		set {
			touchedPanelIndex = value;
		}
	}

	void Update () {
		if(Input.GetKeyDown(answerButtonCode)){
			answerButton = true;
			StartCoroutine(ResourceHolder.I.portController.Out(1));
		}

		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		joystckAxis.x = x;
		joystckAxis.y = y;
	}
}
