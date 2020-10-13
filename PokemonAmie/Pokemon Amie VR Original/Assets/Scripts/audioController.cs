using UnityEngine;
using System.Collections;

public class audioController : MonoBehaviour {
	public AudioClip[] voiceClips;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Attach this script to Pikachu and you can call this function from anywhere to play a voice clip.
	public void playVoiceClip(int voiceClipNum){
		GetComponent<AudioSource> ().clip = voiceClips [voiceClipNum];
		GetComponent<AudioSource> ().Play ();
	}
}
