using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int MaxHits;
	private int timesHit;
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}

	void OnCollisionExit2D(Collision2D col){
		timesHit++;
		if (timesHit >= MaxHits) {
			Destroy (this.gameObject);
		} else if (timesHit == 1) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [0];
		} else if (timesHit == 2) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [1];
		}
	}
}
