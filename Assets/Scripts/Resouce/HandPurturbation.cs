using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButtonTask{
	public class HandPurturbation : MonoBehaviour {
		private Vector3 initialRot;
		public float purturb = 0;

		void Awake(){
			initialRot = transform.localRotation.eulerAngles;
		}

		void Update(){
			transform.localRotation = Quaternion.Euler(initialRot + new Vector3(0, purturb, 0));
		}
	}
}