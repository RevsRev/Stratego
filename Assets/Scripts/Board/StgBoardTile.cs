using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgBoardTile
{
    /*
     * Class variables
     */
    public StgBoardTile leftNeighbour { get; set; }
    public StgBoardTile rightNeighbour { get; set; }
    public StgBoardTile topNeighbour { get; set; }
    public StgBoardTile bottomNeighbour { get; set; }

    public StgAbstractPiece piece { get; set; }

    public Vector2Int gridLocation { get; set; }

    private List<StgBoardTile> neighbours = null;

    /*
     * Methods
     */
    public StgBoardTile(Vector2Int gridLocation)
    {
        this.gridLocation = gridLocation;
    }

    public List<StgBoardTile> getNeighbours()
    {
        if (neighbours != null)
        {
            return neighbours;
        }

        neighbours = new List<StgBoardTile>();
        
        if (leftNeighbour != null)
        {
            neighbours.Add(leftNeighbour);
        }
        if (rightNeighbour != null)
        {
            neighbours.Add(rightNeighbour);
        }
        if (topNeighbour != null)
        {
            neighbours.Add(topNeighbour);
        }
        if (bottomNeighbour != null)
        {
            neighbours.Add(bottomNeighbour);
        }

        return neighbours;
    }

    public List<StgBoardTile> getAvailableMovesForPiece()
    {
        if (piece != null)
        {
            return piece.getAllowedMoves();
        }

        return new List<StgBoardTile>();
    }

    public int getOccupyingTeam()
    {
        if (piece == null)
        {
            return StgAbstractPiece.TEAM_UNASSIGNED;
        }
        return piece.team;
    }
    public bool occupied()
    {
        return getOccupyingTeam() != StgAbstractPiece.TEAM_UNASSIGNED;
    }
}