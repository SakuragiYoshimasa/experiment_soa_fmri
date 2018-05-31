using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TaskMaker {

	// Purturbation 3 pattern
	// delay 5 pattern
	// reproduction
	// 1 condiction 20-30 trials
	// 20 * (3 * 5 + 1) = 320
	// mapp randomly
	public static int purturbation_pattern = 3;
	public static int delay_pattern = 5;
	public static int task_count = 320;
	
	public static List<Task> generateTaskPattern(bool delayDiscTask){
		List<Task> taskPattern = new List<Task>();

		//p * 5 + d and 15

		//for(int i = 0; i < 15; i++){
		if(!delayDiscTask){
			for(int j = 0; j < 10; j++){
				taskPattern.Add(new Task(1, 0, true));
			}
		}

		for(int i = 0; i < 140; i++){
			//for(int j = 0; j < 20; j++){
				//taskPattern.Add(new Task(i % 3, i / 3));
				//No Purturb
				taskPattern.Add(new Task(1, i % 10));
			//}
		}
		

		taskPattern.Shuffle();

		while(taskPattern[0].isReproduce || taskPattern[1].isReproduce || taskPattern[2].isReproduce || taskPattern[3].isReproduce || taskPattern[4].isReproduce){
			taskPattern.Shuffle();
		}
		
		//Repr test
		//taskPattern [3].isReproduce = true;
		return taskPattern;
	}

	public static List<T> Shuffle<T>(this List<T> list){
		for (int i = 0; i < list.Count; i++) {
			T temp = list[i];
			int randomIndex = Random.Range(0, list.Count);
			list[i] = list[randomIndex];
			list[randomIndex] = temp;
		}

		return list;
	}

}

public class Task {
	public int purturbIndex;
	public int delayIndex;
	public bool isReproduce;

	public Task(int pi, int di, bool isRepr = false){
		this.purturbIndex = pi;
		this.delayIndex = di;
		this.isReproduce = isRepr;
	}
}