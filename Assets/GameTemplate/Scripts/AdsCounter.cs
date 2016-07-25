using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Advertisements;

public class AdsCounter : MonoBehaviour {

	int count;

	void Update(){
		
	}



	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
}