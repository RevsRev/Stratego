using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Represents the Stratego board object. Does not deal with any of the rendering of said object.
 */
public class StgBoard
{
    private const int BOARD_DEADZONE_HEIGHT = 4;

    /*
* Statics
*/
    private static int BOARD_WIDTH = 10;
    private static int BOARD_HEIGHT = 10;

    /*
     * Variables
     */
    private StgGame game;
    private Dictionary<int, Dictionary<int, StgBoardTile>> dTiles = new Dictionary<int, Dictionary<int, StgBoardTile>>();

    /*
     * Constructor
     */
    public StgBoard(StgGame game)
    {
        this.game = game;

        initBoardTiles();

        initPieces();
    }

    /*
     * Methods
     */
    private void initBoardTiles()
    {
        //First create all the tiles - including the tiles "off board" that are used for putting the pieces when setting up the game.
        for (int i = 0; i < BOARD_WIDTH; i++)
        {
            dTiles[i] = new Dictionary<int, StgBoardTile>();
            for (int j = -BOARD_DEADZONE_HEIGHT; j < BOARD_HEIGHT + BOARD_DEADZONE_HEIGHT; j++)
            {
                dTiles[i][j] = new StgBoardTile(new Vector2Int(i, j));
            }
        }

        //Now cache all the neighbours
        for (int i = 0; i < BOARD_WIDTH; i++)
        {
            for (int j = 0; j < BOARD_HEIGHT; j++)
            {
                StgBoardTile boardTile = dTiles[i][j];

                if (i != 0)
                    boardTile.leftNeighbour = dTiles[i - 1][j];
                if (i != BOARD_WIDTH - 1)
                    boardTile.rightNeighbour = dTiles[i + 1][j];
                if (j != 0)
                    boardTile.bottomNeighbour = dTiles[i][j - 1];
                if (j != BOARD_HEIGHT - 1)
                    boardTile.topNeighbour = dTiles[i][j + 1];
            }
        }

        //Remove the neighbours for the special water tiles
        //unlinkWaterTiles(2, 2, 4, 2);
        //unlinkWaterTiles(6, 2, 4, 2);
    }

    private void unlinkWaterTiles(int xTileStart, int numXTiles, int yTileStart, int numYTiles)
    {
        for (int i = xTileStart - 1; i <= xTileStart + numXTiles + 1; i++)
        {
            for (int j = yTileStart - 1; j < yTileStart + numYTiles + 1; j++)
            {
                if (i != xTileStart - 1)
                {
                    dTiles[i][j].leftNeighbour = null;
                }

                if (i != xTileStart + numXTiles + 1)
                {
                    dTiles[i][j].rightNeighbour = null;
                }

                if (j != yTileStart - 1)
                {
                    dTiles[i][j].bottomNeighbour = null;
                }

                if (j != yTileStart + numYTiles + 1)
                {
                    dTiles[i][j].topNeighbour = null;
                }
            }
        }
    }

    private void initPieces()
    {
        initPieces(StgAbstractPiece.TEAM_RED);
        initPieces(StgAbstractPiece.TEAM_BLUE);
    }
    private void initPieces(int team)
    {
        int heightLower = -BOARD_DEADZONE_HEIGHT;
        int heightUpper = 0;

        if (team == StgAbstractPiece.TEAM_BLUE)
        {
            heightUpper = BOARD_HEIGHT + BOARD_DEADZONE_HEIGHT;
            heightLower = BOARD_HEIGHT;
        }

        int count = 0;
        for (int i=0; i<BOARD_WIDTH; i++)
        {
            for (int j=heightLower; j<heightUpper; j++)
            {
                StgAbstractPiece piece = getInitialPiece(count, team);
                dTiles[i][j].piece = piece;
                piece.tile = dTiles[i][j];
                count++;
            }
        }
    }
    private StgAbstractPiece getInitialPiece(int count, int team)
    {
        if (count < 8)
        {
            return new StgScout(game, team);
        }
        else if (count < 14)
        {
            return new StgMine(game, team);
        }
        else if (count < 19)
        {
            return new StgMiner(game, team);
        }
        else if (count < 23)
        {
            return new StgSergeant(game, team);
        }
        else if (count < 27)
        {
            return new StgLieutenant(game, team);
        }
        else if (count < 31)
        {
            return new StgCaptain(game, team);
        }
        else if (count < 34)
        {
            return new StgMajor(game, team);
        }
        else if (count < 36)
        {
            return new StgColonel(game, team);
        }
        else if (count < 37)
        {
            return new StgGeneral(game, team);
        }
        else if (count < 38)
        {
            return new StgMarshal(game, team);
        }
        else if (count < 39)
        {
            return new StgSpy(game, team);
        }
        else
        {
            return new StgFlag(game, team);
        }
    }

    public StgBoardTile getTileForGridPoint(Vector2Int point)
    {
        return dTiles[point.x][point.y];
    }

    public List<StgBoardTile> getOccupiedTiles()
    {
        List<StgBoardTile> retval = new List<StgBoardTile>();
        for (int i=0; i<BOARD_WIDTH; i++)
        {
            for (int j= -BOARD_DEADZONE_HEIGHT; j<BOARD_HEIGHT + BOARD_DEADZONE_HEIGHT; j++)
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

    public List<StgBoardTile> getPreGameAllowedMovesForTeam(int team)
    {
        List<StgBoardTile> retval = new List<StgBoardTile>();

        int lower = 0;
        int upper = 4;
        if (team == StgAbstractPiece.TEAM_BLUE)
        {
            lower = 6;
            upper = BOARD_WIDTH;
        }

        for (int i=0; i<BOARD_WIDTH; i++)
        {
            for (int j=lower; j< upper; j++)
            {
                if (!dTiles[i][j].occupied())
                {
                    retval.Add(dTiles[i][j]);
                }
            }
        }
        return retval;
    }

    public bool teamIsReady(int team)
    {
        List<StgBoardTile> preGameMoves = getPreGameAllowedMovesForTeam(team);
        return preGameMoves.Count == 0;
    }
}
