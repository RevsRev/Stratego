using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StgScout : StgAbstractPiece
{
    public StgScout(int team) : base(team)
    {
    }

    public override List<StgBoardTile> getAllowedMoves()
    {
        List <StgBoardTile> allowedMoves = new List<StgBoardTile> ();

        StgBoardTile leftNeighbour = tile.leftNeighbour;
        StgBoardTile rightNeighbour = tile.rightNeighbour;
        StgBoardTile topNeighbour = tile.topNeighbour;
        StgBoardTile bottomNeighbour = tile.bottomNeighbour;

        while (leftNeighbour != null 
          && leftNeighbour.getOccupyingTeam() != team)
        {
            allowedMoves.Add(leftNeighbour);
            if (leftNeighbour.getOccupyingTeam() != StgAbstractPiece.TEAM_UNASSIGNED)
            {
                break;
            }

            leftNeighbour = leftNeighbour.leftNeighbour;
        }

        while (rightNeighbour != null
          && rightNeighbour.getOccupyingTeam() != team)
        {
            allowedMoves.Add(rightNeighbour);
            if (rightNeighbour.getOccupyingTeam() != StgAbstractPiece.TEAM_UNASSIGNED)
            {
                break;
            }

            rightNeighbour = rightNeighbour.rightNeighbour;
        }

        while (topNeighbour != null
          && topNeighbour.getOccupyingTeam() != team)
        {
            allowedMoves.Add(topNeighbour);
            if (topNeighbour.getOccupyingTeam() != StgAbstractPiece.TEAM_UNASSIGNED)
            {
                break;
            }

            topNeighbour = topNeighbour.topNeighbour;
        }

        while (bottomNeighbour != null
          && bottomNeighbour.getOccupyingTeam() != team)
        {
            allowedMoves.Add(bottomNeighbour);
            if (bottomNeighbour.getOccupyingTeam() != StgAbstractPiece.TEAM_UNASSIGNED)
            {
                break;
            }

            bottomNeighbour = bottomNeighbour.bottomNeighbour;
        }

        return allowedMoves;
    }

    public override List<Type> reallyGetTypesAttackBeats()
    {
        List<Type> retval = new List<Type>();
        retval.Add(typeof(StgSpy));
        retval.Add(typeof(StgFlag));

        return retval;
    }
}
