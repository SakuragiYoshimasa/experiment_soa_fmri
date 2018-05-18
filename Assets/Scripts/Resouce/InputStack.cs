using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStack : Singleton<InputStack> {
		
		public int max_stack = 10;
		public Queue<Queue<Frame>> ReproductedUpdateFrames = new Queue<Queue<Frame>>();
		private Queue<Frame> stackingUpdateFrames;

		public void startSave(){
			stackingUpdateFrames = new Queue<Frame>();
		}
		public void saveUpdateFrame(Frame f){
			stackingUpdateFrames.Enqueue(f);
		}

		public void endSave(){
			if(stackingUpdateFrames.Count == 0) return; 
			ReproductedUpdateFrames.Enqueue(stackingUpdateFrames);
			max_stack = (int) Random.Range(3, 10);
			while(ReproductedUpdateFrames.Count >= max_stack){
				ReproductedUpdateFrames.Dequeue();
			}
		}
}
