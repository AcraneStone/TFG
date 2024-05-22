using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RowProductComercio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector]
    public ProductsSO product;
    [SerializeField]
    CustomButton button;
    [HideInInspector]
    public Comercio comercio;
    [HideInInspector]
    public Tabernas taberna;
    [HideInInspector]
    public HooverView hooverView;
    private void Start()
    {
        //TextMeshProUGUI[] texts = hooverView.GetComponentsInChildren<TextMeshProUGUI>();
        //texts[0].text = "Descripción: " + product.ItemDescription;
        //if (product.soporte == ItemContainerEnum.Barril)
        //{
        //    texts[1].text = "Volumen: Ocupa 1 barril";
        //}
        //else if (product.soporte == ItemContainerEnum.Espacio)
        //{
        //    texts[1].text = "Volumen: Ocupa 48 barriles";
        //}
        //texts[2].text = "Cantidad: Cada barril contiene " + product.cantidad;
        //Debug.Log(product.name);
        hooverView.gameObject.SetActive(false);

    }

    public void Comprar()
    {
        comercio.Comprar(product);
    }

    public void Vender()
    {
        comercio.Vender(product);
    }

    public void ComprarTaberna()
    {
        taberna.ComprarProducto(product);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        showHoover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exitHoover();
    }

    public void showHoover()
    {
        TextMeshProUGUI[] texts = hooverView.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = "Descripción: " + product.ItemDescription;
        if (product.soporte == ItemContainerEnum.Barril)
        {
            texts[1].text = "Volumen: Ocupa 1 barril";
        }
        else if (product.soporte == ItemContainerEnum.Espacio)
        {
            texts[1].text = "Volumen: Ocupa 48 barriles";
        }
        texts[2].text = "Cantidad: Cada barril contiene " + product.cantidad;
        hooverView.transform.position = new Vector3(button.transform.position.x + 350, button.transform.position.y + 200, hooverView.transform.position.z);
        hooverView.gameObject.SetActive(true);
    }

    public void exitHoover()
    {
        hooverView.gameObject.SetActive(false);
    }
}
