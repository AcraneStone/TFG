using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum TabernasUI
{
    None = 0,
    Tabernas = 1,
    Comprar = 2,
    Tripulacion = 3,
    Soldados = 4
}

public class Tabernas : MonoBehaviour
{
    [SerializeField]
    InventoryProductSO inventario;
    CitySO city;
    //[SerializeField]
    /*ublic currencySO currencyPlayer;*/

    public PlayerSO player;

    public CityStatsSO citystats;

    public RowProductComercio rowComprar;

    public Transform scroll;


    public ComercioView posadaView; 
    public ComercioView tripulacionView;
    public ComercioView soldadosView;

    public ComercioView comercioView;
    public CustomButton closeButton;
    public View modalView;
    private TabernasUI layer = TabernasUI.None;



    public void Update()
    {
        //Debug.Log(layer);
    }
    public void Start()
    {
        posadaView.gameObject.SetActive(false);
        comercioView.gameObject.SetActive(false);
        soldadosView.gameObject.SetActive(false);
        tripulacionView.gameObject.SetActive(false);
        modalView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        layer = TabernasUI.None;
    }

    public void showUI()
    {
        posadaView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        layer = TabernasUI.Tabernas;
    }

    public void AccionComprar()
    {
        posadaView.gameObject.SetActive(false);
        comercioView.gameObject.SetActive(true);
        SetupItemListComprarUI();
        layer = TabernasUI.Comprar;
    }

    public void showTripulantes()
    {
        posadaView.gameObject.SetActive(false);
        tripulacionView.gameObject.SetActive(true) ;
        layer = TabernasUI.Tripulacion;
    }


    public void showSoldados()
    {
        posadaView.gameObject.SetActive(false);
        soldadosView.gameObject.SetActive (true) ;
        layer = TabernasUI.Soldados;
    }

    public void showModal()
    {
        modalView.gameObject.SetActive(true);
    }

    public void closeModal()
    {
        modalView.gameObject.SetActive(false);
    }


    public void ExitView()
    {

        if (layer == TabernasUI.Tabernas)
        {
            posadaView.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
            layer = TabernasUI.None;
        }

        else if (layer == TabernasUI.Comprar)
        {
            comercioView.gameObject.SetActive(false);
            posadaView.gameObject.SetActive(true);
            layer = TabernasUI.Tabernas;
        }
        else if (layer == TabernasUI.Tripulacion)
        {
            tripulacionView.gameObject.SetActive(false);
            posadaView.gameObject.SetActive(true);
            layer = TabernasUI.Tripulacion;
        }
        else if (layer == TabernasUI.Soldados)
        {
            soldadosView.gameObject.SetActive(false);
            posadaView.gameObject.SetActive(true);
            layer = TabernasUI.Soldados;
        }

    }


    public void ComprarProducto(ProductsSO item)
    {

        SerialProduct found = inventario.findItem(item);

        if (found != null)
        {
            if (found.stackSize > 1 && player.playerCurrency.CurrencyQuantity >= found.precio)
            {
                player.playerInventory.Add(found.itemInventory);
                inventario.Remove(item);
                player.playerCurrency.CurrencyQuantity -= found.precio;
            }
            else
            {
                if (found.stackSize < 1)
                {
                    modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No hay suficientes " + item.name;
                    showModal();
                }
                else if (player.playerCurrency.CurrencyQuantity < (found.precio * 1))
                {
                    modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No tienes suficiente oro";
                    showModal();
                }
            }
        }

    }

    public void ComprarUno(ProductsSO item)
    {
        SerialProduct found = inventario.findItem(item);

        if (found != null)
        {
            if (found.stackSize > 1 && player.playerCurrency.CurrencyQuantity >= found.precio)
            {
                player.playerInventory.Add(found.itemInventory);
                inventario.Remove(item);
                player.playerCurrency.CurrencyQuantity -= found.precio;
            }
            else
            {
                if (found.stackSize < 1)
                {
                    modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No hay suficientes " + item.name;
                    showModal();
                }
                else if (player.playerCurrency.CurrencyQuantity < (found.precio * 1))
                {
                    modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No tienes suficiente oro";
                    showModal();
                }
            }
        }
    }

