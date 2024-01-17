using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public delegate void MapDataAdded(int[,] mapData, int xSize, int ySize);
    public event MapDataAdded OnMapDataAdded;

    int[,] mapData;

    public void AddMapData(string generatedMapData, int xGridSize, int yGridSize)
    {
        mapData ??= new int[xGridSize, yGridSize];

        var initialSplitData = generatedMapData.Replace(" ", "").Replace("\n", "").Trim(',').Split(",");
        System.Array.Reverse(initialSplitData);

        Debug.Log("X,Y: " + xGridSize + "," + yGridSize);


        for (int i = 0; i < xGridSize; i++)
        {
            for (int j = 0; j < yGridSize; j++)
            {
                mapData[i, j] = int.Parse(initialSplitData[(i * yGridSize) + j]);
            }
        }

        OnMapDataAdded?.Invoke(mapData, xGridSize, yGridSize);
    }
    public int[,] GetMapData()
    {
        return mapData;
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
    public int GetSpecificMapData(int x, int z)
    {
        return mapData[x, z];
    }
}
