using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StgMiner : StgAbstractPiece
{
    /*
     * Constructor
     */
    public StgMiner(int team) : base(team) { }

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
        retval.Add(typeof(StgScout));
        retval.Add(typeof(StgMine));
        retval.Add(typeof(StgSpy));
        retval.Add(typeof(StgFlag));

        return retval;
    }
}