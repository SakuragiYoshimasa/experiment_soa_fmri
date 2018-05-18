using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Leap.Unity;
using inpoutx64;


namespace ButtonTask{
	public class TaskManager : Singleton<TaskManager> {

		#region State
		enum ExpState {
			Account, PracticeStart, Practice, PracticeFinish, TaskStart, Task, TaskFinish
		}

		enum TaskState {
			Free, Instruction
		}

		[Header("Status")]
		[SerializeField]
		bool isSyncTest = false;
		[SerializeField]
		bool isPractice = false;
		[SerializeField]
		public bool isDelayDiscTask = false;
		[SerializeField]
		ExpState expState = ExpState.Account;
		[SerializeField]
		TaskState taskState = TaskState.Free;
		#endregion

		#region Routines
		[SerializeField] List<BasicRoutine> Routines;
		#endregion

		void Start () {
			Application.targetFrameRate = 120;
			expState = ExpState.Account;
			taskState = TaskState.Free;

			if(Routines.Count != 7){
				Debug.Log("Not enough routine");
				return;
			}
		}
		
		void Update () {
			
			if(Routines.Count != 7) return;
			if(Routines[(int)expState].UpdateRoutine()){ 
				if(!isPractice && expState == ExpState.Account){
					expState = ExpState.TaskStart;
				} else if(expState == ExpState.PracticeFinish && isPractice){
					expState = ExpState.PracticeFinish;
				} else {
					expState = expState + 1;
				}
			}
		}
	}
}