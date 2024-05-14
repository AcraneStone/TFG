using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPuertos : MonoBehaviour
{

    public  void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Barco"){
            other.gameObject.GetComponent<BarcoFighter>().stats.velocidad1 = 0;
            //cambiar  a escena puerto
            //SceneManager.LoadScene(gameObject.name);
        }
    }
}
