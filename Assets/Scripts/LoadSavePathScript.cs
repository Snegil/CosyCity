using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadSavePathScript : MonoBehaviour
{
    [Space, SerializeField, Header("DO NOT ADD FILE EXTENSION HERE!")]
    string mapFileName;

    string savePath;
    public string SavePath {  get { return savePath; } }
    // Start is called before the first frame update
    void Awake()
    {
        savePath = Application.persistentDataPath + mapFileName + ".txt";
        Debug.Log(savePath);
    }
}
