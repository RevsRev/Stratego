using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StgTileSelector
{

    private StgPlayer player;

    /*
     * Variables
     */
    public GameObject tileHighlightPrefab;
    public GameObject tileHighlightHover { get; private set; }
    public GameObject tileHighlightSelected { get; private set; }

    //TOOD - See if we care about adding a color!
    private Color highlightColor;

    public StgBoardTile boardTileHover { get; set; }
    public StgBoardTile boardTileSelected { get; set; }

    private bool leftMousePressed = false;
    private bool leftClick = false;

    /*
     * Constructor
     */
    public StgTileSelector(StgPlayer player)
    {
        this.player = player;
        initTileHighlights();
    }

    /*
     * Methods
     */
    private void initTileHighlights()
    {
        Vector2Int gridPoint = GridGeometry.GridPoint(0, 0);
        Vector3 point = GridGeometry.PointFromGrid(gridPoint);

        tileHighlightPrefab = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_TILE_HIGHLIGHT);

        tileHighlightHover = MonoBehaviour.Instantiate(tileHighlightPrefab, point, Quaternion.identity);
        tileHighlightHover.SetActive(false);

        tileHighlightSelected = MonoBehaviour.Instantiate(tileHighlightPrefab, point, Quaternion.identity);
        tileHighlightSelected.SetActive(false);
    }

    public void updateLeftMouse(bool pressed)
    {
        if (!leftClick && pressed)
        {
            leftClick = true;
        }
        else if (leftClick && !pressed)
        {
            leftClick = false;
        }

        if (leftClick)
        {
            //Clicking the same tile again will deselect it, as will clicking in empty space.
            doLeftClick();
        }

        leftMousePressed = pressed;
    }
    private void doLeftClick()
    {
        doSelect();
        doMove();
        updateSelectedHighlights();
    }

    private void doSelect()
    {
        if (boardTileHover == boardTileSelected
          || boardTileHover == null)
        {
            boardTileSelected = null;
        }
        else if (boardTileSelected == null
          && boardTileHover.getOccupyingTeam() == player.team)
        {
            boardTileSelected = boardTileHover;
        }
    }

    private void doMove()
    {
        if (boardTileSelected != null
          && boardTileSelected.piece != null
          && boardTileSelected != boardTileHover)
        {
            List<StgBoardTile> allowedMoves = boardTileSelected.piece.getAllowedMoves();
            if (allowedMoves.Contains(boardTileHover))
            {
                boardTileSelected.piece.doMove(boardTileHover);
                endTurn();
            }
        }
    }

    private void endTurn()
    {
        tileHighlightHover.SetActive(false);
        tileHighlightSelected.SetActive(false);
        boardTileHover = null;
        boardTileSelected = null;
        player.nextTurn();
    }
    public void updateSelection(StgBoardTile boardTileHoverUpdate)
    {
        boardTileHover = boardTileHoverUpdate;
        updateHoverHighlights();
    }

    //TODO - offload the selected tile to the click performed...
    private void updateSelectedHighlights()
    {
        if (boardTileSelected != null)
        {
            tileHighlightSelected.transform.position = GridGeometry.PointFromGrid(boardTileSelected.gridLocation);
            tileHighlightSelected.SetActive(true);
        }
        else
        {
            tileHighlightSelected.SetActive(false);
        }
    }

    private void updateHoverHighlights()
    {
        if (boardTileHover == null)
        {
            tileHighlightHover.SetActive(false);
            return;
        }

        if (boardTileHover.getOccupyingTeam() != player.team
          && boardTileSelected == null)
        {
            tileHighlightHover.SetActive(false);
            return;
        }

        if (boardTileSelected != null)
        {
            List<StgBoardTile> allowedHighlights = boardTileSelected.getAvailableMovesForPiece();
            if (!allowedHighlights.Contains(boardTileHover))
            {
                tileHighlightHover.SetActive(false);
                return;
            }
        }

        tileHighlightHover.transform.position = GridGeometry.PointFromGrid(boardTileHover.gridLocation);
        tileHighlightHover.SetActive(true);
    }
}