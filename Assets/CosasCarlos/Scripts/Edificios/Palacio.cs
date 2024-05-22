using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class Palacio : Building
{

    [SerializeField]
    //CitySO city;
    //public PlayerSO player;

    public ComercioView palacioView;
    public CustomButton closeButton;
    public View modalView;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        palacioView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        modalView.gameObject.SetActive(false);

        CustomButton[] buttons = palacioView.GetComponentsInChildren<CustomButton>();
        ServiceSO licencia = AssetDatabase.LoadAssetAtPath<ServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Licencia_Comercio.asset");
        buttons[0].onClick.AddListener(delegate { comprarLicencia(licencia); }) ;
        licencia = AssetDatabase.LoadAssetAtPath<ServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Licencia_Venta.asset");
        buttons[1].onClick.AddListener(delegate { comprarLicencia(licencia); });
        licencia = AssetDatabase.LoadAssetAtPath<ServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Licencia_Salida.asset");
        buttons[2].onClick.AddListener(delegate { comprarLicencia(licencia); });

        closeButton.onClick.AddListener(delegate { exitView(); });


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
