using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetOutlineTile : MonoBehaviour
{
    [SerializeField]
    UserClick userClick;

    [Space, SerializeField]
    Tilemap outlineTilemap;

    [SerializeField]
    Tile outlineTile;

    void OnEnable()
    {
        userClick.ChosenTileByClick += setOutline;   
    }
    void OnDisable()
    {
        userClick.ChosenTileByClick -= setOutline;    
    }
    public void setOutline(Vector3Int position, Tilemap tileMap, Tile tile, bool clear)
    {
        if (!clear)
        {
            outlineTilemap.ClearAllTiles();
            outlineTilemap.SetTile(position, outlineTile);
        }
        else
        {
            outlineTilemap.ClearAllTiles();
        }
        
    }
}
