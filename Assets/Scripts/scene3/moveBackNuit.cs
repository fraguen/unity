using UnityEngine;
using System.Collections;

public class moveBackNuit : MonoBehaviour {
	
	public float positionRestartX;
	Vector2 movement = new Vector2 (-2f, 0f);
	Vector2 siz;
	Vector3 leftBottomCameraBorder;
	float pos = -99;
	
	
	void Start(){
		siz.x =	gameObject.GetComponent<SpriteRenderer>	().bounds.size.x * transform.localScale.x;	
		siz.y =	gameObject.GetComponent<SpriteRenderer>	().bounds.size.y * transform.localScale.y;	
		
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		
	}
	
	void Update()	
	{	
		rigidbody2D.velocity = movement;	
		
		//	Si	le	sprite	sort	de	l'écran	à	gauche	
		//	Recalcul	d'une	nouvelle	posi=on	en	Y	comprise	dans	les	limites	autorisées	de	l'écran
		//Reposi=onnement	en	X		à	la	posi=on	d’origine	de	bacGround3	
		
		if	(transform.position.x <	leftBottomCameraBorder.x - (siz.x /	2))	
		{	
			if(gameObject.tag == "back"){
				GameObject[] backGrounds = GameObject.FindGameObjectsWithTag("back") as GameObject[];
				foreach (GameObject backGround in backGrounds) {
					float currPos = backGround.transform.position.x;
					Debug.Log("currPos : " + currPos);
					if(currPos > pos){
						Debug.Log("currPos > pos : pos=" + pos + ", currPos=" + currPos);
						pos = currPos;
						positionRestartX = currPos+siz.x/2-.6f;
					}
				}
				transform.position	= new Vector3(positionRestartX,transform.position.y,transform.position.z);	
				Debug.Log("PositionRestart : " + positionRestartX);
			}
			else if(gameObject.tag == "sol"){
				GameObject[] sols = GameObject.FindGameObjectsWithTag("sol") as GameObject[];
				foreach (GameObject sol in sols) {
					float currPos = sol.transform.position.x;
					Debug.Log("currPos : " + currPos);
					if(currPos > pos){
						Debug.Log("currPos > pos : pos=" + pos + ", currPos=" + currPos);
						pos = currPos;
						positionRestartX = currPos+siz.x/2-.6f;
					}
				}
				transform.position	= new Vector3(positionRestartX,transform.position.y,transform.position.z);	
				Debug.Log("PositionRestart : " + positionRestartX);
			}
		}	
	}	
}

