using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	private int timesHit;
	public Sprite[] hitSprites;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		timesHit = 0;
	}

	void OnCollisionExit2D(Collision2D col){
		timesHit++;
		int MaxHits = hitSprites.Length + 1;
		if (this.tag == "Breakable") {
			AudioSource.PlayClipAtPoint (gameObject.GetComponent<AudioSource> ().clip, transform.position);
		}
		if (timesHit >= MaxHits && this.tag == "Breakable") {
			//Create Smoke instance
			GameObject smokepuff =Instantiate (smoke, this.transform.position, Quaternion.identity); //Instaniate at brick location
			//Play destroy animation
			ParticleSystem.MainModule particle = smokepuff.GetComponent<ParticleSystem> ().main;
			particle.startColor = this.GetComponent<SpriteRenderer> ().color;
			Destroy (this.gameObject);
		} else{
			LoadSprite (timesHit-1);
		}
	}

	private void LoadSprite(int index){
		if (this.tag == "Breakable") {
			if (hitSprites [index] != null) {
				this.GetComponent<SpriteRenderer> ().sprite = hitSprites [index];
			} else {
				Debug.LogError ("Sprite not added to Brick prefab. Add sprite in inspector.");
			}
		}
	}
}
