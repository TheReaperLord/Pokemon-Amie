using UnityEngine;
using System.Collections;

public class pikachuTexControl : MonoBehaviour {
	// We'll need access to Pikachu's textures so we can move them around when we need to.
	// Place these materials in their corresponding slots in the Unity editor.
	public Material eyeMat;
	public Material bodyMat;
	public Material mouthMat;
	public Material cheekMat;

	// For making Pikachu look at you. Optional.
	public GameObject head;
	public GameObject playerHead;
	public float xup;
	public float yup;
	public float zup;

	public float animTimer;

	public bool isPet;

	// This does nothing.
	public bool enableVoice;

	// Use this for initialization
	void Start () {
		// Adjusting the texture offsets is permanent. Setting them all to zero resets them to their defaults.
		// This isn't necessary since Pikachu defaults to his idle animation, but I keep this here to be safe anyway.
		eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
		bodyMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
		mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
		cheekMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));

		// Start the animation timer anywhere between 5.5 and 6.5 seconds.
		animTimer = Random.Range (5.5f, 6.5f);
	}
	
	// Update is called once per frame
	void Update () {
		// This massive chunk of code controls the texture offset of Pikachu's eyes, mouth, body, and cheeks according to which animation Pikachu is in at the moment.
		// You can play around with the texture offsets of Pikachu's materials inside the Unity editor to find out which offsets you want for a specific animation before writing the code for it.
		// The basic template is something like this:

		// if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("currentAnimation")) {
		//		eyeMat.SetTextureOffset ("_MainTex", new Vector2 (x.xf, y.yf));
		//		mouthMat.SetTextureOffset ("_MainTex", new Vector2 (x.xf, y.yf));
		// }
		// Do this for every animation and every texture you want to change the texture offsets for.

		// There's a little trick you can use to set the textures at specific times during the animation.
		// For that you can put an if statement that checks how much time has passed, and if it's greater/less than the specified amount of time, then change the texture offset.
		// This will result in more lively animations. Play around with it and see what works best.

		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("idleHappy")) {
			//Debug.Log ("Idle Happy");
			eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.5f, -0.25f));
			mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("curious")) {
			eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
			mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("hit")) {
			eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
			mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.5f, 0.0f));
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("jumpExcited")) {
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime < 0.25) {
				//eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
				//mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.5f, 0.0f));
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.5f, -0.25f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.5f));
			} else {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.5f, -0.25f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.5f));
			}
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("sleeping")) {
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime < 0.5f) {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.5f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
			} else {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.5f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.5f, 0.0f));
			}
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("sleepToAwake")) {
			eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.25f));
			mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("shakeOff")) {
			//Debug.Log ("hello");
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime < 0.25f) {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
			}
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0.25f && GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime < 0.8f) {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.25f));
			}
			else {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
			}
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("rubOneEye")) {
			//Debug.Log ("hello");
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime < 0.55f) {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
			} else {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.25f));
			}
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("rubEyes")) {
			//Debug.Log ("hello");
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime < 0.6f) {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.25f));
			} else {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.25f));
			}
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("idle") && isPet == false) {
			eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
			mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
		}
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("idle") && isPet == true) {
			eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.5f));
			mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.25f));
		}

		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("eating") && isPet == false) {
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime < 1.5f) {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
			} else {
				eyeMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, 0.0f));
				mouthMat.SetTextureOffset ("_MainTex", new Vector2 (0.0f, -0.25f));
			}
		}
		if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle")) {
			animTimer -= Time.deltaTime;
		}
		if (animTimer <= 0) {
			animTimer = Random.Range(4.0f, 5.5f);
			playRandomAnim ();
		}
	}
	void LateUpdate(){
		// This is something I played around with, where Pikachu will look at you when he's idling.
		// It was cute, but I took it out because I couldn't figure out how to smoothly transition his head from looking at you to his other animations
		// This also gets in the way of trying to feed a poffin to him, since his mouth collider is stuck to his face.
		/*
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
			head.transform.LookAt (playerHead.transform, new Vector3(xup, yup, zup));
		}
		*/
	}

	// This isn't called anywhere as far as I can remember, since changes made here will be overridden in Update().
	// I kept it here just in case though.
	void changeTex(Material mat, float x, float y){
		mat.SetTextureOffset ("_MainTex", new Vector2 (x, y));
		return;
	}
	void playRandomAnim(){
		// There are better ways of doing this. Don't do what I did here for something like this.
		// The random voice clip player in audioController.cs is a much better way of doing this.
		float tempRandom = Random.Range (0.0f, 0.4f);
		if (tempRandom < .1) {
			GetComponent<Animator> ().Play("curious");
		}
		if (tempRandom > .1 && tempRandom < .2) {
			GetComponent<Animator> ().Play("shakeOff");
		}
		if (tempRandom > .2 && tempRandom < .3) {
			GetComponent<Animator> ().Play("rubOneEye");
		}
		if (tempRandom > .3 && tempRandom < .4) {
			GetComponent<Animator> ().Play ("rubEyes");
		}
	}
}
