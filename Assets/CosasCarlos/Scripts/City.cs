using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    InventoryServiceSO services;
    double luck;
    // Start is called before the first frame update
    void Start()
    {
        CSVcityStats.FillCityStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
