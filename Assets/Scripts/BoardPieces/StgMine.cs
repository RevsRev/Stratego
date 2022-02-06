using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StgMine : StgAbstractPiece
{
    public StgMine(StgGame game, int team) : base(game, team)
    {
    }

    public override List<StgBoardTile> getInGameAllowedMoves()
    {
        //Immobile
        return new List<StgBoardTile>();
    }

    public override List<Type> reallyGetTypesAttackBeats()
    {
        return new List<Type>();
    }
}