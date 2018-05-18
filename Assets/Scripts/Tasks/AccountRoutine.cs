using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ButtonTask{
	public class AccountRoutine : BasicRoutine {
		public override bool UpdateRoutine(){
			UIController.I.setActive(true);

			if(InputHolder.I.answerButton || Input.GetKeyUp(KeyCode.Space)){
				InputHolder.I.answerButton = false;
				Debug.Log("Finish Account");
				return true;
			}
			return false;
		}
	}
}