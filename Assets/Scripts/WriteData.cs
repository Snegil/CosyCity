using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteData : MonoBehaviour
{
    LoadSavePathScript savePathScript;
    MapData mapData;

    // Start is called before the first frame update
    void Awake()
    {
        savePathScript = GetComponent<LoadSavePathScript>();
        mapData = GetComponent<MapData>();
    }

    public void CreateFile()
    {
        File.Create(savePathScript.SavePath);
        SaveMapData();
    }
    public void SaveMapData()
    {
        using (StreamWriter sw = new StreamWriter(savePathScript.SavePath))
        {
            Debug.Log("WRITING TO FILE");
            sw.WriteLine("CosyCity ver. " + Application.version);
            //sw.WriteLine("16");
            //sw.WriteLine();
        }
    }
}
