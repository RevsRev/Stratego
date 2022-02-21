using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StgPlayerController : MonoBehaviour
{
    public StgPlayer player;
    private StgTileSelector stgTileSelector;

    // Start is called before the first frame update
    void Start()
    {
        stgTileSelector = new StgTileSelector(player);
    }

    // Update is called once per frame
    void Update()
    {
        bool leftMouseDown = Input.GetMouseButtonDown(0);
        stgTileSelector.updateLeftMouse(leftMouseDown);

        if (!leftMouseDown)
        {
            doKeyPress();
        }
         
    }

    private void doKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            makeReady();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            player.game.board.randomlyFill(player.team);
        }
    }

    private void makeReady()
    {
        player.makeReady();
    }

    private void FixedUpdate()
    {
        if (!myTurn())
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        StgBoardTile tileHit = null;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name == "StrategoBoard")
            {
                tileHit = player.game.board.getTileForGridPoint(GridGeometry.GridFromPoint(hit.point));
            }
        }
        stgTileSelector.updateSelection(tileHit);
    }

    private bool myTurn()
    {
        //While preparing the game, both players can move all their pieces freely.
        if (!player.ready)
        {
            return true;
        }
        //This player is ready but the other isn't
        else if (!player.game.ready())
        {
            return false;
        }

        return player.myTurn;
    }
}