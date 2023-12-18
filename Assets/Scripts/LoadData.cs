using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    LoadSavePathScript savePathScript;
    MapData mapData;

    // Start is called before the first frame update
    void Awake()
    {
        savePathScript = GetComponent<LoadSavePathScript>();
        mapData = GetComponent<MapData>();
    }
    private void Start()
    {
        try
        {
            mapData.AddMapData(File.ReadAllLines(savePathScript.SavePath));
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
