using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int MaxHits;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}

	void OnCollisionEnter2D(Collision2D col){
		timesHit++;
		if (MaxHits == timesHit) {
			Destroy (this.gameObject);
		}
	}
}
