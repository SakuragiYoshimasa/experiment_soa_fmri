using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ButtonTask;

public class Frame {
	public Vector2 pos;
	public float time;

	public Frame(Vector2 p, float t){
		pos = p;
		time = t;
	}
}

public class JoystickBase : MonoBehaviour {

	[SerializeField]
	private float amp = 1.0f;

	public float delay = 0.0f;
	public bool isReproduction = false;
	public bool stacking = false;

	Queue<Frame> frameQueue = new Queue<Frame>();
	Queue<Frame> reprFrameQueue = new Queue<Frame>();
	Frame frame = null;
	float prevReprTime;

	void Update () {

		float x = InputHolder.I.joystckAxis.x;
		float y = InputHolder.I.joystckAxis.y;
		float time = Time.time;

		if((new Vector2(x, y)).sqrMagnitude > 0.95){
			InputHolder.I.TouchedPanelIndex = 1;
			//TODO FIX IF NEEDED
		}

		//Debug.Log(time);

		if(isReproduction){
			if(frame == null) {
				frame = reprFrameQueue.Dequeue();
				prevReprTime = Time.time;
			} else {
				
				//while((reprFrameQueue.Count > 0) && ((reprFrameQueue.Peek().time - frame.time) < (Time.time - prevReprTime))){
				//frame = reprFrameQueue.Dequeue();	
				//} TODO FIX
				if(reprFrameQueue.Count > 0) frame = reprFrameQueue.Dequeue();

				prevReprTime = Time.time;
			}
		}else{
		
			frameQueue.Enqueue(new Frame(new Vector2(x, y), time));
			while(frameQueue.Count > 0){
				if(Time.time - frameQueue.Peek().time > (delay / 1000.0f)){
					frame = frameQueue.Dequeue();
				} else { break; }
			}
		}

		if(stacking){
			InputStack.I.saveUpdateFrame(new Frame(new Vector2(x, y), time));
		}
		if(isReproduction) Debug.Log(frame.time);
		if(frame == null) return;

		transform.rotation = Quaternion.Euler(frame.pos.y * amp, 0, - frame.pos.x * amp);
	}

	public int setReproductedFrames(){
		int ind = InputStack.I.ReproductedUpdateFrames.Count;
		reprFrameQueue = InputStack.I.ReproductedUpdateFrames.Dequeue();
		frame = null;
		return ind; //何回前のやつを使うかのindexを返す
	}

	public void resetFrameBuffers(){
		frameQueue.Clear();
		reprFrameQueue.Clear();
	}
}
