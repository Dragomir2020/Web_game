using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	//Must be static so only one exists
	static MusicPlayer instance = null;

	// Use this for initialization
	void Start () {
		if (instance != null) {
			//If music player already exists destroy gameObject
			Destroy (gameObject);
		} else {
			//Make sure music player persists between scenes
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
