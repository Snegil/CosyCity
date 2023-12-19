using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadWriteData : MonoBehaviour
{
    LoadSavePathScript savePathScript;
    MapData mapData;

    string[] mapInformation;

    // Start is called before the first frame update
    void Awake()
    {
        savePathScript = GetComponent<LoadSavePathScript>();
        mapData = GetComponent<MapData>();
    }

    private void Start()
    {
        if (!File.Exists(savePathScript.SavePath))
        {
            // Create a file to write to
            using (StreamWriter sw = File.CreateText(savePathScript.SavePath))
            {
                sw.WriteLine(Application.productName + "ver. " + Application.version);
                sw.WriteLine("X, Y");
                sw.WriteLine("16, 16");
                sw.WriteLine();

                int[,] generatedMapInformation = mapData.GenerateMapData(16, 16);

                for (int i = 0; i < generatedMapInformation.GetLength(0); i++)
                {
                    for (int j = 0; j < generatedMapInformation.GetLength(1); j++)
                    {
                        sw.Write(generatedMapInformation[i, j] + ",");
                    }
                    sw.WriteLine();
                }

            }
        }
        using (StreamReader sw = File.OpenText(savePathScript.SavePath))
        {
            //mapInformation = File.ReadAllLines(savePathScript.SavePath);

            string versionNumber = sw.ReadLine();
            sw.ReadLine();
            string size = sw.ReadLine();
            string levelData = sw.ReadToEnd();
            string[] levelArray = levelData.Split(',');

            Debug.Log("LEVEL DATA \n" + levelData);
        }
    }
}
