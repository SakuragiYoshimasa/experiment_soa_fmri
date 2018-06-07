using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class JoystickFrameWriter : Singleton<JoystickFrameWriter> {
	FileInfo file;
	StreamWriter streamWriter;

	[SerializeField]
	private string filename = "../HandLog/handlog";

		void Start () {
			DateTime dt = DateTime.Now;		
			string dateString = String.Format("{0:D2}{1:D2}{2:D2}{3:D2}{4:D2}", dt.Year,  dt.Month, dt.Day, dt.Hour, dt.Minute);
			file = new FileInfo(Application.dataPath + "/" + filename + dateString + ".csv");
			streamWriter = file.AppendText();
		}
		
		public void Write(string line){
			streamWriter.WriteLine(line);
		}
		
		public void Write(float x, float y){
			DateTime dt = DateTime.Now;		
			string dateString = String.Format("{0:D2}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}{6:D3}", dt.Year,  dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
			streamWriter.Write (dateString + ":");
			streamWriter.WriteLine(String.Format("{0},{1}", x, y));
		}

		void OnDestroy(){
			streamWriter.Flush();
			streamWriter.Close();
		}
}
