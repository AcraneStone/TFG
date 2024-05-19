using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public currencySO mycurrency;
    public CurrencyUI mycurrencyUI;

    public void Start()
    {
        CurrencyUI obj = Instantiate(mycurrencyUI);
        obj.currency = this;
        obj.transform.SetParent(this.gameObject.transform, false);
        obj.currencyText = obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        mycurrencyUI = obj;
    }


    //public void Update()
    //{

    //    mycurrencyUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = mycurrency.CurrencyQuantity.ToString();

    //}
    public void SetupItemListUI()
    {
        //GameObject newRow = Instantiate(rowPrefab, scroll);

        


    }
}
