using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory
{
    public ITile CreateTile(TilesEnum tileId)
    {
        ITile returnTile = null;

        switch (tileId)
        {
            case TilesEnum.Water:
                returnTile = new Water();
                break;
            case TilesEnum.Land:
                returnTile = new Land();
                break;
            default:
                returnTile = new Land();
                break;
        }

        return returnTile;
    }
}
