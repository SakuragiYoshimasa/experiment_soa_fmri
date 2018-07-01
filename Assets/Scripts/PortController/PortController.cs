using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inpoutx64;
using ButtonTask;

public class PortController : MonoBehaviour {
	bool open = false;
	int decData = 0;
    int decAdd = 0xDFF8;
	
	void Start () {
		if (!PortControl.IsInpOutDriverOpen()) {
            Debug.Log("Driver is not opened !!!");
			LogWriter.I.Write("Driver is not opend!!!");
            return;
        }
	}

	void Update () {
		/*
		if(open){
			decData = 255;
			PortControl.Output(decAdd, decData);
		}else{
			decData = 0;
			PortControl.Output(decAdd, decData);
		} */
	}

	public void Out(int data){
		//yield return new WaitForEndOfFrame();
		PortControl.Output(decAdd, data);
		Invoke("Close", 0.1f);
	}

	void Close(){
		PortControl.Output(decAdd, 0);
	}

	void OnDestroy(){
		Close();
	}
}
