using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Advertisements;

public class AdsCounter : MonoBehaviour {

	static int reload = 0;
	public GameObject tuto;
	public GameObject player;

	void Start(){
		Reload ();
		timeTuto ();
	}

	public void Reload(){
		while(reload++ % 11 == 10){
			ShowAd ();
		} 
	}


	public void timeTuto(){
		if (SceneManager.GetActiveScene().name == "GameScene" && reload ++ == 1)
		{
			tuto.SetActive (true);
			player.SetActive (false);
			Debug.Log ("scene");
		}
	}

    public void startGame(){
		tuto.SetActive (false);
		player.SetActive (true);
	}
		
	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
}