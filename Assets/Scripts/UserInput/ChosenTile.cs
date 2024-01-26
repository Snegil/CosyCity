using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChosenTile : MonoBehaviour
{
    [SerializeField]
    UserClick userClick;

    [SerializeField]
    Vector3Int TileChosen;

    void OnEnable()
    {
        userClick.ChosenTileByClick += AddChosenTile;
    }
    void OnDisable()
    {
        userClick.ChosenTileByClick -= AddChosenTile;
    }

    void AddChosenTile(Vector3Int position, Tilemap tilemap)
    {
        Tilechosen = position;
    }

    public Vector3Int Tilechosen
    {
        get { return TileChosen; }
        set { TileChosen = value; }
    }
}
