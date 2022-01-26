using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgBoardRenderer : MonoBehaviour
{
    private StgTileSelector stgTileSelector;

    // Start is called before the first frame update
    void Start()
    {
        initPieceRenderers();

        stgTileSelector = new StgTileSelector();
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

    private void initPieceRenderers()
    {
        List<StgBoardTile> occupiedTiles = StgGameHandler.theGame().board.getOccupiedTiles();
        for (int i = 0; i < occupiedTiles.Count; i++)
        {
            StgAbstractPiece piece = occupiedTiles[i].piece;
            StgPieceRenderer.construct(piece);
        }
    }
   
}
