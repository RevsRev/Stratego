using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StgMine : StgAbstractPiece
{
    public StgMine(int team) : base(team)
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