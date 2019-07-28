using UnityEngine;
using System;
using UnityEngine.Purchasing;

public class InAppPurchaser : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;
    public static bool adRemoved = false;
    // Start is called before the first frame update
    
    #region 상품 id
    public const string productId1 = "remove_ad"; 

    #endregion

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        //BuyProductID(productId1);
    }

    void Start()
    {
        //adRemoved = (PlayerPrefs.GetInt("adRemoved", 0) == 1);
        
        InitializePurchasing();
        RestorePurchase();
        Product p = storeController.products.WithID(productId1);
        //RestorePurchase();
        if (p!=null && p.hasReceipt)
        {
            //already bought this before
            adRemoved = true;
            PurchaseButton.instance.SetActive(false);
            //GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
        }
    }

    private static bool IsInitialized()
    {
        return (storeController != null && extensionProvider != null);
    }

    public void InitializePurchasing()
    {
        if(IsInitialized())
            return;
        
        var module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        builder.AddProduct(productId1, ProductType.NonConsumable, new IDs
        {
            {productId1, AppleAppStore.Name},
            {productId1, GooglePlay.Name }
        });

        UnityPurchasing.Initialize(this, builder);
    }

    public static void BuyProductID(string productId)
    {
        try
        {
            if (IsInitialized())
            {
                Product p = storeController.products.WithID(productId);

                if (p != null && p.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asynchronously: '{0}'", p.definition.id));
                    storeController.InitiatePurchase(p);
                }
                else
                {
                    Debug.Log("BuyProductId: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }
        catch(Exception e)
        {
            Debug.Log("ButProductID: FAIL. Exception during purchase. " + e);
        }
    }

    public static void RestorePurchase()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not Initialized.");
            return;
        }

        if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = extensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions
                (
                    (result) => { Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore."); }
                );
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported in this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController sc, IExtensionProvider ep)
    {
        Debug.Log("OnInitialized : PASS");

        storeController = sc;
        extensionProvider = ep;
    }

    public void OnInitializeFailed(InitializationFailureReason reason)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason: " + reason);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
        switch (args.purchasedProduct.definition.id)
        {
            case productId1:
                // remove ads
                //GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
                adRemoved = true;
                PurchaseButton.instance.SetActive(false);
                break;
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product Product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}",
                   Product.definition.storeSpecificId, failureReason));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
