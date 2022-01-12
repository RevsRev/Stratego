using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgStrategoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private bool myTurn = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //I'm not allowed to do anything!
        if (!myTurn)
        {
            return;
        }


    }

    public void nextTurn()
    {
        myTurn = !myTurn;
    }
}
