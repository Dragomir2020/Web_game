using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(SceneManager.GetActiveScene ().name.Equals ("Levels")){
		levelManager.LoadLevel ("Lose Screen");
		}
	}
}
