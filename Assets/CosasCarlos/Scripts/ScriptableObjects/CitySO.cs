using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "City", menuName = "ScriptableObjects/City")]
public class CitySO : ScriptableObject
{
    public InventoryServiceSO services;
    public double luck;
    public double luckTime;
    public int AlmacenCount;
    public string cityName;
    public bool entrancePaid = false;

    //Ayuntamiento
    public double impuestos_arrendados = 0;
    public double time_impuestos;

    //Banca
    public double dinero_prestado = 0;
    public double time_prestamo;


}


