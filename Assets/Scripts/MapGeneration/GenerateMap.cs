using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateMap : MonoBehaviour
{
    [SerializeField]
    MapData mapData;

    void OnEnable()
    {
        mapData.OnMapDataAdded += Generate3DMap;
    }
    public void Generate3DMap(int[,] mapData, int xGridSize, int yGridSize)
    {
        int[,] mapDataInfo = mapData;


    }
}
