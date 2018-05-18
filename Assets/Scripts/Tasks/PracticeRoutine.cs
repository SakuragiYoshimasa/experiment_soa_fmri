using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButtonTask{
	public class PracticeRoutine : BasicRoutine {

		private bool start = false;
		private bool finish = false;

		public override bool UpdateRoutine(){
			
			if(!start){
				StartCoroutine(PracticeCoroutine());
				start = true;
			}
			if(finish){
				return true;
			}
			return false;
		}

		IEnumerator PracticeCoroutine(){

			UIController.I.setText("赤いボタンに到達してください");
			UIController.I.setActive(true);
			yield return new WaitForSeconds(2.0f);
			UIController.I.setText("");
			//UIController.I.setActive(false);
			//yield return new WaitForSeconds(2.0f);
			
			for(int n = 0; n < 30; n++){

				UIController.I.setActive(true);
				//rHolder.leap.delay = 0f;
				//rHolder.hPurturb.purturb = 0f;
				InputHolder.I.TouchedPanelIndex = 0;
				yield return new WaitForSeconds(1.0f);

				UIController.I.setActive(false);
				yield return new WaitForSeconds(0.5f);

				int index = (int)(Random.Range(0, 1.0f) * (float)rHolder.instructionPanels.Count);
				rHolder.instructionPanels[index].GetComponent<MeshRenderer>().material.color = Color.red;
				
				int max_iter = 10;
				for(int i = 0; i < max_iter; i++){
					if(InputHolder.I.TouchedPanelIndex == 0){
						yield return new WaitForSeconds(0.2f);
					}else{
						break;
					}
				}

				rHolder.instructionPanels[index].GetComponent<MeshRenderer>().material.color = Color.white;
				yield return new WaitForSeconds(2.0f);
			}
			UIController.I.setActive(true);
			UIController.I.setText("Finished Practice");
			yield return new WaitForSeconds(2.0f);
			finish = true;
		}
	}
}
