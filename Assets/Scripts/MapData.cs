using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    string[,] mapData;

    public void AddMapData(string[] mapData)
    {
        Debug.Log(mapData);
    }
    public string[,] GetMapData()
    {
        return this.mapData;
    }
}
