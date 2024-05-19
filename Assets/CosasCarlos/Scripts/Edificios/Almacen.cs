using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public enum AlmacenUI
{
    None = 0,
    Active = 1,
    Modal = 2
}

public class Almacen : MonoBehaviour
{

    //Data
    [SerializeField]
    CitySO city;
    public PlayerSO player;
    public Boolean inProperty = false;
    public AlmacenSO almacen;
    InventoryProductSO inventory;

    // UI 
    public ComercioView almacenView;
    public View modalView;
    public CustomButton closeButton;
    private AlmacenUI layer;

    //UI methods
    void Start()
    {
        
        almacenView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        modalView.gameObject.SetActive(false);
        layer = AlmacenUI.None;

    }

    public void showUI()
    {
        //Debug.Log("abroAlmacen");
        almacenView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        modalView.gameObject.SetActive(false);
        layer = AlmacenUI.Active;
    }

    public void showModal()
    {
        //Debug.Log("modal");
        almacenView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        modalView.gameObject.SetActive(true);
        layer = AlmacenUI.Modal;
    }

    public void closeModal()
    {
        modalView.gameObject.SetActive(false);
        layer = AlmacenUI.Active;
    }

    public void ExitView()
    {
        //Debug.Log(layer);

        almacenView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        modalView.gameObject.SetActive(false);
        layer = AlmacenUI.None;
    }

    // Update is called once per frame
    void Update()
    {


    }




    //Transaction methods
    public void Comprar(ServiceSO service)
    {
        SerialService found = city.services.findItem(service);

        if (found != null && found.hasService && !inProperty)
        {
            if(player.playerCurrency.CurrencyQuantity > almacen.precio)
            {
                player.inventoryService.Add(almacen);
                city.services.Add(almacen);
                player.playerCurrency.CurrencyQuantity -= almacen.precio;
                inProperty = true;
                string path = "Assets/Scriptable Objects/" + city.cityName + "/Almacen"+city.AlmacenCount;
                inventory = Instantiate(inventory);
                AssetDatabase.CreateAsset(inventory, path);
                city.AlmacenCount++;
            }
        }else if(found == null || (found != null && !found.hasService)){
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡No tienes la licencia para comerciar!";
            showModal();
        }
        else if(inProperty){
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡Ya tienes este almacen!";
            showModal();
        }   
    }

    public void Vender(ServiceSO service)
    {
        SerialService found = city.services.findItem(almacen);
        SerialService license = city.services.findItem(service);


        if (found != null && license.hasService && inProperty && license != null)
        {
            if (player.playerCurrency.CurrencyQuantity > found.precio)
            {
                player.inventoryService.Add(found.itemInventory);
                city.services.Add(found.itemInventory);
                player.playerCurrency.CurrencyQuantity -= found.precio;
                inProperty = true;
            }
        }
    }
    public void Alquilar(ServiceSO service)
    {
        SerialService found = city.services.findItem(service);

        if (found != null && found.hasService && !inProperty)
        {
            if (player.playerCurrency.CurrencyQuantity > (almacen.precio * 0.3f))
            {
                player.inventoryService.Add(almacen);
                city.services.Add(almacen);
                player.playerCurrency.CurrencyQuantity -= (almacen.precio*0.3f);
                inProperty = true;
                almacen.time = 1;
                string path = "Assets/Scriptable Objects/" + city.cityName + "/Almacen" + city.AlmacenCount;
                inventory = Instantiate(inventory);
                AssetDatabase.CreateAsset(inventory, path);
                city.AlmacenCount++;
            }
        }
        else if (found == null || (found != null && !found.hasService))
        {
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡No tienes la licencia para comerciar!";
            showModal();
        }
        else if (inProperty)
        {
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡Ya tienes este almacen!";
            showModal();
        }
    }

    public void Construir(ServiceSO service)
    {
        SerialService found = city.services.findItem(service);

        if (found != null && found.hasService && !inProperty)
        {
            if (player.playerCurrency.CurrencyQuantity > (almacen.precio * 0.75f))
            {
                player.inventoryService.Add(almacen);
                city.services.Add(almacen);
                player.playerCurrency.CurrencyQuantity -= (almacen.precio * 0.75f);
                inProperty = true;
                almacen.time = 0.5; // ver como gestionar la construccion
                almacen.available = false;
                string path = "Assets/Scriptable Objects/" + city.cityName + "/Almacen" + city.AlmacenCount;
                inventory = Instantiate(inventory);
                AssetDatabase.CreateAsset(inventory, path);
                city.AlmacenCount++;
            }
        }
        else if (found == null || (found != null && !found.hasService))
        {
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡No tienes la licencia para comerciar!";
            showModal();
        }
        else if (inProperty)
        {
            if (!almacen.available) {
                modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡Este almacen esta ocupado por un padre y un hijo!";
                showModal();
            }
            else
            {
                modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡Ya tienes este almacen!";
                showModal();
            }
        }
    }
}
