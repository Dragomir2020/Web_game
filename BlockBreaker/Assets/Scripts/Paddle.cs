using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		float posInBlocks = Input.mousePosition.x / 800 * 16;
		this.gameObject.transform.position  = new Vector3(Mathf.Clamp(posInBlocks, 0f, 15f), this.transform.position.y, -5.0f);
	}
}
