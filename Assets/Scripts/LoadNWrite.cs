using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadNWrite : MonoBehaviour
{
    LoadSavePathScript savePathScript;
    MapData mapData;

    StreamWriter streamWriter;

    // Start is called before the first frame update
    void Awake()
    {
        savePathScript = GetComponent<LoadSavePathScript>();
        mapData = GetComponent<MapData>();

        streamWriter = new StreamWriter(savePathScript.SavePath);
    }

    private void Start()
    {
        
    }
}
