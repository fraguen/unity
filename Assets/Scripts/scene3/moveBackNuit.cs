using UnityEngine;
using System.Collections;

public class moveBackNuit : MonoBehaviour {
	
	public float positionRestartX;
	Vector2 movement = new Vector2 (-2f, 0f);
	Vector2 siz;
	Vector3 leftBottomCameraBorder, rightBottomCameraBorder;
	float pos = -99;
	public GameObject nuageSmallGrey, nuageNormalGrey;
	private int randomNuageGenerator;
	private int frameCount = 0;

	
	
	void Start(){
		siz.x =	gameObject.GetComponent<SpriteRenderer>	().bounds.size.x * transform.localScale.x;	
		siz.y =	gameObject.GetComponent<SpriteRenderer>	().bounds.size.y * transform.localScale.y;	
		
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3 (1, 0, 0));
		randomNuageGenerator = (int)generateRandom (500f, 1000f);

		
	}
	
	void Update()	
	{	
		if(!ScoreManager.instance.isOnGameOver()){
			frameCount++;
			if(gameObject.tag == "back")
				rigidbody2D.velocity = movement;	
			else if(gameObject.tag == "sol")
				rigidbody2D.velocity = new Vector2(-5f, 0f);
			if(frameCount == randomNuageGenerator){
				frameCount = 0;
				generateNuage((int)generateRandom(1,100));
				randomNuageGenerator = (int)generateRandom(500f, 1000f);
			}
		}
		else{
			rigidbody2D.velocity = new Vector2(0f, 0f);
		}
		
		//	Si	le	sprite	sort	de	l'écran	à	gauche	
		//	Recalcul	d'une	nouvelle	posi=on	en	Y	comprise	dans	les	limites	autorisées	de	l'écran
		//Reposi=onnement	en	X		à	la	posi=on	d’origine	de	bacGround3	
		
		if	(transform.position.x <	leftBottomCameraBorder.x - (siz.x /	2))	
		{	
			if(gameObject.tag == "back"){
				GameObject[] backGrounds = GameObject.FindGameObjectsWithTag("back") as GameObject[];
				foreach (GameObject backGround in backGrounds) {
					float currPos = backGround.transform.position.x;
					//Debug.Log("currPos : " + currPos);
					if(currPos > pos){
						//Debug.Log("currPos > pos : pos=" + pos + ", currPos=" + currPos);
						pos = currPos;
						positionRestartX = currPos+siz.x/2-.6f;
					}
				}
				transform.position	= new Vector3(positionRestartX,transform.position.y,transform.position.z);	
				//Debug.Log("PositionRestart : " + positionRestartX);
			}
			else if(gameObject.tag == "sol"){
				GameObject[] sols = GameObject.FindGameObjectsWithTag("sol") as GameObject[];
				foreach (GameObject sol in sols) {
					float currPos = sol.transform.position.x;
					//Debug.Log("currPos : " + currPos);
					if(currPos > pos){
						//Debug.Log("currPos > pos : pos=" + pos + ", currPos=" + currPos);
						pos = currPos;
						positionRestartX = currPos+siz.x/2 -.6f;
					}
				}
				transform.position	= new Vector3(positionRestartX,transform.position.y,transform.position.z);	
				//Debug.Log("PositionRestart : " + positionRestartX);
			}
		}	
	}

	float generateRandom(float start, float end){
		return Random.Range (start, end);
	}

	void generateNuage(int type){

		Vector2 mouvement = new Vector2(-5f, 0f);

		if(type%2 != 0){
			float posNuageY =  generateRandom(0f, 7f);
			float posNuageX = rightBottomCameraBorder.x + nuageSmallGrey.GetComponent<SpriteRenderer>().bounds.size.x;
			GameObject nuage = Instantiate (nuageSmallGrey, new Vector3 (posNuageX, posNuageY, nuageSmallGrey.transform.position.z), Quaternion.identity) as GameObject;
			nuage.rigidbody2D.velocity = mouvement;
		}
		else{
			float posNuageY =  generateRandom(0f, 7f);
			float posNuageX = rightBottomCameraBorder.x + nuageNormalGrey.GetComponent<SpriteRenderer>().bounds.size.x;
			GameObject nuage = Instantiate (nuageNormalGrey, new Vector3 (posNuageX, posNuageY, nuageNormalGrey.transform.position.z), Quaternion.identity) as GameObject;
			nuage.rigidbody2D.velocity = mouvement;
		}
	}
}

