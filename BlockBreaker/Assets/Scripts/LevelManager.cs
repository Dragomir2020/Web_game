using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject Brick1;
	public GameObject Brick2;
	public GameObject Brick3;
	public GameObject PlaySpace;

	public int level = 0;

	static LevelManager instance = null;

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	void Start(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}
	}

	void Update(){
		if (!GameObject.FindObjectOfType<Brick> () && SceneManager.GetActiveScene ().name.Equals("Levels")){
			//No more bricks left
			level++;
			LoadNextLevel();
		}
	}
				
	//Load levels
	void LoadNextLevel () {
		//Destroy and create new game space each level
		Destroy(GameObject.FindGameObjectWithTag("PlaySpace"));
		Instantiate (PlaySpace, new Vector3 (8f, 3f, 0f), Quaternion.identity);
		//Load Bricks for each level
		if (level == 1) {
			Instantiate (Brick1, new Vector3 (7.5f, 8f, -5f), Quaternion.identity);
		}
		if (level == 2) {
			for (int i = 4; i < 12; i += 1) {
				Instantiate (Brick1, new Vector3 (i, 8f, -5f), Quaternion.identity);
				Instantiate (Brick2, new Vector3 (i, 8.5f, -5f), Quaternion.identity);
			}
		}
		if (level == 3) {
			for (int i = 4; i < 12; i += 1) {
				Instantiate (Brick1, new Vector3 (i, 8f, -5f), Quaternion.identity);
				Instantiate (Brick2, new Vector3 (i, 8.5f, -5f), Quaternion.identity);
				Instantiate (Brick3, new Vector3 (i, 9f, -5f), Quaternion.identity);
			}
		}
		if (level == 4) {
			this.LoadLevel ("Win Screen");
		}

	}

}
