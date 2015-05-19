using UnityEngine;
using System.Collections;

public class touchButtonPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter2D(Collider2D collider){

		if (Input.touchCount > 0) {
			Touch p = Input.GetTouch(0);
			if(p.phase == TouchPhase.Ended){
				Debug.Log("Appui sur le boutton play!");
				Application.LoadLevel("scene3");
			}
		}
		
		else if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Appui sur le boutton play!");
			Application.LoadLevel("scene3");
		}

	}

}
