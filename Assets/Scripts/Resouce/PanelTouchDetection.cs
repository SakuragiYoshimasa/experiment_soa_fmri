using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTouchDetection : MonoBehaviour {

	public int panelIndex;

	void OnTriggerEnter(Collider other) {
		InputHolder.I.TouchedPanelIndex = panelIndex;
	}
}
