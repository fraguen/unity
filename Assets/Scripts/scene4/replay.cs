using UnityEngine;
using System.Collections;

public class replay : MonoBehaviour {

	private GameObject clickObject;

	// Use this for initialization
	void Start () {
	
		clickObject = new GameObject ("click");
		clickObject.AddComponent<BoxCollider2D>();
		clickObject.tag = "click";
		clickObject.transform.position = new Vector3 (100f, 100f, 0f);

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			if(GameObject.Find("click") == null)
				clickObject = new GameObject("click");
			Ray mousePosRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 mousePos = new Vector3(mousePosRay.origin.x, mousePosRay.origin.y, 0f);
			clickObject.transform.position = mousePos;
		}
		else if(Input.touchCount > 0){
			if(GameObject.Find("click") == null)
				clickObject = new GameObject("click");
			Touch p = Input.GetTouch(0);
			if(p.phase == TouchPhase.Ended){
				Vector3 touchPos = p.position;
				clickObject.transform.position = touchPos;
			}
		}
		else if(Input.GetKeyDown (KeyCode.Space) == true){
			Application.LoadLevel(0);
		}

	}

	void OnTriggerEnter2D(Collider2D colider) {
		if (colider.tag == "click") {
			Application.LoadLevel(0);
		}
	}
}
