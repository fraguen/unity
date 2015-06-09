using UnityEngine;
using System.Collections;


public class posBackNuit : MonoBehaviour {
	
	Vector2 siz;
	public SpriteRenderer backGround;
	public SpriteRenderer sol;
	
	
	// Use this for initialization
	void Start () {
		siz.x =	gameObject.GetComponent<SpriteRenderer>	().bounds.size.x * transform.localScale.x;	
		siz.y =	gameObject.GetComponent<SpriteRenderer>	().bounds.size.y * transform.localScale.y;	

		if (tag == "back") {
			SpriteRenderer back2 = Instantiate (backGround, new Vector3 (transform.position.x + siz.x / 2 - .6f, transform.position.y, transform.position.z), Quaternion.identity) as SpriteRenderer;
			back2.name = "backGround2";
			back2.tag = "back";
			SpriteRenderer back3 = Instantiate (backGround, new Vector3 (transform.position.x + 2 * (siz.x / 2 - .6f), transform.position.y, transform.position.z), Quaternion.identity) as SpriteRenderer;
			back3.name = "backGround3";
			back3.tag = "back";
		} 
		else if (tag == "sol") {
			SpriteRenderer sol2 = Instantiate (sol, new Vector3 (transform.position.x + siz.x / 2 - .6f, transform.position.y, transform.position.z), Quaternion.identity) as SpriteRenderer;
			sol2.name = "sol2";
			sol2.tag = "sol";
			SpriteRenderer sol3 = Instantiate (sol, new Vector3 (transform.position.x + 2 * (siz.x / 2 - .6f), transform.position.y, transform.position.z), Quaternion.identity) as SpriteRenderer;
			sol3.name = "sol3";
			sol3.tag = "sol";

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

