using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgGeneral : StgAbstractPiece
{
    /*
     * Constructor
     */
    public StgGeneral(int team) : base(team) { }

    /*
     * Methods
     */
    public override void doAttack(StgAbstractPiece stgAbstractPieceToAttack)
    {
        System.Type pieceType = stgAbstractPieceToAttack.GetType();
        if (pieceType == typeof(StgGeneral))
        {
            this.doCaptured();
            stgAbstractPieceToAttack.doCaptured();
        }
    }

    public override List<StgBoardTile> getAllowedMoves(StgBoardTile currentPos)
    {
        //TODO - implement
        throw new System.NotImplementedException();
    }
}
