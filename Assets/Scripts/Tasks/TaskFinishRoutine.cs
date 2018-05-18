using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButtonTask{
	public class TaskFinishRoutine : BasicRoutine {
		public override bool UpdateRoutine(){
			UIController.I.setText("Thank you.");
			UIController.I.setActive(true);
			return false;
		}
	}
}