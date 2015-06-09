using UnityEngine;
using System.Collections;

public class collideManagementBird : MonoBehaviour {

	Vector3 coinBasDroit;
	bool collisionPipe = false, collisionSol = false;

	// Use this for initialization
	void Start () {

		coinBasDroit = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collisionPipe){
			if(!collisionSol){
				rotationBird(gameObject);
			}
			else{
				rigidbody2D.velocity = new Vector2(0, 0);
				transform.Rotate(0, 0, 0);
				rigidbody2D.gravityScale = 0;
				rigidbody2D.mass = 0;
				Time.timeScale =  0f;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D colider) {
		if (colider.tag == "pipe" && !collisionPipe) {
			print ("colision!");
			collisionPipe = true;
			// Detruis le script touchAction 
			Destroy(GetComponent<touchAction>());
		}
		if (colider.tag == "sol" && !collisionSol) {
			collisionSol = true;
		}
	}

	void rotationBird(GameObject bird){
		float zRota = bird.transform.rotation.z - 10;
		bird.transform.Rotate(0, 0, zRota);
		print (bird.transform.rotation.z);
	}
}
