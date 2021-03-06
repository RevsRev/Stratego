using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StgSpy : StgAbstractPiece
{
    /*
     * Constructor
     */
    public StgSpy(StgGame game, int team) : base(game, team) { }

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
        retval.Add(typeof(StgMarshal));
        return retval;
    }
}