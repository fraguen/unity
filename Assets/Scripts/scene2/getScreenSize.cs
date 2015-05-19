using UnityEngine;
using System.Collections;

public class getScreenSize : MonoBehaviour {

	public int screenWidth;
	public int screenHeight;
	public int textWidth;
	public int textHeight;
	public GUIText text;
	public int ratioWidth;
	public int ratioHeigh;
	private double tmp;

	// Use this for initialization
	void Start () {
		int fontSize = text.fontSize;
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		Debug.Log (screenWidth);
		ratioWidth = (int)(screenWidth/176);
		Debug.Log (ratioHeigh);
		Debug.Log (ratioWidth);
		ratioHeigh = (int)(screenHeight/312);
		if (screenWidth < screenHeight) {
			text.fontSize = fontSize * ratioHeigh;
			//Debug.Log("width/height (" + screenWidth + "/" + screenHeight + ") : " + tmp);


		} 
		else {
			text.fontSize = fontSize * ratioWidth;
			//Debug.Log("height/width (" + screenHeight + "/" + screenWidth + ") : " + tmp);
		}
		text.transform.localScale = new Vector3(ratioWidth, ratioHeigh, 1);
	}
	
	// Update is called once per frame
	void Update () {
		/*int fontSize = text.fontSize;
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		ratioWidth = (int)(screenWidth/179);
		ratioHeigh = (int)(screenHeight/318);
		Debug.Log (ratioHeigh);
		Debug.Log (ratioWidth);
		text.fontSize = fontSize * ratioWidth;
		if (screenWidth < screenHeight) {
			//Debug.Log("width/height (" + screenWidth + "/" + screenHeight + ") : " + tmp);

			
		} 
		else {
			//Debug.Log("height/width (" + screenHeight + "/" + screenWidth + ") : " + tmp);
		}
		text.transform.localScale = new Vector3 (ratioWidth, ratioHeigh, 1);*/
	}
}
