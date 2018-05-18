using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButtonTask{
	public class PracticeFinishRoutine : BasicRoutine {
		public override bool UpdateRoutine(){
			UIController.I.setActive(false);
			return true;
		}
	}
}
