using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                sw.WriteLine(Application.productName + " ver. " + Application.version);
                sw.WriteLine("X,Z");
                sw.WriteLine("16,16");
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
            string versionNumber = sw.ReadLine();
            sw.ReadLine();
            string readSize = sw.ReadLine();
            string[] size = readSize.Split(',');

            string levelData = sw.ReadToEnd().Trim();            

            Debug.Log("LEVEL DATA \n" + levelData);
            Debug.Log("ROWS: " + levelData.Split("\n").Length);
            mapData.AddMapData(levelData, int.Parse(size[0]), int.Parse(size[1]));
        }
    }
}
