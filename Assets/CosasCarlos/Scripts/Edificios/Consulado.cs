using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class Consulado : MonoBehaviour
{
    [SerializeField]
    CitySO city;
    /*ublic currencySO currencyPlayer;*/

    public PlayerSO player;

    public CityStatsSO citystats;

    public ComercioView consuladoView;
    public CustomButton closeButton;



    public void Update()
    {
        //Debug.Log(layer);
    }
    public void Start()
    {
        //city = AssetDatabase.
        consuladoView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }

    public void showUI()
    {
        consuladoView.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
    }



    public void ExitView()
    {
        //Debug.Log(layer);
        consuladoView.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }



    public void ComprarChivatazo() { }

    public void ComprarMapa() { }
}