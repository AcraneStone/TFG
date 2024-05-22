using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    protected CitySO city;
    protected PlayerSO player;

    protected virtual void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        city = AssetDatabase.LoadAssetAtPath<CitySO>("Assets/CosasCarlos/Scriptable Objects/" + sceneName + "/" + sceneName + ".asset");

        player = AssetDatabase.LoadAssetAtPath<PlayerSO>("Assets/CosasCarlos/Scriptable Objects/Player/myPlayerSO.asset");
    }
}
