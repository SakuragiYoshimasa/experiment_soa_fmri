using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ButtonTask{
	[Serializable]
	public abstract class BasicRoutine : MonoBehaviour {
		protected ResourceHolder rHolder;

		void Awake(){ rHolder = ResourceHolder.I;}
		public abstract bool UpdateRoutine(); 
	}
}
