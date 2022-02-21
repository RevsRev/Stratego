using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class StgGame
{
    /*
     * Statics
     */
    public static readonly int STATE_PREGAME = 0;
    public static readonly int STATE_PLAYING = 1;

    private bool localGame = true;
    private int state = STATE_PREGAME;

    public StgBoard board { get; private set; }
    public StgPlayer playerBlue { get; private set; }
    public StgPlayer playerRed { get; private set; }

    public StgGame(bool localGame) 
    {
        this.localGame = localGame;

        board = new StgBoard(this);
        playerBlue = new StgPlayer(this, StgAbstractPiece.TEAM_BLUE);
        playerRed = new StgPlayer(this, StgAbstractPiece.TEAM_RED);
    }

    public void makeReady()
    {
        if (playerBlue.ready && playerRed.ready)
        {
            state = STATE_PLAYING;
        }
    }

    public bool ready()
    {
        return state != STATE_PREGAME;
    }

    public bool teamCanBeMadeReady(int team)
    {
        return board.teamIsReady(team);
    }

    public void nextTurn()
    {
        playerBlue.myTurn = !playerBlue.myTurn;
        playerRed.myTurn = !playerRed.myTurn;
    }

    public bool doMove(StgPlayer player, StgAbstractPiece pieceToMove, StgBoardTile tileToMoveTo)
    {
        bool success = false;
        if (localGame)
        {
            success = doMoveLocalGame(pieceToMove, tileToMoveTo);
        }
        else
        {
            success = doMoveNonLocalGame(pieceToMove, tileToMoveTo);
        }

        if (success)
        {
            player.nextTurn();
        }

        return success;
    }

    private bool doMoveNonLocalGame(StgAbstractPiece pieceToMove, StgBoardTile tileToMoveTo)
    {
        //Make sure we are allowed to do the move on the Svr before moving locally.
        if (doMoveOnSvr(pieceToMove, tileToMoveTo))
        {
            return doMoveLocalGame(pieceToMove, tileToMoveTo);
        }
        return false;
    }

    private bool doMoveOnSvr(StgAbstractPiece pieceToMove, StgBoardTile tileToMoveTo)
    {
        throw new NotImplementedException();
    }

    private bool doMoveLocalGame(StgAbstractPiece pieceToMove, StgBoardTile tileToMoveTo)
    {
        StgBoardTile currentTile = pieceToMove.tile;
        currentTile.piece = null;
        currentTile = tileToMoveTo;

        //Now do attack
        pieceToMove.doAttack(tileToMoveTo.piece);
        //Don't need any verification for local moves, always return true!
        return true;
    }

    public StgPlayer getPlayerForTeam(int team)
    {
        if (team == StgAbstractPiece.TEAM_BLUE)
        {
            return playerBlue;
        }
        else
        {
            return playerRed;
        }
    }

    public List<StgBoardTile> getPreGameAllowedMovesForTeam(int team)
    {
        return board.getPreGameAllowedMovesForTeam(team);
    }
}
