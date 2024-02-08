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
        userClick.OutlineTiles += SetOutline;   
    }
    void OnDisable()
    {
        userClick.OutlineTiles -= SetOutline;    
    }
    public void SetOutline(Vector3Int position, Tilemap tileMap, bool clear)
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
