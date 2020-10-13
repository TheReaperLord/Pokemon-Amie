using UnityEngine;
using System.Collections;

public class poffinScript : MonoBehaviour {
	public int eatState = 0;
	// This is where you hold each state of the eaten poffin. 
	// Each GameObject in this array should be an piece of poffin as a child of the parent poffin, starting with the uneaten poffin first and the subsequent poffin parts after that. 
	// The eaten poffin parts are hidden nicely inside the parent poffin, so you'll never see them.
	public GameObject[] meshStates;

	public bool startEating;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startEating) {
			getEaten ();
			startEating = false;
		}
	}

	// This will hide each part of the poffin as its being eaten, giving the illusion of it being eaten.
	// You can also throw in a particle emitter inside the poffin and play a particle animation for each bite, but I didn't do that this time.
	public void getEaten(){
		switch (eatState) {
		case 0:
			Debug.Log ("Eaten Once");
			meshStates [eatState].SetActive (false);
			eatState += 1;
			break;
		case 1:
			Debug.Log ("Eaten Twice");
			meshStates [eatState].SetActive (false);
			eatState += 1;
			break;
		case 2:
			Debug.Log ("Eaten Three Times");
			meshStates [eatState].SetActive (false);
			//Destroy (this.gameObject);
			eatState += 1;
			break;
		}
	}
}