    public void ComprarCinco(ProductsSO item)
    {
        SerialProduct found = inventario.findItem(item);

        if (found != null)
        {
            if (found.stackSize >= 5 && player.playerCurrency.CurrencyQuantity >= (found.precio*5))
            {
                player.playerInventory.Add(found.itemInventory, 5);
                inventario.Remove(item, 5);
                player.playerCurrency.CurrencyQuantity -= (found.precio*5);
            }
            else
            {
                if(found.stackSize < 5)
                {
                    modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No hay suficientes "+item.name;
                    showModal();
                }else if(player.playerCurrency.CurrencyQuantity < (found.precio * 5))
                {
                    modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No tienes suficiente oro";
                    showModal();
                }
            }
        }
    }
    public void ComprarDiez(ProductsSO item)
    {
        SerialProduct found = inventario.findItem(item);

        if (found != null)
        {
            if (found.stackSize > 10 && player.playerCurrency.CurrencyQuantity >= (found.precio * 10))
            {
                player.playerInventory.Add(found.itemInventory, 10);
                inventario.Remove(item, 10);
                player.playerCurrency.CurrencyQuantity -= (found.precio * 10);
            }
            else
            {
                if (found.stackSize < 10)
                {
                    modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No hay suficientes " + item.name;
                    showModal();
                }
                else if (player.playerCurrency.CurrencyQuantity < (found.precio * 10))
                {
                    modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No tienes suficiente oro";
                    showModal();
                }
            }
        }
    }


    public void SetupItemListComprarUI()
    {

        foreach (Transform item in scroll)
        {
            Destroy(item.gameObject);
        }

        foreach (var serial in inventario.inventoryList)
        {
            //GameObject newRow = Instantiate(rowPrefab, scroll);
            RowProductComercio obj = Instantiate(rowComprar, scroll);
            //obj.comercio = this;
            obj.product = serial.itemInventory;
            CityStatsSO.Pair pair = citystats.GetPair(obj.product);
            Debug.Log("Hola");
            obj.transform.SetParent(scroll, false);
            obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = serial.itemInventory.ItemName;
            obj.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = setPrecioCompra(pair).ToString();
        }
    }



    public float setPrecioVenta(CityStatsSO.Pair pair)
    {
        float precioFinal = pair.producto.precio;
        float percentage = 1;
        switch (pair.existencias)
        {
            case ItemStats.MuyBajo:
                percentage += 0.33f;
                break;
            case ItemStats.Bajo:
                percentage += 0.16f;
                break;
            case ItemStats.Alto:
                percentage -= 0.16f;
                break;
            case ItemStats.MuyAlto:
                percentage -= 0.33f;
                break;
            default:
                break;
        }

        switch (pair.demanda)
        {
            case ItemStats.MuyBajo:
                percentage += 0.33f;
                break;
            case ItemStats.Bajo:
                percentage += 0.16f;
                break;
            case ItemStats.Alto:
                percentage -= 0.16f;
                break;
            case ItemStats.MuyAlto:
                percentage -= 0.33f;
                break;
            default:
                break;
        }
        switch (pair.produccion)
        {
            case ItemStats.MuyBajo:
                percentage += 0.50f;
                break;
            case ItemStats.Bajo:
                percentage += 0.25f;
                break;
            case ItemStats.Alto:
                percentage -= 0.25f;
                break;
            case ItemStats.MuyAlto:
                percentage -= 0.50f;
                break;
            default:
                break;
        }

        return precioFinal * percentage;
    }


    public float setPrecioCompra(CityStatsSO.Pair pair)
    {
        float precio = setPrecioVenta(pair);
        return precio * 1.25f;
    }
}
