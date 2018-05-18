using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Leap;

namespace ButtonTask{
	public class LeapStack : Singleton<LeapStack> {
		/* 
		public int max_stack = 10;

		public Queue<Queue<Frame>> ReproductedUpdateFrames = new Queue<Queue<Frame>>();
		public Queue<Queue<Frame>> ReproductedFixedFrames = new Queue<Queue<Frame>>();
		private Queue<Frame> stackingUpdateFrames;
		private Queue<Frame> stackingFixedFrames;

		private bool isStarted = false;

		public void startSave(){
			isStarted = true;
			stackingUpdateFrames = new Queue<Frame>();
			stackingFixedFrames = new Queue<Frame>();
		}

		public void saveUpdateFrame(Frame f){
			stackingUpdateFrames.Enqueue(f);
		}

		public void saveFixedUpdateFrame(Frame f){
			stackingFixedFrames.Enqueue(f);
		}

		public void endSave(){
			if(stackingUpdateFrames.Count == 0 || stackingFixedFrames.Count == 0) return; 
			ReproductedUpdateFrames.Enqueue(stackingUpdateFrames);
			ReproductedFixedFrames.Enqueue(stackingFixedFrames);
			max_stack = (int) Random.Range(3, 10);
			while(ReproductedUpdateFrames.Count >= max_stack){
				ReproductedUpdateFrames.Dequeue();
			}

			while(ReproductedFixedFrames.Count >= max_stack){
				ReproductedFixedFrames.Dequeue();
			}
		}
		*/
	}
}