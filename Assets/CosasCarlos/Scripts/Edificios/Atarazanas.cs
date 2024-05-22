using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Atarazanas : Building
{

    public enum AtarazanasUI
    {
        None = 0,
        Active = 1,
        List = 2
    }


    public ComercioView atarazanasView;
    public ComercioView listView;
    public CustomButton closeButton;

    public RowProductComercio rowComprar;
    public Transform scroll;

    AtarazanasUI layer;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        CustomButton[] buttons = atarazanasView.GetComponentsInChildren<CustomButton>();
        buttons[0].onClick.AddListener(delegate { comprarView(); });
        buttons[1].onClick.AddListener(delegate { alquilarView(); });
        buttons[2].onClick.AddListener(delegate { venderView(); });
        buttons[3].onClick.AddListener(delegate { repararView(); });

        closeButton.onClick.AddListener(delegate { exitView(); });

        atarazanasView.gameObject.SetActive(false);
        listView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        layer = 0;
        
    }

    public void showUI()
    {
        atarazanasView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        layer = AtarazanasUI.Active;

    }

    public void comprarView()
    {
        atarazanasView.gameObject.SetActive(false);
        listView.gameObject.SetActive(true);
        layer = AtarazanasUI.List;
        //setear precios
    }

    public void alquilarView()
    {
        atarazanasView.gameObject.SetActive(false);
        listView.gameObject.SetActive(true);
        layer = AtarazanasUI.List;

    }

    public void venderView()
    {
        atarazanasView.gameObject.SetActive(false);
        listView.gameObject.SetActive(true);
        layer = AtarazanasUI.List;

    }

    public void repararView()
    {
        atarazanasView.gameObject.SetActive(false);
        listView.gameObject.SetActive(true);
        layer = AtarazanasUI.List;

    }

    public void exitView()
    {
        if(layer == AtarazanasUI.List)
        {
            listView.gameObject.SetActive(false);
            atarazanasView.gameObject.SetActive(true);

        }else if(layer == AtarazanasUI.Active)
        {
            atarazanasView.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SetupItemListComprarUI()
    //{

    //    foreach (Transform item in scroll)
    //    {
    //        Destroy(item.gameObject);
    //    }

    //    foreach (var serial in inventario.inventoryList)
    //    {
    //        RowProductComercio obj = Instantiate(rowComprar, scroll);
    //        obj.hooverView = hooverView;
    //        obj.product = serial.itemInventory;
    //        CityStatsSO.Pair pair = citystats.GetPair(obj.product);
    //        obj.transform.SetParent(scroll, false);
    //        obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = serial.itemInventory.ItemName;
    //        obj.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = setPrecioCompra(pair).ToString("F2");
    //    }
    //}
}
