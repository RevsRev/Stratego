using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class StgPlayer
{
    public bool ready { get; private set; } = false;
    public bool myTurn { get; set; } = false;
    public StgGame game { get; set; }

    public int team { get; set; }

    public StgPlayer(StgGame game, int team)
    {
        this.team = team;
        this.game = game;

        myTurn = team == StgAbstractPiece.TEAM_RED;
    }

    public void nextTurn()
    {
        game.nextTurn();
    }

    public void makeReady()
    {
        ready = true;
        game.makeReady();
    }

    //called once per frame provided it is this player's turn
    //private void UpdateTurn()
    //{
    //    XmlDocument move = getMove();
    //    if (move != null
    //        && doMove(move))
    //    {
    //        nextTurn();
    //    }
    //}
    public XmlDocument getMove()
    {
        throw new System.NotImplementedException();
    }
    public bool doMove(XmlDocument move)
    {
        return game.doMove(move);
    }
}
