using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButtonTask{
	public class PracticeStartRoutine : BasicRoutine {
		public override bool UpdateRoutine(){
			UIController.I.setActive(true);
			return true;
		}
	}
}