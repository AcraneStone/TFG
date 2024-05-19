
using System.IO;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class CSVcityStats : MonoBehaviour
{
    //[Sirenix.OdinInspector.FilePath]
    //public string filePath = "/Scriptable Objects/Items/Products";

    private static string csvPath = "/CSVs/puertos-mercancias.csv";

    [MenuItem("Utilities/Update City Stats")]
    public static void FillCityStats()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string[] sceneDataName = sceneName.Split('_');
        string cityName = sceneDataName[0]+"_Stats.asset";
        CityStatsSO cityStats = AssetDatabase.LoadAssetAtPath<CityStatsSO>("Assets/Scriptable Objects/CityStats/" + cityName);
        string[] lines = File.ReadAllLines(Application.dataPath + csvPath);
        foreach (string line in lines) {
            string[] data = line.Split(';');
            if (data[0] == cityStats.cityName)
            {
                for(int i = 1; i < 61; i++)
                {
                    Debug.Log(i + " " + data[(i * 3) - 2]);

                    cityStats.GetPairByID(i).existencias = (ItemStats)int.Parse(data[(i * 3) - 2]);
                    cityStats.GetPairByID(i).demanda = (ItemStats)int.Parse(data[(i * 3) - 1]);
                    cityStats.GetPairByID(i).produccion = (ItemStats)int.Parse(data[(i * 3)]);
                }
                AssetDatabase.Refresh();
                break;
            }
        }
    }

}
