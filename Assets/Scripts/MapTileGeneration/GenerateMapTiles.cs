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
    List<Tile> tiles = new List<Tile>();

    Tilemap tilemap;

    void OnEnable()
    {
        mapData.OnMapDataAdded += GenerateMap;
    }
    private void OnDisable()
    {
        mapData.OnMapDataAdded -= GenerateMap;
    }

    void Start()
    {
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();    
    }

    private void GenerateMap(int[,] mapData, int xSize, int ySize)
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                TileChangeData tileChangeData = new TileChangeData(new Vector3Int(i, j), tiles[mapData[i, j]], tiles[mapData[i, j]].color, Matrix4x4.identity);
                tilemap.SetTile(tileChangeData, true);
            }
        }
    }
}
