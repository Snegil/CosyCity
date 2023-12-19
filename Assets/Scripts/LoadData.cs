using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    LoadSavePathScript savePathScript;
    WriteData writeData;
    MapData mapData;

    // Start is called before the first frame update
    void Awake()
    {
        savePathScript = GetComponent<LoadSavePathScript>();
        writeData = GetComponent<WriteData>();
        mapData = GetComponent<MapData>();
    }
    private void Start()
    {
        if (!File.Exists(savePathScript.SavePath))
        {
            writeData.CreateFile();
            return;
        }
    }
}
