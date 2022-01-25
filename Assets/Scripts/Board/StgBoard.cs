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
    }

    /*
     * Methods
     */
    private void initBoardTiles()
    {
        for (int i=0; i<BOARD_HEIGHT; i++)
        {
            for (int j=0; j<BOARD_WIDTH; j++)
            {
                dTiles[i][j] = new StgBoardTile(new Vector2Int(i, j));
            }
        }
    }

    public StgBoardTile getTileForGridPoint(Vector2Int point)
    {
        return dTiles[point.x][point.y];
    }
}
