using UnityEngine;
using System.Collections;

public class collideManagementBird : MonoBehaviour {

	Vector3 coinBasDroit;
	bool collision = false;

	// Use this for initialization
	void Start () {

		coinBasDroit = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collision) {
			GameObject bird = GameObject.FindGameObjectWithTag("bird");
			if(sortiEcran(bird) == false){
				rotationBird(bird);
			}
			else{
				bird.rigidbody2D.velocity = new Vector2(0, 0);
				bird.transform.Rotate(0, 0, 0);
				bird.rigidbody2D.gravityScale = 0;
				bird.rigidbody2D.mass = 0;
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D colider) {
		if (colider.tag == "bird") {
			print ("colision!");
			collision = true;
			// Detruis le script touchAction 
			Destroy(GetComponent<touchAction>());
		}
	}

	bool sortiEcran(GameObject bird){
		float sizeY =	bird.GetComponent<SpriteRenderer>().bounds.size.y;
		float posY = bird.transform.position.y;
		bool estSorti = false;
		if(posY - sizeY /2 < coinBasDroit.y){
			estSorti = true;
		}
		print (estSorti);
		return estSorti;
	}

	void rotationBird(GameObject bird){
		float zRota = bird.transform.rotation.z - 10;
		bird.transform.Rotate(0, 0, zRota);
		print (bird.transform.rotation.z);
	}
}
