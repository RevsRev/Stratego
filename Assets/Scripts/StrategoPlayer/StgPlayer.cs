﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class StgPlayer
{

    public bool myTurn { get; private set; } = false;
    public StgGame game { get; set; }

    public StgPlayer(StgGame game, bool myTurn)
    {
        this.myTurn = myTurn;
        this.game = game;
    }

    public void nextTurn()
    {
        myTurn = !myTurn;
    }

    //called once per frame provided it is this player's turn
    private void UpdateTurn()
    {
        XmlDocument move = getMove();
        if (move != null
            && doMove(move))
        {
            nextTurn();
        }
    }
    public XmlDocument getMove()
    {
        throw new System.NotImplementedException();
    }
    public bool doMove(XmlDocument move)
    {
        return game.doMove(move);
    }
}
