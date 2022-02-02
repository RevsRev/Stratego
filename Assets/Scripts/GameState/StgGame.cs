using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class StgGame
{
    private bool localGame = true;

    public StgBoard board { get; private set; }
    public StgPlayer playerBlue { get; private set; }
    public StgPlayer playerRed { get; private set; }

    public StgGame() 
    {
        board = new StgBoard();
        playerBlue = new StgPlayer(this, StgAbstractPiece.TEAM_BLUE);
        playerRed = new StgPlayer(this, StgAbstractPiece.TEAM_RED);
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
}
