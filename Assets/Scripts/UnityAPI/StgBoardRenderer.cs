using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgBoardRenderer : MonoBehaviour
{
    private StgTileSelector stgTileSelector = new StgTileSelector();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initing board renderer");
    }

    // Update is called once per frame
    void Update()
    {
        stgTileSelector.updateLeftMouse(Input.GetMouseButtonDown(0));
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        StgBoardTile tileHit = null;
        if (Physics.Raycast(ray, out hit))
        {
            tileHit = StgGameHandler.theGame().board.getTileForGridPoint(GridGeometry.GridFromPoint(hit.point));

        }
        stgTileSelector.updateSelection(tileHit);
    }

   
}
