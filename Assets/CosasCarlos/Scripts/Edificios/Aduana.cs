using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class Aduana : Building
{


    [SerializeField]
    //CitySO city;
    //public PlayerSO player = AssetDatabase.get;
    private float impuestoEntrada;
    private float impuestoSalida;

    // UI 
    public ComercioView aduanaView;
    //public View modalView;
    public CustomButton closeButton;
    // Start is called before the first frame update
    void Start()
    {
        impuestoEntrada = 0;
        impuestoSalida = 0;
        aduanaView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        //modalView.gameObject.SetActive(false);

    }

    public void showUI()
    {
        aduanaView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        //modalView.gameObject.SetActive(false);
    }

    public void ExitView()
    {
        //Debug.Log(layer);

        aduanaView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        //modalView.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PagarEntrada()
    {
        //if (!city.entrancePaid)
        //{
        //    foreach(Barcos barco in city.flota)
        //    {
        //        foreach(ProductsSO p in barco.invenario)
        //        {
        //            SerialProduct found = barco.inventario.findItem(p);
        //            impuestoEntrada += (p.precio * 0.1f) * found.stackSize;
        //         }
        //    }
        //    if(player.playerCurrency.CurrencyQuantity > impuestoEntrada)
        //    {
        //        player.playerCurrency.CurrencyQuantity -= impuestoEntrada;
        //        city.entrancePaid = true;
                //modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Has pagado los impuestos de entrada: "+ impuestoEntrada;
                //showModal();
        //    }

        //}
        //Hace falta el inventario del barco
        //Si ha pagado city.entrancePaid = true;
    }

    public void PagarSalida()
    {
        //if (city.entrancePaid)
        //{
        //    foreach(Barcos barco in city.flota)
        //    {
        //        foreach(ProductsSO p in barco.invenario)
        //        {
        //            SerialProduct found = barco.inventario.findItem(p);
        //            impuestoSalida += (p.precio * 0.05f) * found.stackSize;
        //         }
        //    }
        //    if(player.playerCurrency.CurrencyQuantity > impuestoEntrada)
        //    {
        //        player.playerCurrency.CurrencyQuantity -= impuestoEntrada;
        //        city.entrancePaid = false;
        //modalView.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Has pagado los impuestos de salida: "+ impuestoSalida;
        //showModal();
        //    }

        //}
    }

    public void PagarTramitacion()
    {
        //Hace falta inventario del barco
    }
}
