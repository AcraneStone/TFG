using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Puerto : Building
{
    public enum PuertoUI
    {
        None = 0,
        Active = 1,
        Inventario = 2
    }

    public ComercioView puertoView;
    public ComercioView inventarioView;
    Transform scroll;
    public CustomButton closeButton;
    public RowProductComercio row;

    public HooverView hooverView;

    public PuertoUI layer;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        CustomButton[] buttons = puertoView.GetComponentsInChildren<CustomButton>();
        buttons[0].onClick.AddListener(delegate { verInventario(); });
        buttons[1].onClick.AddListener(delegate { verServicios(); });
        buttons[2].onClick.AddListener(delegate { verFlota(); });
        buttons[3].onClick.AddListener(delegate { verAlmacenes(); });
        scroll = inventarioView.transform.Find("scrollContent");

        puertoView.gameObject.SetActive(false);
        inventarioView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        layer = PuertoUI.None;
    }


    public void showUI()
    {
        puertoView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        layer = PuertoUI.Active;
    }


    public void verInventario()
    {
        puertoView.gameObject.SetActive(false);
        inventarioView.gameObject.SetActive(true);
        SetupItemListInventory();
        layer = PuertoUI.Inventario;
    }


    public void verServicios()
    {
        puertoView.gameObject.SetActive(false);
        inventarioView.gameObject.SetActive(true);
        SetupItemListServices();
        layer = PuertoUI.Inventario;
    }

    public void verFlota()
    {
        puertoView.gameObject.SetActive(false);
        inventarioView.gameObject.SetActive(true);
        layer = PuertoUI.Inventario;
    }

    public void verAlmacenes()
    {
        puertoView.gameObject.SetActive(false);
        inventarioView.gameObject.SetActive(true);
        layer = PuertoUI.Inventario;
    }



    // Update is called once per frame
    void Update()
    {

    }


    public void SetupItemListInventory()
    {

        foreach (Transform item in scroll)
        {
            Destroy(item.gameObject);
        }

        foreach (var serial in player.playerInventory.inventoryList)
        {
            RowProductComercio obj = Instantiate(row, scroll);
            obj.hooverView = hooverView;
            obj.product = serial.itemInventory;
            obj.transform.SetParent(scroll, false);
            obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = serial.itemInventory.ItemName;
            obj.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = serial.itemInventory.existencias.ToString();
            if (row.hooverView.gameObject.activeSelf)
            {
                obj.transform.GetComponentInChildren<CustomButton>().onClick.AddListener(delegate { row.exitHoover(); });

            }
            else
            {

                obj.transform.GetComponentInChildren<CustomButton>().onClick.AddListener(delegate { row.showHoover(); });
            }
        }
    }


    public void SetupItemListServices()
    {

        foreach (Transform item in scroll)
        {
            Destroy(item.gameObject);
        }

        foreach (var serial in player.inventoryService.inventoryList)
        {
            RowProductComercio obj = Instantiate(row, scroll);
            obj.hooverView = hooverView;
            //obj.product = serial.itemInventory;
            obj.transform.SetParent(scroll, false);
            obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = serial.itemInventory.ItemName;
            obj.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = serial.itemInventory.city;
            if (row.hooverView.gameObject.activeSelf)
            {
                obj.transform.GetComponentInChildren<CustomButton>().onClick.AddListener(delegate { row.exitHoover(); });

            }
            else
            {

                obj.transform.GetComponentInChildren<CustomButton>().onClick.AddListener(delegate { row.showHoover(); });
            }
        }
    }

    public void SetupItemListAlmacenes()
    {

        foreach (Transform item in scroll)
        {
            Destroy(item.gameObject);
        }

        foreach (var serial in player.inventoryService.inventoryList)
        {
            
            RowProductComercio obj = Instantiate(row, scroll);
            obj.hooverView = hooverView;
            //obj.product = serial.itemInventory;
            obj.transform.SetParent(scroll, false);
            obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = serial.itemInventory.ItemName;
            obj.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = serial.itemInventory.city;
            if (row.hooverView.gameObject.activeSelf)
            {
                obj.transform.GetComponentInChildren<CustomButton>().onClick.AddListener(delegate { row.exitHoover(); });

            }
            else
            {

                obj.transform.GetComponentInChildren<CustomButton>().onClick.AddListener(delegate { row.showHoover(); });
            }
        }
    }
}
