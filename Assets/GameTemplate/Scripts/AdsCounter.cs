using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Advertisements;

public class AdsCounter : MonoBehaviour {

	static int reload;
	public GameObject GameOver;

	void Start(){
		Reload ();
		Reload ();
		Reload ();
		Reload ();
	}

	public void Reload(){
		if (reload++ % 10 == 0) {
			GameOver.SetActive (true);
			ShowAd ();
		} else {
			Debug.Log ("ads");
		}
	}

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
}