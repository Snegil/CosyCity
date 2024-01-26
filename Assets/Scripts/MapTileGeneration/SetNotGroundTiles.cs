using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetNotGroundTiles : MonoBehaviour
{
    [SerializeField]
    List<Tile> tiles = new List<Tile>();

    [SerializeField]
    List<Tilemap> tilemaps = new List<Tilemap>();
}
