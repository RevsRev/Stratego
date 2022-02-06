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
    private StgGame game;
    private Dictionary<int, Dictionary<int, StgBoardTile>> dTiles = new Dictionary<int, Dictionary<int, StgBoardTile>>();

    /*
     * Constructor
     */
    public StgBoard(StgGame game)
    {
        this.game = game;

        initBoardTiles();

        //Testing - I'm going to put a general on the 1,1 tile
        dTiles[0][0].piece = new StgMarshal(game, StgAbstractPiece.TEAM_RED);
        dTiles[0][0].piece.tile = dTiles[0][0];
        dTiles[1][0].piece = new StgGeneral(game, StgAbstractPiece.TEAM_RED);
        dTiles[1][0].piece.tile = dTiles[1][0];
        dTiles[2][0].piece = new StgColonel(game, StgAbstractPiece.TEAM_RED);
        dTiles[2][0].piece.tile = dTiles[2][0];
        dTiles[3][0].piece = new StgMajor(game, StgAbstractPiece.TEAM_RED);
        dTiles[3][0].piece.tile = dTiles[3][0];
        dTiles[4][0].piece = new StgCaptain(game, StgAbstractPiece.TEAM_RED);
        dTiles[4][0].piece.tile = dTiles[4][0]; 
        dTiles[5][0].piece = new StgLieutenant(game, StgAbstractPiece.TEAM_RED);
        dTiles[5][0].piece.tile = dTiles[5][0];
        dTiles[6][0].piece = new StgSergeant(game, StgAbstractPiece.TEAM_RED);
        dTiles[6][0].piece.tile = dTiles[6][0];
        dTiles[7][0].piece = new StgMiner(game, StgAbstractPiece.TEAM_RED);
        dTiles[7][0].piece.tile = dTiles[7][0];
        dTiles[8][0].piece = new StgScout(game, StgAbstractPiece.TEAM_RED);
        dTiles[8][0].piece.tile = dTiles[8][0];
        dTiles[9][0].piece = new StgSpy(game, StgAbstractPiece.TEAM_RED);
        dTiles[9][0].piece.tile = dTiles[9][0];
        dTiles[0][1].piece = new StgMine(game, StgAbstractPiece.TEAM_RED);
        dTiles[0][1].piece.tile = dTiles[0][1];
        dTiles[1][1].piece = new StgFlag(game, StgAbstractPiece.TEAM_RED);
        dTiles[1][1].piece.tile = dTiles[1][1];

        dTiles[0][9].piece = new StgMarshal(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[0][9].piece.tile = dTiles[0][9];
        dTiles[1][9].piece = new StgGeneral(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[1][9].piece.tile = dTiles[1][9];
        dTiles[2][9].piece = new StgColonel(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[2][9].piece.tile = dTiles[2][9];
        dTiles[3][9].piece = new StgMajor(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[3][9].piece.tile = dTiles[3][9];
        dTiles[4][9].piece = new StgCaptain(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[4][9].piece.tile = dTiles[4][9];
        dTiles[5][9].piece = new StgLieutenant(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[5][9].piece.tile = dTiles[5][9];
        dTiles[6][9].piece = new StgSergeant(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[6][9].piece.tile = dTiles[6][9];
        dTiles[7][9].piece = new StgMiner(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[7][9].piece.tile = dTiles[7][9];
        dTiles[8][9].piece = new StgScout(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[8][9].piece.tile = dTiles[8][9];
        dTiles[9][9].piece = new StgSpy(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[9][9].piece.tile = dTiles[9][9];
        dTiles[0][8].piece = new StgMine(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[0][8].piece.tile = dTiles[0][8];
        dTiles[1][8].piece = new StgFlag(game, StgAbstractPiece.TEAM_BLUE);
        dTiles[1][8].piece.tile = dTiles[1][8];
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

    public List<StgBoardTile> getPreGameAllowedMovesForTeam(int team)
    {
        List<StgBoardTile> retval = new List<StgBoardTile>();

        int lower = 0;
        int upper = 4;
        if (team == StgAbstractPiece.TEAM_BLUE)
        {
            lower = 6;
            upper = BOARD_HEIGHT;
        }

        for (int i=0; i<BOARD_HEIGHT; i++)
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
}
