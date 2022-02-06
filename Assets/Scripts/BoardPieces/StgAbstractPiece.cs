using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public static int TEAM_UNASSIGNED = -1;
    public static int TEAM_BLUE = 0;
    public static int TEAM_RED = 1;

    /*
     * Variables
     */
    public int team { get; set; } = TEAM_BLUE;
    public StgBoardTile tile { get; set; }
    public bool alive { get; private set; } = true; //alive or not alive
    private StgGame game;

    private List<Type> typesAttackBeats = null;

    /*
     * Constructor
     */
    public StgAbstractPiece(StgGame game, int team)
    {
        this.game = game;
        this.team = team;
    }

    /*
     * Methods
     */
    public StgPlayer getPlayer()
    {
        return game.getPlayerForTeam(team);
    }
    public List<StgBoardTile> getAllowedMoves()
    {
        StgPlayer player = getPlayer();
        if (player.ready)
        {
            return getInGameAllowedMoves();
        }
        return getPreGameAllowedMoves();
    }
    public abstract List<StgBoardTile> getInGameAllowedMoves();
    public List<StgBoardTile> getPreGameAllowedMoves()
    {
        return game.getPreGameAllowedMovesForTeam(team);
    }

    //Standard moves (all pieces move like this except for scouts and immobile pieces)
    public static List<StgBoardTile> getStandardMoves(StgBoardTile tile, int team)
    {
        List<StgBoardTile> allowedMoves = new List<StgBoardTile>();
        if (tile == null)
        {
            return allowedMoves;
        }

        List<StgBoardTile> neighbours = tile.getNeighbours();
        for (int i = 0; i < neighbours.Count; i++)
        {
            StgBoardTile neighbour = neighbours[i];
            if (neighbour.getOccupyingTeam() != team)
            {
                allowedMoves.Add(neighbour);
            }
        }
        return allowedMoves;
    }
    public void doAttack(StgAbstractPiece stgAbstractPieceToAttack)
    {
        if (stgAbstractPieceToAttack == null)
        {
            tile.piece = this;
            return;
        }

        reallyDoAttack(stgAbstractPieceToAttack);
    }
    private void reallyDoAttack(StgAbstractPiece stgAbstractPieceToAttack)
    {
        StgAbstractPiece.reallyDoAttack(this, stgAbstractPieceToAttack);
    }
    private static void reallyDoAttack(StgAbstractPiece attackingPiece, StgAbstractPiece defendingPiece)
    {
        Type attackingType = attackingPiece.GetType();
        Type defendingType = defendingPiece.GetType();

        //both the pieces die if they are the same type
        if (attackingType == defendingType)
        {
            attackingPiece.doCaptured();
            defendingPiece.doCaptured();
            return;
        }

        List<Type> typesAttackingPieceBeats = attackingPiece.getTypesAttackBeats();
        if (typesAttackingPieceBeats.Contains(defendingType))
        {
            doOutcome(attackingPiece, defendingPiece);
        }
        else
        {
            doOutcome(defendingPiece, attackingPiece);
        }
    }

    public List<Type> getTypesAttackBeats()
    {
        if (typesAttackBeats == null)
        {
            typesAttackBeats = reallyGetTypesAttackBeats();
        }
        return typesAttackBeats;
    }
    public abstract List<Type> reallyGetTypesAttackBeats();

    private static void doOutcome(StgAbstractPiece winner, StgAbstractPiece loser)
    {
        winner.doMove(loser.tile);
        winner.doWin();
        loser.doCaptured();
    }

    public void doMove(StgBoardTile tileToMoveTo)
    {
        //Move the piece and unlink from the tile
        tile.piece = null;
        tile = tileToMoveTo;

        //Now do attack
        doAttack(tileToMoveTo.piece);
    }
    public void doCaptured()
    {
        //don't think this should ever happen but just to be sure!
        if (tile.piece == this)
        {
            tile.piece = null;
        }

        tile = null;
        alive = false;
    }
    public void doWin()
    {
        tile.piece = this;
    }

    public Vector2Int? getPosition()
    {
        if (tile == null)
        {
            return null;
        }
        return tile.gridLocation;
    }
}
