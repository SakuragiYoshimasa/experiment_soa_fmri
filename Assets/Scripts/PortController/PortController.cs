using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inpoutx64;

public class PortController : MonoBehaviour {
	bool open = false;
	int decData = 0;
    int decAdd = 0xDFF8;
	
	void Start () {
		if (!PortControl.IsInpOutDriverOpen()) {
            Debug.Log("Driver is not opened !!!");
            return;
        }
	}

	void Update () {
		if(open){
			decData = 255;
			PortControl.Output(decAdd, decData);
		}else{
			decData = 0;
			PortControl.Output(decAdd, decData);
		}
	}

	public IEnumerator Out(int data){
		yield return new WaitForEndOfFrame();
		PortControl.Output(decAdd, data);
		Invoke("Close", 0.2f);
	}

	void Close(){
		PortControl.Output(decAdd, 0);
	}

	void OnDestroy(){
		Close();
	}
}
