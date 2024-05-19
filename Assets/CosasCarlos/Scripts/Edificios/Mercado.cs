using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum MercadoUI
{
    None    = 0,
    Mercado = 1,
    Comprar = 2,
    Vender  = 3
}
//[Serializable]
public class Mercado : Comercio
{
    
    public ComercioView mercadoView;
    public ComercioView comercioView;
    public CustomButton closeButton;
    private MercadoUI layer = MercadoUI.None;



    public void Update()
    {
        //Debug.Log(layer);
    }
    public void Start()
    {
        mercadoView.gameObject.SetActive(false);
        comercioView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        layer = MercadoUI.None;
    }

    public void showUIMercado()
    {
        mercadoView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        layer = MercadoUI.Mercado;
    }

    public void AccionComprar() { 
        mercadoView.gameObject.SetActive(false);
        comercioView.gameObject.SetActive(true);
        SetupItemListComprarUI();
        layer = MercadoUI.Comprar;
    }

    public void AccionVender() {
        mercadoView.gameObject.SetActive(false);
        comercioView.gameObject.SetActive(true);
        SetupItemListVenderUI();
        layer = MercadoUI.Vender;
    }


    public void ExitView() {
        //Debug.Log(layer);


        if (layer == MercadoUI.Mercado) { 
            mercadoView.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
            layer = MercadoUI.None;
        }
        
        else if(layer == MercadoUI.Comprar || layer == MercadoUI.Vender){
            comercioView.gameObject.SetActive(false);
            mercadoView.gameObject.SetActive(true);
            layer = MercadoUI.Mercado;
        }
       
    }

}


