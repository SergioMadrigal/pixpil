using UnityEngine;
using System.Collections;
using OnePF;
using System.Collections.Generic;	

public class ShopObjects : MonoBehaviour {

	public static ShopObjects Instance;

	private bool _processingPayment = false;
	public static bool _purchaseDone = false;
	private bool _showShopWindow = false;
	private string _popupText = "";
	private GameObject[] _joysticks = null;

	private const string STORE_ONEPF = "org.onepf.store";
	const string SKU = "sku";
	const string SKU_Pack1 = "pack1";
	const string SKU_Pack2 = "pack2";
	const string SKU_Pack3 = "pack3";
	const string SKU_Pack4 = "pack4";
	const string SKU_Pack5 = "pack5";
	public GameObject pack1Shop;
	public GameObject pack2Shop;
	public GameObject pack3Shop;
	public GameObject pack4Shop;
	public GameObject pack5Shop;
	public GameObject[] shopItems;

	string _label = "";
	bool _isInitialized = false;

	#region Billing
	private void Awake()
	{
		Instance = this;

		// Listen to all events for illustration purposes
		OpenIABEventManager.billingSupportedEvent += billingSupportedEvent;
		OpenIABEventManager.billingNotSupportedEvent += billingNotSupportedEvent;
		OpenIABEventManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		OpenIABEventManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		OpenIABEventManager.purchaseSucceededEvent += OnPurchaseSucceded;
		OpenIABEventManager.purchaseFailedEvent += purchaseFailedEvent;
		OpenIABEventManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
		OpenIABEventManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
		DontDestroyOnLoad( this );
	}

	private void OnDestroy()
	{
		// Remove all event handlers
		OpenIABEventManager.billingSupportedEvent -= billingSupportedEvent;
		OpenIABEventManager.billingNotSupportedEvent -= billingNotSupportedEvent;
		OpenIABEventManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		OpenIABEventManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		OpenIABEventManager.purchaseSucceededEvent -= OnPurchaseSucceded;
		OpenIABEventManager.purchaseFailedEvent -= purchaseFailedEvent;
		OpenIABEventManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
		OpenIABEventManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
	}

	private void Start()
	{
		// Map skus for different stores       
		OpenIAB.mapSku( SKU, OpenIAB_Android.STORE_GOOGLE, "sku" );
		OpenIAB.mapSku( SKU, OpenIAB_Android.STORE_AMAZON, "sku" );
		OpenIAB.mapSku( SKU, OpenIAB_iOS.STORE, "sku" );
		//    OpenIAB.mapSku( SKU, OpenIAB_WP8.STORE, "sku" );

		OpenIAB.mapSku( SKU_Pack1, OpenIAB_iOS.STORE, "pack1" );
		OpenIAB.mapSku( SKU_Pack2, OpenIAB_iOS.STORE, "pack2" );
		OpenIAB.mapSku( SKU_Pack3, OpenIAB_iOS.STORE, "pack3" );
		OpenIAB.mapSku( SKU_Pack4, OpenIAB_iOS.STORE, "pack4" );
		OpenIAB.mapSku( SKU_Pack5, OpenIAB_iOS.STORE, "pack5" );

		var publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmf0kVFCutMdWCEpDOTJG9YxLpjmyckyThaKUDRhAFtXcO1dURsMynAnE+yRJxs1491cJBtXR2C2R956zl4ZC44IvNHCm3o8+UAEh5DhneEmObMlm7kX/h8GNJpCdxKRX5SGSux6CpnsdpqTa6SpC9sr0C25rNitkXdz1cPNBxZiDoti0Nvdw93nko0YbL3S8NeVLSG7te964Sa19dF8G30t1+YYLlSIvIZ+RylwTAaApxC63BvHV6vHZydGk7ljmXSNjGrHQmLWT8g3eJQSgf9lkdj1+qXZM1W8gN4fnT2pFzf979g+qQGPX2cDPVzT+cT+8zC6cGtoKqw7+LILPcQIDAQAB";

		var options = new Options();
		options.checkInventoryTimeoutMs = Options.INVENTORY_CHECK_TIMEOUT_MS * 2;
		options.discoveryTimeoutMs = Options.DISCOVER_TIMEOUT_MS * 2;
		options.checkInventory = false;
		options.verifyMode = OptionsVerifyMode.VERIFY_SKIP;
		options.prefferedStoreNames = new string[] { OpenIAB_Android.STORE_GOOGLE, OpenIAB_Android.STORE_AMAZON, OpenIAB_Android.STORE_YANDEX};
		options.storeKeys = new Dictionary<string, string> { { OpenIAB_Android.STORE_GOOGLE, publicKey } };
		options.storeSearchStrategy = SearchStrategy.INSTALLER_THEN_BEST_FIT;
		// Transmit options and start the service
		OpenIAB.init( options );

	}


