using UnityEngine;
using System.Collections;

public class moveNuage : MonoBehaviour {

	private Vector3 leftBottomCameraBorder;
	private Vector2 mouvement;
	private Vector3 siz;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		mouvement = new Vector2 (-5f, 0f);
		rigidbody2D.velocity = mouvement;
		siz = GetComponent<SpriteRenderer> ().bounds.size;
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.x < leftBottomCameraBorder.x) {
			Destroy(gameObject);
		}

	}
}
