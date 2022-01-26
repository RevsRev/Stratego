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
        //List<StgBoardTile> allowedMoves = new List<StgBoardTile> ();
        //TODO - implement this properly!
        return currentPos.getNeighbours();
    }
}
