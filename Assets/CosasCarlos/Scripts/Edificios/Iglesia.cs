using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Ayuntamiento;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Iglesia : Building
{
    public ComercioView iglesiaView;
    public View modalView;
    public CustomButton closeButton;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        closeButton.onClick.AddListener(delegate { exitView(); });

        CustomButton[] buttons = iglesiaView.GetComponentsInChildren<CustomButton>();
        ChurchServiceSO servicio = AssetDatabase.LoadAssetAtPath<ChurchServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Misas_Difuntos.asset");
        servicio.city = city.name;
        buttons[0].onClick.AddListener(delegate { comprarServicio(servicio); });

        servicio = AssetDatabase.LoadAssetAtPath<ChurchServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Misas_Futuro.asset");
        servicio.city = city.name;
        buttons[1].onClick.AddListener(delegate { comprarServicio(servicio); });

        servicio = AssetDatabase.LoadAssetAtPath<ChurchServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Donacion_Pobres.asset");
        servicio.city = city.name;
        buttons[2].onClick.AddListener(delegate { comprarServicio(servicio); });

        servicio = AssetDatabase.LoadAssetAtPath<ChurchServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Donacion_Enfermos.asset");
        servicio.city = city.name;
        buttons[3].onClick.AddListener(delegate { comprarServicio(servicio); });

        servicio = AssetDatabase.LoadAssetAtPath<ChurchServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Capellania.asset");
        servicio.city = city.name;
        buttons[4].onClick.AddListener(delegate { comprarServicio(servicio); });

        servicio = AssetDatabase.LoadAssetAtPath<ChurchServiceSO>("Assets/CosasCarlos/Scriptable Objects/Items/Servicios/Mejorar_Iglesia.asset");
        servicio.city = city.name;
        buttons[5].onClick.AddListener(delegate { comprarServicio(servicio); });


        iglesiaView.gameObject.SetActive(false);
        modalView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }

    public void showUI()
    {

        iglesiaView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);

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
        if (!modalView.isActiveAndEnabled)
        {
            iglesiaView.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void comprarServicio(ChurchServiceSO service)
    {
        SerialService found = city.services.findItem(service);

        if (found != null && found.hasService)
        {
            if (player.playerCurrency.CurrencyQuantity > found.precio)
            {
                player.inventoryService.Add(service);
                city.services.Remove(service);
                player.playerCurrency.CurrencyQuantity -= found.precio;
                if(city.luck < service.luck)
                {
                    city.luck = service.luck;
                    city.luckTime = service.time;
                }
            }
        }
        else if (found == null || (found != null && !found.hasService))
        {
            SerialService playerService = player.inventoryService.findItem(service);
            {
                if(playerService != null)
                {
                modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "¡Ya tienes este servicio!";
                showModal();

                }
            }
        }

    }
}
