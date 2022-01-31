using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StgSpy : StgAbstractPiece
{
    /*
     * Constructor
     */
    public StgSpy(int team) : base(team) { }

    /*
     * Methods
     */

    public override List<StgBoardTile> getAllowedMoves()
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