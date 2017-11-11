using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private BallLaunch ball;
	private bool launchBall = false;
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AI ();
		}
	}

	void Start(){
		ball = GameObject.FindObjectOfType<BallLaunch> ();
	}

	private void MoveWithMouse(){
		float posInBlocks = Input.mousePosition.x / 800 * 16;
		this.gameObject.transform.position = new Vector3 (Mathf.Clamp (posInBlocks, 0f, 14.5f), this.transform.position.y, -5.0f);
	}

	private void AI(){
		//Only do once
		if (!launchBall) {
			GameObject.FindObjectOfType<BallLaunch>().LaunchBall();
			launchBall = true;
		}
		float ballPos = ball.transform.position.x;
		this.gameObject.transform.position = new Vector3 (Mathf.Clamp (ballPos - 0.75f, 0f, 14.5f), this.transform.position.y, -5.0f);
	}
}
