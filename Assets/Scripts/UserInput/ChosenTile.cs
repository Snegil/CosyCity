using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenTile : MonoBehaviour
{
    [SerializeField]
    Vector3Int TileChosen;

    public Vector3Int Tilechosen
    {
        get { return TileChosen; }
        set { TileChosen = value; }
    }
}
