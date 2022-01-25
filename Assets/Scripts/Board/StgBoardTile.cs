using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgBoardTile
{
    /*
     * Class variables
     */
    public StgBoardTile leftNeighbour { get; set; }
    public StgBoardTile rightNeighbour { get; set; }
    public StgBoardTile topNeighbour { get; set; }
    public StgBoardTile bottomNeighbour { get; set; }

    public StgAbstractPiece piece { get; set; }

    public Vector2Int gridLocation { get; set; }

    /*
     * Methods
     */
    public StgBoardTile(Vector2Int gridLocation)
    {
        this.gridLocation = gridLocation;
    }
}