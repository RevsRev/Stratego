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

    public StgGame() 
    {
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

    internal bool doMove(XmlDocument move)
    {
        if (localGame)
        {
            return doMoveLocalGame(move);
        }
        else
        {
            return doMoveNonLocalGame(move);
        }
    }

    private bool doMoveNonLocalGame(XmlDocument move)
    {
        throw new NotImplementedException();
    }

    private bool doMoveLocalGame(XmlDocument move)
    {
        throw new NotImplementedException();
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
