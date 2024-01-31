using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class RemoveTiles : MonoBehaviour
{
    [SerializeField]
    ToggleableModes toggleModes;

    [SerializeField]
    UserClick userClick;

    Vector3Int position;
    List<Tilemap> tileMaps;

    bool hasData;

    void OnEnable()
    {
        userClick.removeChosenTileByClick += SetTileInformation;
    }
    void OnDisable()
    {
        userClick.removeChosenTileByClick -= SetTileInformation;
    }

    private void SetTileInformation(Vector3Int position, List<Tilemap> tileMaps)
    {
        this.position = position;
        this.tileMaps = tileMaps;
        hasData = true;
    }

    public void ConfirmTile(InputAction.CallbackContext context)
    {
        if (hasData == true)
        {
            for (int i = 0; i < tileMaps.Count; i++)
            {
                tileMaps[i].SetTile(position, null);
            }
        }
    }
}