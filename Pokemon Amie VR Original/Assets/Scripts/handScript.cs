using UnityEngine;
using System.Collections;

public class handScript : MonoBehaviour {
	public int controllerIndex;
	private string controllerString;

	public AudioClip rub1;
	public AudioClip rub2;
	public AudioClip rub3;
	public AudioClip rub4;

	public AudioClip spawnPoffin;

	public GameObject otherHand;

	// Drop a poffin prefab here in the editor, this is the poffin that will spawn.
	public GameObject puffinToSpawn;

	// Use this for initialization
	void Start () {
		controllerString = GetComponentInParent<SteamVR_TrackedController> ().controllerIndex.ToString ();
		controllerIndex = int.Parse (controllerString);
	}
	
	// Update is called once per frame
	void Update () {
		// I overcomplicate things.
		controllerString = GetComponentInParent<SteamVR_TrackedController> ().controllerIndex.ToString ();
		controllerIndex = int.Parse (controllerString);

		if (SteamVR_Controller.Input (controllerIndex).GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis1).x > 0.1f) {
			//Debug.Log (SteamVR_Controller.Input (controllerIndex).GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis1).x);
			GetComponent<Animator> ().Play ("handAnim", 0, SteamVR_Controller.Input (controllerIndex).GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis1).x - 0.09f);
		} else {
			GetComponent<Animator> ().Play ("handAnim", 0, 0.0f);
		}
		if (SteamVR_Controller.Input (controllerIndex).GetPressDown (Valve.VR.EVRButtonId.k_EButton_ApplicationMenu)) {
			Instantiate (puffinToSpawn, transform.position, transform.rotation);
			GetComponent<AudioSource> ().clip = spawnPoffin;
			GetComponent<AudioSource> ().Play ();
		}
	}

	public void playHandSound(){
		float range = Random.Range (0.0f, 1.0f);
		if (range < 0.25f) {
			GetComponent<AudioSource> ().clip = rub1;
		}
		if (range >= 0.25f && range < 0.5f) {
			GetComponent<AudioSource> ().clip = rub2;
		}
		if (range >= 0.5f && range < 0.75f) {
			GetComponent<AudioSource> ().clip = rub3;
		}
		if (range >= .75f && range <= 1.0f) {
			GetComponent<AudioSource> ().clip = rub4;
		}
		GetComponent<AudioSource> ().Play ();
	}
}
