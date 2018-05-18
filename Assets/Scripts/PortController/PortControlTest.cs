using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inpoutx64;
using System;

public class PortControlTest : MonoBehaviour {

	bool open = false;
	int decData = 0;
    int decAdd = 0xDFF8; //DFF8

	public GameObject label;

	void Start () {
		if (!PortControl.IsInpOutDriverOpen()) {
            Debug.Log("Driver is not opened !!!");
            return;
        } else {
			StartCoroutine(test());
		}
	}
	
	// Update is called once per frame
	void Update () {
		/* 
		if(open){
			decData = 255;
			PortControl.Output(decAdd, decData);
		}else{
			decData = 0;
			PortControl.Output(decAdd, decData);
		}

		if(Input.GetKeyDown(KeyCode.Space)) open = !open;*/
	}


	IEnumerator test(){
		for(int i = 0; i < 50; i ++){
			
			for(float interval = 0.4f; interval <= 2.0f; interval += 0.4f){
				var start = DateTime.Now;
				PortControl.Output(decAdd, 255);
				yield return new WaitForSeconds(0.2f);
				var end = DateTime.Now;
				PortControl.Output(decAdd, 0);
				yield return new WaitForSeconds(interval - 0.2f);
				//PortcontrolTestWriter.I.Write(start, end);
			}
		}

		for(int i = 0; i < 50; i ++){
			
			for(float interval = 0.4f; interval <= 2.0f; interval += 0.4f){
				var start = DateTime.Now;
				PortControl.Output(decAdd, 255);
				yield return new WaitForSeconds(interval);
				var end = DateTime.Now;
				PortControl.Output(decAdd, 0);
				yield return new WaitForSeconds(interval);
				//PortcontrolTestWriter.I.Write(start, end);
			}
		}

		label.SetActive(true);
	}
}
