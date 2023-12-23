using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class MapData : MonoBehaviour
{
    int[,] mapData;

    public void AddMapData(string generatedMapData, int xGridSize, int yGridSize)
    {
        mapData ??= new int[xGridSize, yGridSize];        

        string[] splitMapData = generatedMapData.Split(',');

        Debug.Log("X,Y: " + xGridSize + "," + yGridSize);

        for (int i = 0; i < xGridSize; i++)
        {
            for (int j = 0; j < yGridSize; j++)
            {
                this.mapData[i, j] = int.Parse(splitMapData[j]);
            }
            Debug.Log(i);
        }
    }
    public int[,] GetMapData()
    {
        return this.mapData;
    }

    // This should only be run, IF map.txt does NOT exist
    public int[,] GenerateMapData(int xSize, int ySize)
    {
        mapData = new int[xSize, ySize];

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                mapData[i, j] = 1;
            }
        }
        return mapData;
    }
}
