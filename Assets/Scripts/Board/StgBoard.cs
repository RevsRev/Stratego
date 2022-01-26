using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Represents the Stratego board object. Does not deal with any of the rendering of said object.
 */
public class StgBoard
{
    /*
     * Statics
     */
    private static int BOARD_HEIGHT = 10;
    private static int BOARD_WIDTH = 10;

    /*
     * Variables
     */
    private Dictionary<int, Dictionary<int, StgBoardTile>> dTiles = new Dictionary<int, Dictionary<int, StgBoardTile>>();

    /*
     * Constructor
     */
    public StgBoard()
    {
        initBoardTiles();

        //Testing - I'm going to put a general on the 1,1 tile
        dTiles[1][1].piece = new StgGeneral(StgAbstractPiece.TEAM_BLUE);
        dTiles[1][1].piece.position = new Vector2Int(1, 1);
    }

    /*
     * Methods
     */
    private void initBoardTiles()
    {
        //First create all the tiles
        for (int i=0; i<BOARD_HEIGHT; i++)
        {
            dTiles[i] = new Dictionary<int, StgBoardTile>();
            for (int j=0; j<BOARD_WIDTH; j++)
            {
                dTiles[i][j] = new StgBoardTile(new Vector2Int(i, j));
            }
        }

        //Now cache all the neighbours
        for (int i=0; i<BOARD_HEIGHT; i++)
        {
            for (int j=0; j<BOARD_WIDTH; j++)
            {
                StgBoardTile boardTile = dTiles[i][j];

                if (i != 0)
                    boardTile.bottomNeighbour = dTiles[i - 1][j];
                if (i != BOARD_HEIGHT - 1)
                    boardTile.topNeighbour = dTiles[i + 1][j];
                if (j != 0)
                    boardTile.leftNeighbour = dTiles[i][j - 1];
                if (j != BOARD_WIDTH - 1)
                    boardTile.rightNeighbour = dTiles[i][j + 1];
            }
        }
    }

    public StgBoardTile getTileForGridPoint(Vector2Int point)
    {
        return dTiles[point.x][point.y];
    }

    public List<StgBoardTile> getOccupiedTiles()
    {
        List<StgBoardTile> retval = new List<StgBoardTile>();
        for (int i=0; i<dTiles.Count; i++)
        {
            for (int j=0; j<dTiles[i].Count; j++)
            {
                StgBoardTile tile = dTiles[i][j];
                if (tile.piece != null)
                {
                    retval.Add(tile);
                }
            }
        }
        return retval;
    }
}
