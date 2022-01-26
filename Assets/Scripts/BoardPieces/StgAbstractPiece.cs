using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class, and those derived from it, represent the Stratego Pieces. 
 * This class does not deal with the rendering of these pieces.
 * Rendering will be offloaded to TODO - work out how this part of the architecture will work.
 */
public abstract class StgAbstractPiece
{
    /*
     * Statics
     */
    public static int TEAM_BLUE = 0;
    public static int TEAM_RED = 1;

    /*
     * Variables
     */
    public int team { get; set; } = TEAM_BLUE;
    public Vector2Int position { get; set; }

    /*
     * Constructor
     */
    public StgAbstractPiece(int team)
    {
        this.team = team;
    }

    /*
     * Methods
     */
    public abstract List<StgBoardTile> getAllowedMoves(StgBoardTile currentPos);
    public abstract void doAttack(StgAbstractPiece stgAbstractPieceToAttack);
    public void doCaptured()
    {
        //TODO - implement
    }
}
