using UnityEngine;
using System.Collections;

public class pettingScript : MonoBehaviour {
	public bool isEating;
	public bool isPet = false;
	public float endPetTime;
	public GameObject mouthObj;
	// Use this for initialization
	void Start () {
		isEating = mouthObj.GetComponent<eatScript> ().isEating;
	}
	
	// Update is called once per frame
	void Update () {
		//If Pikachu is being pet and isn't eating
		if (isPet && !isEating) {
			//Let the pikachuTexControl script know what texture to use while Pikachu is being pet and start counting down on the petting timer
			GetComponentInParent<pikachuTexControl>().isPet = true;
			endPetTime -= Time.deltaTime;
		}
		if (endPetTime <= 0.0f) {
			GetComponentInParent<pikachuTexControl>().isPet = false;
		}
	}
	void OnTriggerEnter(Collider collision) {
		//If Pikachu isn't eating and the hand model (must have a hand tag) is colliding with the sphere collider inside Pikachu's head
		if (!isEating && collision.tag == "hand") {
			//Flip the petting flag in Update() so the pikachuTexControl script knows what to do with the textures
			isPet = true;
			//Reset the petting timer
			endPetTime = 1.25f;
			//Play the petting sound effect from the hand script
			collision.GetComponent<handScript> ().playHandSound ();
			//Reset the animation timer in the pikachuTexControl script so that Pikachu won't start an animation during petting
			GetComponentInParent<pikachuTexControl>().animTimer = Random.Range(4.0f, 5.5f);
		}
	}
	void OnTriggerExit(Collider collision) {
		if(!isEating && collision.tag == "hand"){
			isPet = true;
			endPetTime = 1.25f;
			//This isn't needed, thought it played the sound effect too many times. Up to you.
			//collision.GetComponent<handScript> ().playHandSound ();
		}
	}
}
