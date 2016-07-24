using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour {

	public GameObject pause;
	public AudioSource audioSource;
	public GameObject player;


	public void menuPause( ){
		
		pause.SetActive (true);
		Time.timeScale = 0;
		audioSource.Pause ();
		player.SetActive (false);
			
	}

	public void continueGame(){
		pause.SetActive (false);
		Time.timeScale = 1;
		audioSource.Play ();
		player.SetActive (true);
	}

	public void backHome(){
		SceneManager.LoadScene ("Menu");
		Time.timeScale = 1;
	}
}
