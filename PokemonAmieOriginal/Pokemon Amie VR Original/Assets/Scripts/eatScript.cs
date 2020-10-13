using UnityEngine;
using System.Collections;

public class eatScript : MonoBehaviour {
	public bool isEating;
	public bool triggerEat;
	public Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * I don't remember why I commented this out but it's probably a good idea to leave it commented.
		if (isEating) {
			animator.Play ("startEating");
			isEating = false;
		}
		*/
	}

	void OnTriggerEnter(Collider collision) {
		//If a poffin collides with the mouth collider and we're not in the middle of an animation other than the idle animation
		if (collision.gameObject.tag == "poffin" && animator.GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
			//Set the eating flag and play the eating animation
			isEating = true;
			//Debug.Log ("Eating a poffin");
			animator.Play ("startEating");
		} else {
			isEating = false;
		}
	}
	void OnTriggerStay(Collider collision){
		if (collision.gameObject.tag == "poffin"){
			// The following code is used to keep Pikachu from eating the poffin way too fast.
			// If 1.5 seconds have passed during this animation (assumed to be the eating animation) and pikachu can eat the poffin
			if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1.5f && triggerEat) {
				//Set off the getEaten function inside the poffinScript script and set triggerEat to false.
				collision.GetComponent<poffinScript> ().getEaten ();
				triggerEat = false;
			}
			if (animator.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.5f && !triggerEat) {
				//If the animation started over and triggerEat is false, then flip the triggerEat back to true.
				triggerEat = true;
			}
			// If the poffin has been bitten into three times and triggerEat is true...
			if (collision.GetComponent<poffinScript> ().eatState == 3 && triggerEat) {
				// Play the end of the eating animation and destroy the poffin.
				animator.Play ("endEating");
				Destroy(collision.gameObject);
				Debug.Log ("Destroyed Poffin");
				//Play one of two animations. Make sure to check the behaviors of those animations if you want Pikachu to emit hearts or play a voice line.
				if (Random.Range (0.0f, 1.0f) < 0.5f) {
					animator.Play ("finishEating");
				} else {
					animator.Play ("finishEating1");
				}
			}
		}
	}
	void OnTriggerExit(Collider collision) {
		// If you're cruel and want to take Pikachu's poffin away from him while you're feeding him, then play the end eating animation.
		// Or another animation of your choice, something that can lead into him being angry at you.
		if (collision.gameObject.tag == "poffin") {
			isEating = false;
			animator.Play ("endEating");
		}
	}
}
