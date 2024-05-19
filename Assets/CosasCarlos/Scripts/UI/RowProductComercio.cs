using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowProductComercio : MonoBehaviour
{
    [HideInInspector]
    public ProductsSO product;
    [SerializeField]
    CustomButton button;
    [HideInInspector]
    public Comercio comercio;

    public void Comprar()
    {
        comercio.Comprar(product);
    }

    public void Vender()
    {
        comercio.Vender(product);
    }
}
