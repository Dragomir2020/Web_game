using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	private int timesHit;
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}

	void OnCollisionExit2D(Collision2D col){
		timesHit++;
		int MaxHits = hitSprites.Length + 1;
		//if (GameObject.FindObjectsOfType<Brick> ().Length != 1) {
			AudioSource.PlayClipAtPoint (gameObject.GetComponent<AudioSource> ().clip, transform.position);
		//}
		if (timesHit >= MaxHits) {
			Destroy (this.gameObject);
		} else{
			LoadSprite (timesHit-1);
		}
	}

	private void LoadSprite(int index){
		if (this.tag == "Breakable") {
			if (hitSprites [index]) {
				this.GetComponent<SpriteRenderer> ().sprite = hitSprites [index];
			}
		}
	}
}
