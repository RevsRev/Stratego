using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StgFlag : StgAbstractPiece
{
    public StgFlag(int team) : base(team)
    {
    }

    public override List<StgBoardTile> getAllowedMoves()
    {
        //Immobile
        return new List<StgBoardTile>();
    }

    public override List<Type> reallyGetTypesAttackBeats()
    {
        return new List<Type>();
    }
}