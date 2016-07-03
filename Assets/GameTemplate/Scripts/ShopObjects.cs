using UnityEngine;
using System.Collections;
using InitScriptName;
using System.Collections.Generic;	

public class ShopObjects : MonoBehaviour {
	public GameObject pack;
	public GameObject price;
	public GameObject button;

	void OnMouseUp(){
		Buy ();
	}

	public void Buy(  )
	{

		if( pack.name == "Fish4" )
		{
			//InitScript.waitedPurchaseGems = int.Parse( pack.transform.Find( "Count" ).GetComponent<Text>().text.Replace( "x ", "" ) );
			#if UNITY_WEBPLAYER
			InitScript.Instance.PurchaseSucceded();
			return;
			#endif
			INAPP.Instance.purchaseProduct( "pack1" );
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			price.SetActive(false);
			button.SetActive(false);
			//PlayerPrefs.SetInt ();
		}

		if( pack.name == "Pack2" )
		{
			//InitScript.waitedPurchaseGems = int.Parse( pack.transform.Find( "Count" ).GetComponent<Text>().text.Replace( "x ", "" ) );
			#if UNITY_WEBPLAYER
			InitScript.Instance.PurchaseSucceded();
			return;
			#endif
			INAPP.Instance.purchaseProduct( "pack2" );
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
		}
		if( pack.name == "Pack3" )
		{
			//InitScript.waitedPurchaseGems = int.Parse( pack.transform.Find( "Count" ).GetComponent<Text>().text.Replace( "x ", "" ) );
			#if UNITY_WEBPLAYER
			InitScript.Instance.PurchaseSucceded();
			return;
			#endif
			INAPP.Instance.purchaseProduct( "pack3" );
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
		}
		if( pack.name == "Pack4" )
		{
			//InitScript.waitedPurchaseGems = int.Parse( pack.transform.Find( "Count" ).GetComponent<Text>().text.Replace( "x ", "" ) );
			#if UNITY_WEBPLAYER
			InitScript.Instance.PurchaseSucceded();
			return;
			#endif
			INAPP.Instance.purchaseProduct( "pack4" );
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
		}
	}

}