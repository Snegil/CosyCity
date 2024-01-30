using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using static MapData;

public class UserClick : MonoBehaviour
{
    public delegate void TileChosenByClick(Vector3Int position, Tilemap tileMap, Tile tile, bool clear);
    public event TileChosenByClick ChosenTileByClick;

    Vector3Int gridPos;

    [SerializeField]
    MapData mapData;

    [SerializeField]
    List<Tilemap> tilemaps = new List<Tilemap>();

    [SerializeField]
    int tilemapIndex = 0;

    MousePosition mousePosition;

    int xSize;
    int ySize;

    [SerializeField]
    List<Tile> tiles;

    [SerializeField]
    int tileIndex;

    void OnEnable()
    {
        mapData.OnMapDataAdded += AssignSizeVariables;
    }
    void OnDisable()
    {
        mapData.OnMapDataAdded -= AssignSizeVariables;
    }

    private void Start()
    {
        mousePosition = GetComponent<MousePosition>();
    }


    private void Update()
    {
        gridPos = tilemaps[0].WorldToCell(mousePosition.WorldPos);

        if (gridPos.x >= 0 && gridPos.x < xSize && gridPos.y >= 0 && gridPos.y < ySize)
        {
            if (!tilemaps[0].GetTile(gridPos) && !tilemaps[1].GetTile(GridPos))
            {
                ChosenTileByClick?.Invoke(gridPos, tilemaps[tilemapIndex], tiles[tileIndex], false);
            }
        }
        else
        {
            ChosenTileByClick?.Invoke(gridPos, tilemaps[tilemapIndex], tiles[0], true);
        }
    }


    public Vector3Int GridPos { get { return gridPos; } }

    public void SetTilemapIndex(int index)
    {
        tilemapIndex = index;
    }
    public void SetTileIndex(int index)
    {
        tileIndex = index;
    }

    public int TileMapIndex
    {
        get { return tilemapIndex; }
        set { tilemapIndex = value; }
    }

    public void AssignSizeVariables(int[,] mapData, int xSize, int ySize)
    {
        this.xSize = xSize;
        this.ySize = ySize;
    }
}
