using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static Aduana;

public class Ayuntamiento : MonoBehaviour
{
    public enum AyuntamientoUI
    {
        None = 0,
        Active = 1,
        Arrendar = 2,
        Licencia = 3
    }

    [SerializeField]
    CitySO city;
    public PlayerSO player;

    public ComercioView licenciasView;
    public ComercioView ayuntamientoView;
    public ComercioView arrendarView;
    public CustomButton closeButton;
    public View modalView;
    public InputRow input;


    //public ServiceSO licencia_tiendas;
    //public ServiceSO licencia_tabernas;

    public bool arrendado = false;

    private AyuntamientoUI layer;
    // Start is called before the first frame update
    void Start()
    {
        if(city.impuestos_arrendados > 0)
        {
            arrendado = true;
        }
        licenciasView.gameObject.SetActive(false);
        ayuntamientoView.gameObject.SetActive(false);
        arrendarView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        modalView.gameObject.SetActive(false);
        layer = AyuntamientoUI.None;  
    }

    public void showUI()
    {
        //Debug.Log("abroAyto");

        licenciasView.gameObject.SetActive(false);
        ayuntamientoView.gameObject.SetActive(true);
        arrendarView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
        layer = AyuntamientoUI.Active;
    }

    public void showLicencias()
    {
        licenciasView.gameObject.SetActive(true);
        ayuntamientoView.gameObject.SetActive(false);
        arrendarView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
        layer = AyuntamientoUI.Licencia;
    }

    public void showArrendar()
    {
        licenciasView.gameObject.SetActive(false);
        ayuntamientoView.gameObject.SetActive(false);
        arrendarView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        layer = AyuntamientoUI.Arrendar;
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
        //Debug.Log(layer);


        if (layer == AyuntamientoUI.Active)
        {
            ayuntamientoView.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
            layer = AyuntamientoUI.None;
        }

        else if (layer == AyuntamientoUI.Licencia)
        {
            licenciasView.gameObject.SetActive(false);
            ayuntamientoView.gameObject.SetActive(true);
            layer = AyuntamientoUI.Active;
        }

        else if(layer == AyuntamientoUI.Arrendar)
        {
            arrendarView.gameObject.SetActive(false);
            ayuntamientoView.gameObject.SetActive(true);
            layer = AyuntamientoUI.Active;
        }

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


    public void ArrendarImpuestos() {

        input.getText();
        if (arrendado)
        {
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡Ya has arrendado impuestos!";
            showModal();
        }
        else if(input.text != "")
        {
            addImpuestos();
        }
    }

    public void addImpuestos()
    {
        
        //string s = transform.Find("CustomInput").GetComponent<TMP_InputField>().text.ToString();
        if(double.TryParse(input.text, out var quantity) && player.playerCurrency.CurrencyQuantity > quantity)
        {
            arrendado = true;
            city.impuestos_arrendados = quantity;
            city.time_impuestos = 1;
            player.playerCurrency.CurrencyQuantity -= (float)quantity;
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Has arrendado " + quantity + " reales";
            showModal();
        }
        else {
            modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "No es válido";
            showModal();
        }
    }
}

