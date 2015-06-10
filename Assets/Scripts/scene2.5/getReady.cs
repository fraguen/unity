using UnityEngine;
using System.Collections;

public class getReady : MonoBehaviour {

	private Vector3 coinSupGauche;
	GameObject back;
	Vector3 backSiz;
	GameObject spriteGetReady;

	// Use this for initialization
	void Start () {

		coinSupGauche = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		back = GameObject.Find("backGroundNuit");
		backSiz = back.GetComponent<SpriteRenderer> ().bounds.size;
		spriteGetReady = GameObject.Find ("getReady");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (back.transform.position.x + (backSiz.x/2) <= coinSupGauche.x) {
			Debug.Log("READY!");
			Application.LoadLevel(2);

		}
	
	}
}
