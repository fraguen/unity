using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private int score;
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
	}

	public int getScore(){
		return score;
	}
}
