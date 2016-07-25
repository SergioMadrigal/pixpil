using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public GameObject shop;
	public GameObject music;
	//public GameObject menu;
	//public AudioSource audioSource;
	
	// Update is called once per frame
	void Update () {
		if (shop.activeInHierarchy) {
			music.SetActive (false);
		} else {
			music.SetActive (true);
		}
    }
}
