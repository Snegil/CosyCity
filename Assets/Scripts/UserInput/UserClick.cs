using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class UserClick : MonoBehaviour
{
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
        mousePosition = GetComponent<MousePosition>();
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
    public void MouseClicked(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Vector3Int gridPos = tilemaps[tilemapIndex].WorldToCell(mousePosition.WorldPos);
            if (gridPos.x >= 0 && gridPos.x < xSize && gridPos.y >= 0 && gridPos.y < ySize) 
            {
                for (int i = 0; i < tilemaps.Count; i++)
                {
                    if (tilemaps[i].GetTile(gridPos) != null)
                    {
                        Debug.Log(tilemaps[i].GetTile(gridPos));
                    }                    
                }
            }
        }
    }
}
