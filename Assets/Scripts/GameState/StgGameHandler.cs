using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class StgGameHandler
{
    private bool localGame = true;

    public StgBoard board { get; private set; }
    private StgPlayer playerBlue;
    private StgPlayer playerRed;

    private static StgGameHandler instance;
    private static readonly object padlock = new object();

    private StgGameHandler() 
    {
        board = new StgBoard();
    }
    public static StgGameHandler theGame()
    {
        if (instance == null)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new StgGameHandler();
                }
            }
        }
        return instance;
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
