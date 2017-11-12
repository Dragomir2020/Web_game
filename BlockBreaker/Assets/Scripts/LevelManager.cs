using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject Brick1;
	public GameObject Brick2;
	public GameObject Brick3;
	public GameObject NoBreak;
	public GameObject PlaySpace;

	public int level = 0;

	static LevelManager instance = null;

	public void LoadLevel(string name){
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
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
		if (!GameObject.FindObjectOfType<Brick> () && SceneManager.GetActiveScene ().name.Equals ("Levels")) {
			//No more bricks left
			level++;
			LoadNextLevel ();
		}
		if (!GameObject.FindObjectOfType<Brick> () && SceneManager.GetActiveScene ().name.Equals ("Start Menu")) {
			//Have AI play on start menu
			StartMenu();
		}
		if (!GameObject.FindObjectOfType<Brick> () && SceneManager.GetActiveScene ().name.Equals ("Lose Screen")) {
			//Add Brick Border
			AddBrickBorder();
		}
		if (!GameObject.FindObjectOfType<Brick> () && SceneManager.GetActiveScene ().name.Equals ("Win Screen")) {
			//Add Brick Border
			AddBrickBorder();
		}
	}
				
	//Load levels
	private void LoadNextLevel () {
		//Destroy and create new game space each level
		Destroy(GameObject.FindGameObjectWithTag("PlaySpace"));
		Instantiate (PlaySpace, new Vector3 (8f, 3f, 0f), Quaternion.identity);
		//Load Bricks for each level here and add new levels
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

	private void StartMenu(){
		//Render Play Space
		Destroy(GameObject.FindGameObjectWithTag("PlaySpace"));
		Instantiate (PlaySpace, new Vector3 (8f, 3f, 0f), Quaternion.identity);
		//Destroy Image
		Destroy(GameObject.FindGameObjectWithTag("Background"));
		//Load TitleBlocks
		int count = 0;
		for(float j = 11.68f; j > 8; j -= 0.3203f){
			count++;
			for(float i = 0; i < 16; i++){
				if ((count == 1 || count == 12) || (i == 0 || i == 15)) {
					Instantiate (NoBreak, new Vector3 (i, j, -3f), Quaternion.identity);
				}
			}
		}
		//Load Menu Blocks
		/*count = 0;
		for(float j = 6f; j > 4; j -= 0.3203f){
			count++;
			for(float i = 5f; i < 11; i++){
				if ((count == 1 || count == 7) || (i == 5f || i == 10f)) {
					Instantiate (NoBreak, new Vector3 (i, j, -3f), Quaternion.identity);
				}
			}
		}*/
		//Load Breakable Blocks
		count = 0;
		for(float j = 7.8364f; j > 4; j -= 0.3203f){
			for(float i = 0; i < 16; i++){
				if (count % 3 == 0) {
					Instantiate (Brick1, new Vector3 (i, j, -3f), Quaternion.identity);
				} else if (count % 3 == 1) {
					Instantiate (Brick2, new Vector3 (i, j, -3f), Quaternion.identity);
				} else {
					Instantiate (Brick3, new Vector3 (i, j, -3f), Quaternion.identity);
				}
				count++;
			}
		}

		//Turn on basic AI for home screen
		GameObject.FindObjectOfType<Paddle>().autoPlay = true;
	}

	private void AddBrickBorder(){
		//Render Play Space
		Destroy(GameObject.FindGameObjectWithTag("PlaySpace"));
		Instantiate (PlaySpace, new Vector3 (8f, 3f, 0f), Quaternion.identity);
		//Destroy Image
		Destroy(GameObject.FindGameObjectWithTag("Background"));
		Destroy(GameObject.Find("Paddle"));
		Destroy(GameObject.Find("Ball"));
		int count = 0;
		for(float j = 11.68f; j > -1; j -= 0.3203f){
			count++;
			for(float i = 0; i < 16; i++){
				if ((count == 1 || count == 38) || (i == 0 || i == 15)) {
					Instantiate (NoBreak, new Vector3 (i, j, -3f), Quaternion.identity);
				}
			}
		}
	}

}
