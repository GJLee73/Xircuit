using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public static GameObject instance;
    void Awake()
    {
        instance = this.gameObject;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (!InAppPurchaser.adRemoved)
        {
            // remove the ad
            InAppPurchaser.BuyProductID(InAppPurchaser.productId1);
        }
        else
        {
           // already removed the ad

        }
    }
}
