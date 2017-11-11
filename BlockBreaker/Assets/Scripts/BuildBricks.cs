using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBricks : MonoBehaviour {

	public GameObject Brick1;
	public GameObject Brick2;
	public GameObject Brick3;

	// Use this for initialization
	void Start () {
		for(int i = 4; i < 12; i += 2){
			Instantiate (Brick1, new Vector3(i, 8f, -5f), Quaternion.identity);
			Instantiate (Brick2, new Vector3(i, 8.5f, -5f), Quaternion.identity);

		}

	}

}
