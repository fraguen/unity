using UnityEngine;
using System.Collections;

public class touchAction : MonoBehaviour {
	//private Vector3	siz;
	private int jump=1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	/* Afin d'avoir des saut à chaque fois que l'on appuie sans obligation d'etre dans une nouvelle frame*/ 
	void FixedUpdate(){
		if (Input.GetKeyDown ("space")) {
			print ("space key was pressed : y : "+transform.position.y+" before");
			transform.position = new Vector3 (transform.position.x, transform.position.y+jump, transform.position.z);
			
			print ("space key was pressed : y : "+transform.position.y+" after");
		}
	}
}
