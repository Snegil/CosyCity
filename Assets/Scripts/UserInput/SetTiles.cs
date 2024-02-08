using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SetTiles : MonoBehaviour
{
    [SerializeField]
    UserClick userClick;

    Vector3Int position;
    Tilemap tileMap;
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

    private void SetTileInformation(Vector3Int position, Tilemap tileMap, bool clear)
    {
        this.position = position;
        this.tileMap = tileMap;
        this.clear = clear;
        hasData = true;
    }

    public void ConfirmTile(InputAction.CallbackContext context)
    {
        if (hasData == true)
        {
            if (InputActionPhase.Started == context.phase && clear == false)
            {
                //tileMap.SetTile(position, tile);
            }
            if (InputActionPhase.Started == context.phase && clear == true)
            {
                tileMap.SetTile(position, null);
            }
        }           
    }
}