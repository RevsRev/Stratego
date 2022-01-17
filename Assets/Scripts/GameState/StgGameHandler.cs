using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class StgGameHandler
{
    private bool localGame = true;

    private StgPlayer playerBlue;
    private StgPlayer playerRed;

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
