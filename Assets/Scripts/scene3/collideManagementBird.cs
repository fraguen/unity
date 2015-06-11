using UnityEngine;
using System.Collections;

public class collideManagementBird : MonoBehaviour {

	Vector3 coinHautDroit;
	float sizY;
	bool collisionPipe = false, collisionSol = false, collisionTopScreen = false;
	GUIText GUIscore;
	string score;

	// Use this for initialization
	void Start () {
	
		coinHautDroit = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
		sizY =	gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
		GUIscore = GameObject.FindObjectOfType<GUIText> ();
		score = ScoreManager.instance.getScore ().ToString ();
		GUIscore.text = score;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collisionPipe || collisionTopScreen){
			if(!collisionSol){
				rotationBird(gameObject);
			}
		}
		if(collisionSol){
			if(GetComponent<touchAction>() != null)
				Destroy(GetComponent<touchAction>());
			rigidbody2D.velocity = new Vector2(0, 0);
			transform.Rotate(0, 0, 0);
			rigidbody2D.gravityScale = 0;
			rigidbody2D.mass = 0;
			ScoreManager.instance.gameOver(true);
			StartCoroutine(WaitForLoadGameOverScreen());

			//Application.LoadLevel("scene4");
			//Time.timeScale =  0f;
		}
		if(gameObject.transform.position.y - sizY/2 > coinHautDroit.y ){
			collisionTopScreen = true;
			Destroy(GetComponent<touchAction>());
		}
	}

	void OnTriggerEnter2D(Collider2D colider) {
		if (colider.tag == "pipe" && !collisionPipe) {
			AudioSource audio = GameObject.FindGameObjectWithTag("hit").GetComponent<AudioSource>();
			AudioManager.instance.playSong(audio);
			print ("colision!");
			collisionPipe = true;
			// Detruis le script touchAction 
			Destroy(GetComponent<touchAction>());
		}
		if (colider.tag == "sol" && !collisionSol) {
			collisionSol = true;
			AudioSource audio = GameObject.FindGameObjectWithTag("die").GetComponent<AudioSource>();
			AudioManager.instance.playSong(audio);
		}

		if (colider.tag == "betweenPipes") {
			if(!collisionPipe && !collisionSol && !collisionTopScreen){
				ScoreManager.instance.addScore(1);
				print(ScoreManager.instance.getScore());
				score = ScoreManager.instance.getScore().ToString();
				GUIscore.text = score;
			}
		}
	}

	void rotationBird(GameObject bird){
		float zRota = bird.transform.rotation.z - 10;
		bird.transform.Rotate(0, 0, zRota);
		//print (bird.transform.rotation.z);
	}

	IEnumerator WaitForLoadGameOverScreen () 
	{
		yield return new WaitForSeconds(2);
		Application.LoadLevel(3);
		ScoreManager.instance.gameOver (false);

	}
}
