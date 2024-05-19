using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Ayuntamiento;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Palacio : MonoBehaviour
{

    [SerializeField]
    CitySO city;
    public PlayerSO player;

    public ComercioView palacioView;
    public CustomButton closeButton;
    public View modalView;


    // Start is called before the first frame update
    void Start()
    {
        palacioView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        modalView.gameObject.SetActive(false);
    }

    public void showUI()
    {
        palacioView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        modalView.gameObject.SetActive(false);
    }

    public void showModal()
    {
        modalView.gameObject.SetActive(true);
    }

    public void closeModal()
    {
        modalView.gameObject.SetActive(false);
    }


    public void exitView()
    {
        palacioView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        modalView.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void comprarLicencia(ServiceSO service)
    {
        SerialService found = city.services.findItem(service);

        if (found != null && found.hasService == false)
        {
            if (player.playerCurrency.CurrencyQuantity > found.precio)
            {
                player.playerCurrency.CurrencyQuantity -= found.precio;
                found.hasService = true;
                player.inventoryService.Add(service);
            }
        }
        else if (found != null && found.hasService == true)
        {
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡Ya tienes esta licencia!";
            showModal();
        }
    }
}
