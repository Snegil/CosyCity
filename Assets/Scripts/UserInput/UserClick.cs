using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using static MapData;
using static UnityEngine.UI.ContentSizeFitter;

public class UserClick : MonoBehaviour
{
    public delegate void TileChosenByClick(Vector3Int position, Tilemap tileMap, Tile tile, bool clear);
    public event TileChosenByClick ChosenTileByClick;
    public delegate void OutlineTileEvent(Vector3Int position, Tilemap tileMap, Tile tile, bool clear);
    public event OutlineTileEvent OutlineTiles;


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
    int tileIndex = 0;

    bool mode;
    void OnEnable()
    {
        
        mapData.OnMapDataAdded += AssignSizeVariables;
    }
    void OnDisable()
    {
        
        mapData.OnMapDataAdded -= AssignSizeVariables;
    }
    private void SetMode(bool mode)
    {
        this.mode = mode;
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
            OutlineTiles?.Invoke(gridPos, tilemaps[0], tiles[0], false);
            ChosenTileByClick?.Invoke(gridPos, tilemaps[tilemapIndex], tiles[tileIndex], false);
        }
        else
        {
            OutlineTiles?.Invoke(gridPos, tilemaps[0], tiles[0], true);
        }
    }

    public void UserClicked(InputAction.CallbackContext context)
    {
        
    }

    public Vector3Int GridPos { get { return gridPos; } }

    public int TilemapIndex
    {
        get { return tilemapIndex; }
        set { tilemapIndex = value; }
    }
    public int TileIndex
    {
        get { return tileIndex; }
        set { tileIndex = value; }
    }

    public void AssignSizeVariables(int[,] mapData, int xSize, int ySize)
    {
        this.xSize = xSize;
        this.ySize = ySize;
    }
}
