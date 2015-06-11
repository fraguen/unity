using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	private static AudioManager _instance;
	public AudioSource source;
	public AudioSource theme;

	public static AudioManager instance{ 
		get{
			if(_instance == null){
				GameObject manager= new GameObject("[AudioManager]");
				_instance = manager.AddComponent<AudioManager>();
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		} 
	}

	void Awake(){
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
			source = GetComponent<AudioSource>();
		}
		else{
			if(this != _instance){
				Destroy(this.gameObject);
			}
		}
	}

	public void playSong(AudioSource source){
		this.source = source;
		this.source.PlayOneShot(source.clip);
	}

	public void playLoop(AudioSource source){
		this.source = source;
		this.source.loop = true;
		this.source.Play();
	}

	public void playTheme(AudioSource theme){
		this.theme = theme;
		this.theme.loop = true;
		this.theme.Play ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
