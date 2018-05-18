using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Leap.Unity;
using inpoutx64;

namespace ButtonTask{
	public class ResourceHolder : Singleton<ResourceHolder> {

		#region UI Components
		[Header("UI Components")]
		public Text AccountText;
		public Text InstructionText;
		public Text delayText;
		public Text perturbText;
		#endregion

		#region TaskObjects
		[Header("Objects for task")]
		public List<GameObject> instructionPanels;
		public JoystickBase joystickBase;
		public Camera cam;
		#endregion

		#region DelaySettings
		public float[] delays = {0, 50f, 100f, 150f, 200f, 250f, 300f, 350f, 400f, 450f};
		public int delays_patterns = 10;
		public int delayIndex = 0;
		#endregion
		/*
		#region Purturbation
		public HandPurturbation hPurturb;
		public float[] purturbation = {-10.0f, -5.0f, 0, 5.0f, 10.0f};
		public int purturb_patterns = 5;
		public int purturb_index = 2;
		#endregion
		*/

		#region PortControl
		[Header("Port Control")]
		public PortController portController;
		#endregion
	}
}