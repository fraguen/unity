using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private int score;
	private bool onGameOver = false;
	private static ScoreManager _instance;

	public static ScoreManager instance{ 
		get{
			if(_instance == null){
				GameObject manager= new GameObject("[ScoreManager]");
				_instance = manager.AddComponent<ScoreManager>();
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		} 
	}

	void Awake(){
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else{
			if(this != _instance){
				Destroy(this.gameObject);
			}
		}
	}

	public void addScore(int score){
		this.score += score;
		GameObject.FindObjectOfType<GUIText> ().text = this.score.ToString();
	}

	public int getScore(){
		return score;
	}

	public void gameOver(bool status){
		this.onGameOver = status;
	}

	public bool isOnGameOver(){
		return this.onGameOver;
	}
}
