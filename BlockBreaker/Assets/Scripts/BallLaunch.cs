using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLaunch : MonoBehaviour {

	public Text level;
	private Paddle paddle;
	private Vector3 paddleToBall;
	private bool gameStarted;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBall = this.transform.position - paddle.transform.position;
		gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			//Move ball along with paddle
			this.transform.position = paddle.transform.position + paddleToBall;
			if (Input.GetMouseButtonDown(0)) {
				gameStarted = true;
				//Shoot ball
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 12f);
				level.text = "";
			}
		}

	}
}
