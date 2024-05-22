using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialBarco : InventoryItem<Barcos>
{
    // Start is called before the first frame update

    public SerialBarco(Barcos barco) : base(barco)
    {
        barco.inventario = new();
    }

}
