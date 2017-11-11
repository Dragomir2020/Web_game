using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallLaunch : MonoBehaviour {

	private Text level;
	private Paddle paddle;
	private Vector3 paddleToBall;
	private bool gameStarted;

	static BallLaunch ball = null; //Only Have one ball on screen

	// Use this for initialization
	void Start () {
		if (ball != null) {
			Destroy (gameObject);
		}
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBall = this.transform.position - paddle.transform.position;
		level = GameObject.FindObjectOfType<Text> ();
		if(SceneManager.GetActiveScene ().name.Equals ("Levels")){
			GetLevelName ();
		}
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
		
	void OnCollisionExit2D(Collision2D collision){
		//Randimize ball movement a little
		this.GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)); 
	}
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			//Move ball along with paddle
			this.transform.position = paddle.transform.position + paddleToBall;
			if (Input.GetMouseButtonDown(0)) {
				gameStarted = true;
				//Shoot ball
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
				level.text = "";
			}
		}

	}

	public void LaunchBall(){
		gameStarted = true;
		//Shoot ball
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
		level.text = "";
	}
}
