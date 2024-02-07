using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class ChosenTile : MonoBehaviour
{
    public delegate void TileChosen();
    public event TileChosen ChosenTileEvent;

    [SerializeField]
    List<Tile> tiles = new List<Tile>();

    [SerializeField]
    int tileIndex;

    public void TileChangeOnInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            TileChange((int)context.ReadValue<float>());
        }        
    }
    public void TileChange(int value)
    {
        if ((tileIndex + value) > tiles.Count - 1)
        {
            tileIndex = 0;
            return;
        }
        if ((tileIndex + value) < 0)
        {
            tileIndex = tiles.Count - 1;
            return;
        }
        tileIndex += value;
    }
}
