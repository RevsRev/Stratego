using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StgTileSelector
{

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
    public StgTileSelector()
    {
        initTileHighlights();
    }

    /*
     * Methods
     */
    private void initTileHighlights()
    {
        Vector2Int gridPoint = GridGeometry.GridPoint(0, 0);
        Vector3 point = GridGeometry.PointFromGrid(gridPoint);

        tileHighlightHover = MonoBehaviour.Instantiate(tileHighlightPrefab, point, Quaternion.identity);
        tileHighlightHover.SetActive(false);

        tileHighlightSelected = MonoBehaviour.Instantiate(tileHighlightPrefab, point, Quaternion.identity);
        tileHighlightSelected.SetActive(false);
    }

    public void updateLeftMouse(bool pressed)
    {
        leftClick = !leftMousePressed && pressed;
        leftMousePressed = pressed;
    }
    public void updateSelection(StgBoardTile boardTileHover)
    {
        if (leftClick)
        {
            //Clicking the same tile again will deselect it, as will clicking in empty space.
            if (boardTileSelected == boardTileHover
              || boardTileHover == null)
            {
                boardTileSelected = null;
            }
            else if (boardTileSelected == null)
            {
                boardTileSelected = boardTileHover;
            }
        }

        updateHighlights();
    }
    private void updateHighlights()
    {
        if (boardTileHover != null)
        {
            tileHighlightHover.transform.position = GridGeometry.PointFromGrid(boardTileHover.gridLocation);
            tileHighlightHover.SetActive(true);
        }
        else
        {
            tileHighlightHover.SetActive(false);
        }

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
}