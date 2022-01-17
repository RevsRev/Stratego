using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgGeneral : StgAbstractPiece
{
    public override void doAttack(StgAbstractPiece stgAbstractPieceToAttack)
    {
        System.Type pieceType = stgAbstractPieceToAttack.GetType();
        if (pieceType == typeof(StgGeneral))
        {
            this.doCaptured();
            stgAbstractPieceToAttack.doCaptured();
        }
    }

    public override bool canDoMove(Vector2 currentPos, Vector2 destinationPos)
    {
        //TODO - implement
        throw new System.NotImplementedException();
    }
}
