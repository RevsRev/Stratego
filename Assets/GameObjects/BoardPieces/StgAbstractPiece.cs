using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StgAbstractPiece : MonoBehaviour
{
    public abstract bool canDoMove(Vector2 currentPos, Vector2 destinationPos);
    public abstract void doAttack(StgAbstractPiece stgAbstractPieceToAttack);
    public void doCaptured()
    {
        //TODO - implement
    }
}
