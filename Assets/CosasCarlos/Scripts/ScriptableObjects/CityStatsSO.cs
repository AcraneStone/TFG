using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "City Stats", menuName = "ScriptableObjects/City Stats")]
public class CityStatsSO : ScriptableObject
{
    [Serializable]
    public class Pair
    {
        public ProductsSO producto;
        public ItemStats existencias;
        public ItemStats demanda;
        public ItemStats produccion;
    }
    
    public string cityName;

    [SerializeField]
    private List<Pair> cityStats;
    public Pair GetPair(ProductsSO producto)
    {
        foreach (Pair pair in cityStats)
        {
            if (pair.producto == producto)
            {
                Debug.Log(pair.producto.ItemName);
                return pair;
            }
        }
        Pair pairVacio = new();
        return pairVacio;
    }

    public Pair GetPairByID(int ID)
    {
        foreach (Pair pair in cityStats)
        {
            if (pair.producto.ID == ID)
            {
                return pair;
            }
        }
        Pair pairVacio = new();
        return pairVacio;
    }

    //public void setStats(int ID, int newExistencias, int newDemandas, int newProduccion)
    //{
    //    foreach (Pair pair in cityStats)
    //    {
    //        if (pair.producto.ID == ID)
    //        {
    //            pair.existencias = newExistencias;

    //        }
    //    }

    //}
}