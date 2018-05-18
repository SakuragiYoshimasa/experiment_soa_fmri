using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace ButtonTask {
	public class TaskRoutine : BasicRoutine {
		private bool start = false;
		private bool finish = false;
		private List<Task> task_patterns;
		private int lastInput;

		public override bool UpdateRoutine(){
			
			if(!start){
				task_patterns = TaskMaker.generateTaskPattern(TaskManager.I.isDelayDiscTask);
				StartCoroutine(TaskCoroutine());
				start = true;
			}
			if(finish){
				return true;
			}
			return false;
		}

		IEnumerator TaskCoroutine(){

			UIController.I.setText("実験を開始します");
			UIController.I.setActive(true);
			yield return new WaitForSeconds(2.0f);
			UIController.I.setText("");
			int task_number = 0;
	
			foreach(Task task in task_patterns){

				task_number++;

				rHolder.joystickBase.stacking = !TaskManager.I.isDelayDiscTask;
				InputStack.I.startSave();
				int reprIndex = 0;
				int mask = rHolder.cam.cullingMask;
				UIController.I.setActive(true);
				rHolder.delayIndex = task.delayIndex;
				rHolder.joystickBase.delay = rHolder.delays[task.delayIndex];
				//rHolder.hPurturb.purturb = 0f;

				if(task.isReproduce){
					rHolder.joystickBase.isReproduction = true;
					reprIndex = rHolder.joystickBase.setReproductedFrames();
				}
				yield return new WaitForSeconds(1.0f);

				UIController.I.setActive(false);
				yield return new WaitForSeconds(0.5f);

				int index = (int)(UnityEngine.Random.Range(0, 1.0f) * (float)rHolder.instructionPanels.Count);
				rHolder.instructionPanels[index].GetComponent<MeshRenderer>().material.color = Color.red;
				InputHolder.I.answerButton = false;
				InputHolder.I.TouchedPanelIndex = 0;
				StartCoroutine(rHolder.portController.Out(255));
				DateTime start_time = DateTime.Now;

				//Sum tome of this routine is 2.0secs
				if(!task.isReproduce){
					
					//rHolder.delayText.text = "Delay:" + rHolder.delays[rHolder.delayIndex].ToString();
					//rHolder.purturb_index = task.purturbIndex;
					//rHolder.perturbText.text = "P:" + rHolder.purturbation[rHolder.purturb_index].ToString();
					//yield return new WaitForSeconds(0.05f);

					//Removed Purturbation
					//while(Mathf.Abs(rHolder.hPurturb.purturb) < Mathf.Abs(rHolder.purturbation[rHolder.purturb_index])){
					//	rHolder.hPurturb.purturb += rHolder.purturbation[rHolder.purturb_index] / 10.0f;
					//	yield return new WaitForSeconds(0.05f);
					//}
					//if(rHolder.purturbation[rHolder.purturb_index] == 0f){
						//yield return new WaitForSeconds(0.55f);
					//}
			
					int max_iter = 10;
					for(int i = 0; i < max_iter; i++){
						if(InputHolder.I.TouchedPanelIndex == 0){
							yield return new WaitForSeconds(0.2f);
						}else{
							break;
						}
					}

				}else{
					Debug.Log ("repr");
					yield return new WaitForSeconds(2.0f);
				}

				//Wait Input
				rHolder.instructionPanels[index].GetComponent<MeshRenderer>().material.color = Color.white;
				yield return new WaitForSeconds(2.0f);

				rHolder.joystickBase.stacking = false;
				rHolder.joystickBase.isReproduction = false;
				rHolder.joystickBase.resetFrameBuffers();
				InputStack.I.endSave();

				DateTime end_time = DateTime.Now;
				LogWriter.I.Write(start_time,
								  end_time,
								  index + 1,
				  				  task.delayIndex, 
								  task.purturbIndex, 
								  task.isReproduce, 
								  reprIndex, 
								  InputHolder.I.answerButton ? 1 : 0, 
								  InputHolder.I.TouchedPanelIndex);
				lastInput = 0;
			}
	
			UIController.I.setText("Finished Task");
			UIController.I.setActive(true);
			yield return new WaitForSeconds(2.0f);		
			finish = true;
		}
	}
}