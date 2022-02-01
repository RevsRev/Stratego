using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/*
 * When we have constructed a StgGame, create one of these on the client for controlling the game.
 */
public class StgGameController : MonoBehaviour
{
    public StgGame game { get; set; }

    public void Update()
    {
        if (game == null)
        {
            return;
        }
    }

    public void init(StgGame game)
    {
        this.game = game;

        //Construct all the controllers that we need
        //GameObject boardPrefab = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_BOARD);

        //GameObject gObjPlayerBlue = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PLAYER);
        //gObjPlayerBlue.GetComponent<StgPlayerController>().player = game.playerBlue;

        GameObject gObjPlayer = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PLAYER);
        GameObject gObjPlayerRed = MonoBehaviour.Instantiate(gObjPlayer);
        StgPlayerController stgPlayerController = gObjPlayerRed.GetComponent<StgPlayerController>();
        stgPlayerController.player = game.playerRed;

        initPieceControllers();

    }
    private void initPieceControllers()
    {
        List<StgBoardTile> occupiedTiles = game.board.getOccupiedTiles();
        for (int i = 0; i < occupiedTiles.Count; i++)
        {
            StgAbstractPiece piece = occupiedTiles[i].piece;
            StgPieceController.factory(piece);
        }
    }
}
