using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class, and those derived from it, represent the Stratego Pieces. 
 * This class does not deal with the rendering of these pieces.
 * Rendering will be offloaded to TODO - work out how this part of the architecture will work.
 */
public abstract class StgAbstractPiece
{
    public abstract bool canDoMove(Vector2 currentPos, Vector2 destinationPos);
    public abstract void doAttack(StgAbstractPiece stgAbstractPieceToAttack);
    public void doCaptured()
    {
        //TODO - implement
    }
}