	// Verifies the developer payload of a purchase.
	bool VerifyDeveloperPayload(string developerPayload) {
		/*
         * TODO: verify that the developer payload of the purchase is correct. It will be
         * the same one that you sent when initiating the purchase.
         * 
         * WARNING: Locally generating a random string when starting a purchase and 
         * verifying it here might seem like a good approach, but this will fail in the 
         * case where the user purchases an item on one device and then uses your app on 
         * a different device, because on the other device you will not have access to the
         * random string you originally generated.
         *
         * So a good developer payload has these characteristics:
         * 
         * 1. If two different users purchase an item, the payload is different between them,
         *    so that one user's purchase can't be replayed to another user.
         * 
         * 2. The payload must be such that you can verify it even when the app wasn't the
         *    one who initiated the purchase flow (so that items purchased by the user on 
         *    one device work on other devices owned by the user).
         * 
         * Using your own server to store and verify developer payloads across app
         * installations is recommended.
         */
		return true;
	}

	private void OnBillingSupported() {
		Debug.Log("Billing is supported");
		Invoke("queryInventory",1);
	}

	void queryInventory(){
		OpenIAB.queryInventory();
	}

	private void OnBillingNotSupported(string error) {
		//		Debug.Log("Billing not supported: " + error);
	}

	private void OnQueryInventorySucceeded(Inventory inventory) {
		Debug.Log("Query inventory succeeded: " + inventory);
		foreach (Purchase item in inventory.GetAllPurchases ()) {
			OpenIAB.consumeProduct(item);
		}

	}

	private void OnQueryInventoryFailed(string error) {
		Debug.Log("Query inventory failed: " + error);
	}

	private void OnPurchaseSucceded(Purchase purchase) {
		Debug.Log("Purchase succeded: " + purchase.Sku + "; Payload: " + purchase.DeveloperPayload);

		//MainMap.WasInApp = true;
		PlayerPrefs.SetInt("WasInApp", 1);
		PlayerPrefs.Save();
		_purchaseDone = true;
		//InitScriptName.InitScript.Instance.PurchaseSucceded();
		OpenIAB.consumeProduct(purchase);
		if (!VerifyDeveloperPayload(purchase.DeveloperPayload)) {
			return;
		}

		_processingPayment = false;
	}

	private void OnPurchaseFailed(string error) {
		Debug.Log("Purchase failed: " + error);
		_processingPayment = false;
	}

	private void OnConsumePurchaseSucceeded(Purchase purchase) {
		Debug.Log("Consume purchase succeded: " + purchase.ToString());

	}

	private void OnConsumePurchaseFailed(string error) {
		Debug.Log("Consume purchase failed: " + error);
		_processingPayment = false;
	}

	private void OnTransactionRestored(string sku) {
		Debug.Log("Transaction restored: " + sku);
	}

	private void OnRestoreSucceeded() {
		Debug.Log("Transactions restored successfully");
	}

	private void OnRestoreFailed(string error) {
		Debug.Log("Transaction restore failed: " + error);
	}
	#endregion // Billing

