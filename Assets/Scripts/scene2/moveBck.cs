using UnityEngine;
using System.Collections;

public class moveBck : MonoBehaviour {

	public float positionRestartX;
	Vector2 movement = new Vector2 (-2f, 0f);
	Vector2 siz;
	Vector3 leftBottomCameraBorder;
	SpriteRenderer backGround;
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
			SpriteRenderer[] sprites = FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
			foreach (SpriteRenderer sprite in sprites) {
				float currPos = sprite.transform.position.x;
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
