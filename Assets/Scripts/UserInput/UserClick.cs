using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using static MapData;

public class UserClick : MonoBehaviour
{
    public delegate void TileChosenByClick(Vector3Int position, Tilemap tileMap, bool clear);
    public event TileChosenByClick ChosenTileByClick;

    Vector3Int gridPos;

    ChosenTile chosenTile;

    [SerializeField]
    MapData mapData;

    [SerializeField]
    List<Tilemap> tilemaps = new List<Tilemap>();
    [SerializeField]
    int tilemapIndex = 0;

    MousePosition mousePosition;

    int xSize;
    int ySize;

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
        chosenTile = GetComponent<ChosenTile>();
        mousePosition = GetComponent<MousePosition>();
    }
    private void Update()
    {
        gridPos = tilemaps[tilemapIndex].WorldToCell(mousePosition.WorldPos);

        if (gridPos.x >= 0 && gridPos.x < xSize && gridPos.y >= 0 && gridPos.y < ySize)
        {
            for (int i = 0; i < tilemaps.Count; i++)
            {
                ChosenTileByClick?.Invoke(gridPos, tilemaps[tilemapIndex], false);
            }
        }
        else
        {
            ChosenTileByClick?.Invoke(gridPos, tilemaps[tilemapIndex], true);
        }
    }
    public Vector3Int GridPos { get { return gridPos; } }
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
    public void MouseClicked(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (gridPos.x >= 0 && gridPos.x < xSize && gridPos.y >= 0 && gridPos.y < ySize) 
            {
                for (int i = 0; i < tilemaps.Count; i++)
                {
                    ChosenTileByClick?.Invoke(gridPos, tilemaps[tilemapIndex], false);
                }
            }
        }
    }
}