	#region GUI
	public void purchaseProduct(string good){
		_purchaseDone = false;
		OpenIAB.purchaseProduct(good);

	}

	#endregion // GUI

	private void billingSupportedEvent()
	{
		_isInitialized = true;
		Debug.Log( "billingSupportedEvent" );
	}
	private void billingNotSupportedEvent( string error )
	{
		Debug.Log( "billingNotSupportedEvent: " + error );
	}
	private void queryInventorySucceededEvent( Inventory inventory )
	{
		Debug.Log( "queryInventorySucceededEvent: " + inventory );
		if( inventory != null )
			_label = inventory.ToString();
	}
	private void queryInventoryFailedEvent( string error )
	{
		Debug.Log( "queryInventoryFailedEvent: " + error );
		_label = error;
	}
	private void purchaseSucceededEvent( Purchase purchase )
	{
		Debug.Log( "purchaseSucceededEvent: " + purchase );
		_label = "PURCHASED:" + purchase.ToString();
	}
	private void purchaseFailedEvent( int errorCode, string errorMessage )
	{
		Debug.Log( "purchaseFailedEvent: " + errorMessage );
		_label = "Purchase Failed: " + errorMessage;
	}
	private void consumePurchaseSucceededEvent( Purchase purchase )
	{
		Debug.Log( "consumePurchaseSucceededEvent: " + purchase );
		_label = "CONSUMED: " + purchase.ToString();
	}
	private void consumePurchaseFailedEvent( string error )
	{
		Debug.Log( "consumePurchaseFailedEvent: " + error );
		_label = "Consume Failed: " + error;
	}
		
	void OnMouseUp(){
		if (pack1Shop.name == "Fish6")
		{
			Debug.Log("10");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack1");
			shopItems [0].SetActive (false);
			shopItems [1].SetActive (false);
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
		}else if (pack2Shop.name == "Fish7")
		   {
			Debug.Log("20");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack2");
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			shopItems [2].SetActive (false);
			shopItems [3].SetActive (false);
		} else if (pack3Shop.name == "Fish8")
		  {
			Debug.Log("30");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack3");
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			shopItems [4].SetActive (false);
			shopItems [5].SetActive (false);
		}else if (pack4Shop.name == "Fish9")
		  {
			Debug.Log("40");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack4");
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			shopItems [6].SetActive (false);
			shopItems [7].SetActive (false);
		}else if (pack4Shop.name == "Fish10")
		  {
			Debug.Log("50");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack5");
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			shopItems [8].SetActive (false);
			shopItems [9].SetActive (false);
		}
	}
	/*public void Pack1(){
		if (pack1Shop.name == "Fish6")
		{
			Debug.Log("10");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack1");
			shopItems [0].SetActive (false);
			shopItems [1].SetActive (false);
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
		}
	}

	public void Pack2(){
		if (pack2Shop.name == "Fish7")
		{
			Debug.Log("20");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack2");
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			shopItems [2].SetActive (false);
			shopItems [3].SetActive (false);
		}
	}*/

	/*public void Pack3(){
		if (pack3Shop.name == "Fish8")
		{
			Debug.Log("30");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack3");
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			shopItems [4].SetActive (false);
			shopItems [5].SetActive (false);
		}
	}

	public void Pack4(){
		if (pack4Shop.name == "Fish9")
		{
			Debug.Log("40");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack4");
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			shopItems [6].SetActive (false);
			shopItems [7].SetActive (false);
		}
	}

	public void Pack5(){
		if (pack4Shop.name == "Fish10")
		{
			Debug.Log("50");
			#if UNITY_WEBPLAYER
			return;
			#endif
			ShopObjects.Instance.purchaseProduct("pack5");
			//  INAPP.Instance.purchaseProduct("android.test.refunded");
			shopItems [8].SetActive (false);
			shopItems [9].SetActive (false);
		}
	}*/


}
