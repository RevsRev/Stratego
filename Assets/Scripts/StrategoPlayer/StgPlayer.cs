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
        if (game.teamCanBeMadeReady(team))
        {
            if (!ready)
            {
                Debug.Log("Team " + team + " made ready!");

                ready = true;
                game.makeReady();
            }
        }
        else
        {
            Debug.Log("Team " + team + " cannot be made ready!");
        }
    }
}
