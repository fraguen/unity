using UnityEngine;
using System.Collections;

public class movePipes : MonoBehaviour {
	public Vector2 mouvement;
	public GameObject pipe1Up;
	public GameObject pipe1Down;
	public GameObject betweenPipes;
	public GameObject plante;
	private Transform pipe1UpOriginalTransform;
	private Transform pipe1DownOriginalTransform;
	private Transform betweenPipesTransform;
	private Transform planteTransform;

	private	Vector3	coinBasGauche;
	private	Vector3	coinBasDroit;
	private	Vector3	coinHautGauche;
	private	Vector3	coinHautDroit;
	private Vector3	coinHautGaucheCamera;
	private Vector3	siz;
	private float horsCadre=4;

	// Use this for initialization
	void Start () {
		mouvement = new Vector2 (-2f, 0f);

		//limite écran
		coinBasGauche = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		coinBasDroit=Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));

		pipe1UpOriginalTransform = pipe1Up.transform;
		pipe1DownOriginalTransform = pipe1Down.transform;
		betweenPipesTransform = betweenPipes.transform;
		float posYPlante = pipe1Down.transform.position.y + pipe1Down.GetComponent<SpriteRenderer> ().bounds.size.y / 2 + plante.GetComponent<SpriteRenderer> ().bounds.size.y / 2;
		Vector3 tmpPos = new Vector3 (plante.transform.position.x, posYPlante, plante.transform.position.z);
		plante.transform.position = tmpPos;
	}
	
	// Update is called once per frame
	void Update () {
		if(!ScoreManager.instance.isOnGameOver()){
			pipe1Up.rigidbody2D.velocity = mouvement;
			pipe1Down.rigidbody2D.velocity = mouvement;
			betweenPipes.rigidbody2D.velocity = mouvement;
			plante.rigidbody2D.velocity = mouvement;
		}
		else{
			mouvement = new Vector2(0f, 0f);
			pipe1Up.rigidbody2D.velocity = mouvement;
			pipe1Down.rigidbody2D.velocity = mouvement;
			betweenPipes.rigidbody2D.velocity = mouvement;
			plante.rigidbody2D.velocity = mouvement;
		}
		siz.x =	pipe1Up.GetComponent<SpriteRenderer>().bounds.size.x;
		siz.y =	pipe1Up.GetComponent<SpriteRenderer>().bounds.size.y;
		if (pipe1Up.transform.position.x < coinBasGauche.x - (siz.x / 2)) {
			moveToRightPipe ();
		}
		/*if (transform.position.x < coinHautGauche.x || transform.position.x < coinBasGauche.x) {
			transform.position=new Vector3(horsCadre,transform.position.y,transform.position.z);
		}*/
	}

	void moveToRightPipe(){
		float randomY =	Random.Range(1,4)-2;
		float posX =coinBasDroit.x+(siz.x/2);
		float posY = pipe1UpOriginalTransform.position.y+randomY;
		float posYPlante;

		Vector3	tmpPos = new Vector3(posX, posY, pipe1Up.transform.position.z);
		pipe1Up.transform.position = tmpPos;

		posY = pipe1DownOriginalTransform.position.y+randomY;
		tmpPos = new Vector3(posX,posY,pipe1Down.transform.position.z);
		pipe1Down.transform.position = tmpPos;

		posY = (pipe1Up.transform.position.y + pipe1Down.transform.position.y) / 2;
		tmpPos = new Vector3(posX,posY,betweenPipes.transform.position.z);
		betweenPipes.transform.position = tmpPos;

		posYPlante = pipe1Down.transform.position.y + pipe1Down.GetComponent<SpriteRenderer> ().bounds.size.y / 2 + plante.GetComponent<SpriteRenderer> ().bounds.size.y / 2;
		tmpPos = new Vector3 (posX, posYPlante, plante.transform.position.z);
		plante.transform.position = tmpPos;

	}
}
