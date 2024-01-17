using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCameraOnTilemap : MonoBehaviour
{
    [SerializeField]
    MapData mapData;

    void OnEnable()
    {
        mapData.OnMapDataAdded += MoveCamera;
    }
    private void OnDisable()
    {
        mapData.OnMapDataAdded -= MoveCamera;
    }

    private void MoveCamera(int[,] mapData, int xSize, int ySize)
    {
        transform.position = new Vector2(xSize, ySize);
    }
}
