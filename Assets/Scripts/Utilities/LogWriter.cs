using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace ButtonTask{
	public class LogWriter : Singleton<LogWriter> {

		FileInfo file;
		StreamWriter streamWriter;

		[SerializeField]
		private string filename = "../TaskLog/tasklog_";

		void Start () {
			DateTime dt = DateTime.Now;		
			string dateString = String.Format("{0:D2}{1:D2}{2:D2}{3:D2}{4:D2}", dt.Year,  dt.Month, dt.Day, dt.Hour, dt.Minute);
			file = new FileInfo(Application.dataPath + "/" + filename + dateString + ".csv");
			streamWriter = file.AppendText();

			string labelLine = "start_time, end_time, instructedPanel, delay, purturb, is_reproduce, reproduce, response, touchedPanel";
			streamWriter.WriteLine(labelLine);
		}
		
		public void Write(string line){
			streamWriter.WriteLine(line);
		}

		public void Write(DateTime startTime, DateTime endTime, int instru_panel, int delay, int purturb, bool isReproduce, int reproduce, int response, int touchedPanel){
			string startDateString = String.Format("{0:D4}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}{6:D3}", startTime.Year,  startTime.Month, startTime.Day, startTime.Hour, startTime.Minute, startTime.Second, startTime.Millisecond);
			string endDateString =  String.Format("{0:D4}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}{6:D3}", endTime.Year, endTime.Month, endTime.Day, endTime.Hour, endTime.Minute, endTime.Second, endTime.Millisecond);
			streamWriter.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", startDateString, endDateString, instru_panel, delay, purturb, isReproduce ? 1 : 0, reproduce, response, touchedPanel));
		}

		void OnDestroy(){
			streamWriter.Flush();
			streamWriter.Close();
		}
	}
}
