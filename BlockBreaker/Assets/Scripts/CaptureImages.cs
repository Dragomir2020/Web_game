using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CaptureImages : MonoBehaviour {

	public bool grab;
	public Renderer display;

	void OnPostRender(){
		print ("Captures");
		//CaptureScreen ();
	}

	private void CaptureScreen(){
		Texture2D tex = new Texture2D(Screen.width, Screen.height);
		tex.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0);
		tex.Apply();
		byte[] bytes = tex.EncodeToPNG ();
		File.WriteAllBytes (Application.dataPath + "screenshot.png", bytes);
		grab = false;
	}
}
