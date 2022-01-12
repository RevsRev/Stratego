using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgGameState : MonoBehaviour
{
    // Start is called before the first frame update
    StgStrategoPlayer playerRed;
    StgStrategoPlayer playerBlue;
    StgStrategoPlayer currentPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void nextPlayer()
    {
        playerRed.nextTurn();
        playerBlue.nextTurn();
    }
}
