﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StgSergeant : StgAbstractPiece
{
    /*
     * Constructor
     */
    public StgSergeant(StgGame game, int team) : base(game, team) { }

    /*
     * Methods
     */

    public override List<StgBoardTile> getInGameAllowedMoves()
    {
        return StgAbstractPiece.getStandardMoves(tile, team);
    }

    public override List<Type> reallyGetTypesAttackBeats()
    {
        List<Type> retval = new List<Type>();
        retval.Add(typeof(StgScout));
        retval.Add(typeof(StgMiner));
        retval.Add(typeof(StgSpy));
        retval.Add(typeof(StgFlag));

        return retval;
    }
}