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
        stgTileSelector.updateLeftMouse(Input.GetMouseButtonDown(0));
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
            tileHit = player.game.board.getTileForGridPoint(GridGeometry.GridFromPoint(hit.point));
        }
        stgTileSelector.updateSelection(tileHit);
    }

    private bool myTurn()
    {
        return player.myTurn;
    }
}