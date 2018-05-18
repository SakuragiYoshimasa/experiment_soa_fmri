using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMeasurement : MonoBehaviour {

    StreamWriter sw;
    FileInfo fi;

    public string fileName;
    public bool fpsMode = false;
    int frameCount = 0;
    float prevTime = 0;

	void Start () {
        fi = new FileInfo(Application.dataPath + "/" + fileName);
        sw = fi.AppendText();
	}

	void Update () {
		++frameCount;
        float time = Time.realtimeSinceStartup - prevTime;
        
        if (time >= 0.5f) {
            Debug.LogFormat("{0}fps", frameCount / time);
            StampEvent((frameCount / time).ToString());
            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
	}

    public void StampEvent(string eventName) {
        sw.WriteLine(eventName);
    }

    public void StampTime(long time)
    {
        sw.WriteLine(time.ToString());
    }

    private void OnDestroy()
    {
        sw.Flush();
        sw.Close();
    }
}
