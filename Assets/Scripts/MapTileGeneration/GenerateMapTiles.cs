using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMapTiles : MonoBehaviour
{
    [SerializeField]
    MapData mapData;

    [SerializeField]
    List<Tile> aboveGroundTiles = new List<Tile>();
    [SerializeField]
    Tile hellTile;


    [SerializeField]
    Tilemap aboveGroundTileMap;
    [SerializeField]
    Tilemap hellTileMap;

    void OnEnable()
    {
        mapData.OnMapDataAdded += GenerateMap;
    }
    private void OnDisable()
    {
        mapData.OnMapDataAdded -= GenerateMap;
    }

    private void GenerateMap(int[,] mapData, int xSize, int ySize)
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                aboveGroundTileMap.SetTile(new Vector3Int(i, j, 0), aboveGroundTiles[mapData[i, j]]);
            }
        }
        for (int p = 0; p < xSize; p++)
        {
            hellTileMap.SetTile(new Vector3Int(p, 0, 0), hellTile);
        }
        for (int o = 0; o < ySize; o++)
        {
            hellTileMap.SetTile(new Vector3Int(0, o, 0), hellTile);
        }
    }
}
