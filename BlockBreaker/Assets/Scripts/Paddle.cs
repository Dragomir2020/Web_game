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
		//Only Move paddle 0.1 World units each time
		float ballPos = ball.transform.position.x - 0.75f;
		float tolerance = 0.1f;
		float movement = 0.3f;
		if ((this.gameObject.transform.position.x > ballPos) && ((this.gameObject.transform.position.x - ballPos) > tolerance)) {
			if ((this.gameObject.transform.position.x - ballPos) > movement) {
				this.gameObject.transform.position = new Vector3 (Mathf.Clamp (this.gameObject.transform.position.x - movement, 0f, 14.5f), this.transform.position.y, -5.0f);
			} else {
				this.gameObject.transform.position = new Vector3 (Mathf.Clamp (ballPos, 0f, 14.5f), this.transform.position.y, -5.0f);
			}
		}
		if ((this.gameObject.transform.position.x < ballPos) && ((ballPos - this.gameObject.transform.position.x) > tolerance)) {
			if ((ballPos - this.gameObject.transform.position.x) > movement) {
				this.gameObject.transform.position = new Vector3 (Mathf.Clamp (this.gameObject.transform.position.x + movement, 0f, 14.5f), this.transform.position.y, -5.0f);
			} else {
				this.gameObject.transform.position = new Vector3 (Mathf.Clamp (ballPos, 0f, 14.5f), this.transform.position.y, -5.0f);
			}
		}
	}
}
