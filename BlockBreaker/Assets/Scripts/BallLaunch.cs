using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLaunch : MonoBehaviour {

	private Text level;
	private Paddle paddle;
	private Vector3 paddleToBall;
	private bool gameStarted;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBall = this.transform.position - paddle.transform.position;
		level = GameObject.FindObjectOfType<Text> ();
		GetLevelName ();
		gameStarted = false;
	}

	private void GetLevelName(){
		LevelManager levelM = GameObject.FindObjectOfType<LevelManager> ();
		level.text = "level " + levelM.level.ToString ();
	}

	void OnCollisionEnter2D(Collision2D collision){
		//Play boing audio
		if (gameStarted) {
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			//Move ball along with paddle
			this.transform.position = paddle.transform.position + paddleToBall;
			if (Input.GetMouseButtonDown(0)) {
				gameStarted = true;
				//Shoot ball
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
				level.text = "";
			}
		}

	}
}
