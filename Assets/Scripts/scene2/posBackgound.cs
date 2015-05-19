using UnityEngine;
using System.Collections;


public class posBackgound : MonoBehaviour {

	Vector2 siz;
	public SpriteRenderer backGround;


	// Use this for initialization
	void Start () {
		siz.x =	gameObject.GetComponent<SpriteRenderer>	().bounds.size.x * transform.localScale.x;	
		siz.y =	gameObject.GetComponent<SpriteRenderer>	().bounds.size.y * transform.localScale.y;	
		
		SpriteRenderer back2 = Instantiate(backGround, new Vector3(transform.position.x + siz.x/2-.6f, transform.position.y, 0), Quaternion.identity) as SpriteRenderer;
		back2.name = "backGround2";
		SpriteRenderer back3 = Instantiate(backGround, new Vector3(transform.position.x + 2 * (siz.x/2-.6f), transform.position.y, 0), Quaternion.identity) as SpriteRenderer;
		back3.name = "backGround3";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
