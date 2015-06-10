using UnityEngine;
using System.Collections;

public class deleteStartingBack : MonoBehaviour {

	Vector3 coinSupGauche;
	GameObject back;
	Vector3 siz;

	// Use this for initialization
	void Start () {

		coinSupGauche = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		siz = GetComponent<SpriteRenderer> ().bounds.size;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x + (siz.x/ 2) <= coinSupGauche.x) {
			Destroy(gameObject);
		}
	
	}
}
