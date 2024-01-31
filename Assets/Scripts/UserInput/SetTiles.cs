using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SetTiles : MonoBehaviour
{
    [SerializeField]
    ToggleableModes toggleModes;

    [SerializeField]
    UserClick userClick;

    Vector3Int position;
    Tilemap tileMap;
    Tile tile;
    bool clear;

    bool hasData;

    void OnEnable()
    {
        userClick.ChosenTileByClick += SetTileInformation;
    }
    void OnDisable()
    {
        userClick.ChosenTileByClick -= SetTileInformation;
    }

    private void SetTileInformation(Vector3Int position, Tilemap tileMap, Tile tile, bool clear)
    {
        this.position = position;
        this.tileMap = tileMap;
        this.tile = tile;
        this.clear = clear;
        hasData = true;
    }

    public void ConfirmTile(InputAction.CallbackContext context)
    {
        if (hasData == true)
        {
            if (InputActionPhase.Started == context.phase && clear == false)
            {
                tileMap.SetTile(position, tile);
            }
            if (InputActionPhase.Started == context.phase && clear == true)
            {
                tileMap.SetTile(position, null);
            }
        }           
    }
}