using UnityEngine;
using System.Collections;

public class touchAction : MonoBehaviour {
	//private Vector3	siz;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	/* Afin d'avoir des saut à chaque fois que l'on appuie sans obligation d'etre dans une nouvelle frame*/ 
	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.Space) == true) {
				//print ("Space pressed");
				Vector2 pulse = new Vector2 (0, speed);
				gameObject.rigidbody2D.velocity = pulse;
		}
		else if(Input.touchCount > 0){
			Touch p = Input.GetTouch(0);
			if(p.phase == TouchPhase.Ended){
				Vector2 pulse = new Vector2 (0, speed);
				gameObject.rigidbody2D.velocity = pulse;
			}
		}

	}
}
