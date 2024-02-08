using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using static MapData;
using static UnityEngine.UI.ContentSizeFitter;

public class UserClick : MonoBehaviour
{
    public delegate void TileChosenByClick(Vector3Int position, Tilemap tileMap, bool clear);
    public event TileChosenByClick ChosenTileByClick;
    public delegate void OutlineTileEvent(Vector3Int position, Tilemap tileMap, bool clear);
    public event OutlineTileEvent OutlineTiles;


    Vector3Int gridPos;

    [SerializeField]
    MapData mapData;

    [SerializeField]
    List<Tilemap> tilemaps = new();

    [SerializeField]
    int tilemapIndex = 0;

    MousePosition mousePosition;

    int xSize;
    int ySize;

    [SerializeField]
    List<Tile> tiles;

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
            OutlineTiles?.Invoke(gridPos, tilemaps[0], false);
        }
        else
        {
            OutlineTiles?.Invoke(gridPos, tilemaps[0], true);
        }
    }

    public void UserClicked(InputAction.CallbackContext context)
    {
        if (gridPos.x >= 0 && gridPos.x < xSize && gridPos.y >= 0 && gridPos.y < ySize && tilemaps[0].GetTile(gridPos) != null && context.phase == InputActionPhase.Started)
        {
            ChosenTileByClick?.Invoke(gridPos, tilemaps[tilemapIndex], false);
        }
    }

    public Vector3Int GridPos { get { return gridPos; } }

    public int TilemapIndex
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