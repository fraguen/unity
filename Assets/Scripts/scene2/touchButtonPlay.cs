using UnityEngine;
using System.Collections;

public class touchButtonPlay : MonoBehaviour {
	
	Vector3 siz;
	Vector3 posButton;

	// Use this for initialization
	void Start () {
		posButton = transform.position;
		siz = GetComponent<SpriteRenderer> ().bounds.size;
	}
	
	// Update is called once per frame
	void Update () {

		if(detectButtonPressed ()){
			Application.LoadLevel(1);
		}

/*		if (Input.GetMouseButtonDown(0)){
			Vector3 pos =  Input.mousePosition;
			Debug.Log("Mouse pressed " + pos);
			Ray ray = Camera.main.ScreenPointToRay(pos);
			if(ray.origin.x <= buttonPosition.origin.x && ray.origin.y <= buttonPosition.origin.y)
			{
				Debug.Log("Something hit");
			}
		}
		*/
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Clique");
		if (Input.touchCount > 0) {
			Touch p = Input.GetTouch(0);
			if(p.phase == TouchPhase.Ended){
				Debug.Log("Appui sur le boutton play!");
				Application.LoadLevel(1);
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Appui sur le boutton play!");
			Application.LoadLevel(1);
		}

	}

	public bool detectButtonPressed(){
		bool pressed = false;
		if (Input.GetMouseButtonDown (0)) {
			Vector3 pos =  Input.mousePosition;
			Debug.Log("Mouse pressed " + pos);
			Ray ray = Camera.main.ScreenPointToRay(pos);
			float moussePosX = ray.origin.x;
			float moussePosY = ray.origin.y;
			if(moussePosX >= (posButton.x - siz.x/2) && moussePosX <= (posButton.x + siz.x/2)){
				if( moussePosY >= (posButton.y - siz.y/2) && moussePosY <= (posButton.y + siz.y/2)){
					pressed = true;
				}
			}
		}
		else if(Input.touchCount > 0){
			Touch p = Input.GetTouch(0);
			Vector3 touchPosition = p.position;
			Debug.Log(touchPosition);
			Ray ray = Camera.main.ScreenPointToRay(touchPosition);
			float touchPosX = ray.origin.x;
			float touchPosY = ray.origin.y;
			if(p.phase == TouchPhase.Ended){
				if(touchPosX >= (posButton.x - siz.x/2) && touchPosX <= (posButton.x + siz.x/2)){
					if( touchPosY >= (posButton.y - siz.y/2) && touchPosY <= (posButton.y + siz.y/2)){
						pressed = true;
					}
				}
			}
		}
		return pressed;

	}

}
