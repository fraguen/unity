using UnityEngine;
using System.Collections;

public class displayScore : MonoBehaviour {

	GUIText GUIscore;
	string score;

	// Use this for initialization
	void Start () {
		displayScoreOnScreen ();
	
	}
	
	// Update is called once per frame
	void Update () {
		displayScoreOnScreen ();
	}

	void displayScoreOnScreen(){
		GUIscore = GameObject.FindObjectOfType<GUIText> ();
		score = ScoreManager.instance.getScore().ToString();
		GUIscore.text = score;
	}
}
