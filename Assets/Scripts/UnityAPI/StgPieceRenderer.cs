using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StgPieceRenderer : MonoBehaviour
{
    public StgAbstractPiece piece;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        //TODO - need to work out what piece this instance relates to!
    }

    // Update is called once per frame
    void Update()
    {
        if (piece == null)
        {
            return;
        }

        if (!piece.alive)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector2Int? pos = piece.getPosition();
        if (pos != null)
        {
            transform.position = GridGeometry.PointFromGrid((Vector2Int)pos);
        }
       
    }

    private void initColor()
    {
        if (piece.team == StgAbstractPiece.TEAM_BLUE)
        {
            color = Color.blue;
            color.r = 0.2f;
            color.g = 0.2f;
        }
        else if (piece.team == StgAbstractPiece.TEAM_RED)
        {
            color = Color.red;
            color.b = 0.2f;
            color.g = 0.2f;
        }
        else
        {
            color = Color.white;
        }


        GetComponent<SpriteRenderer>().color = color;
    }

    public static void factory(StgAbstractPiece piece)
    {
        GameObject obj = null;
        if (piece is StgMarshal)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_MARSHAL);
        }
        else if (piece is StgGeneral)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_GENERAL);
        }
        else if (piece is StgColonel)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_COLONEL);
        }
        else if (piece is StgMajor)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_MAJOR);
        }
        else if (piece is StgCaptain)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_CAPTAIN);
        }
        else if (piece is StgLieutenant)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_LIEUTENANT);
        }
        else if (piece is StgSergeant)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_SERGENT);
        }
        else if (piece is StgMiner)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_MINER);
        }
        else if (piece is StgScout)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_SCOUT);
        }
        else if (piece is StgSpy)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_SPY);
        }
        else if (piece is StgMine)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_MINE);
        }
        else if (piece is StgFlag)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_FLAG);
        }

        //If we haven't made a piece, just return out.
        if (obj == null)
        {
            return;
        }

        GameObject constructedObj = MonoBehaviour.Instantiate(obj);
        StgPieceRenderer stgPieceRenderer = constructedObj.GetComponent<StgPieceRenderer>();
        stgPieceRenderer.piece = piece;
        stgPieceRenderer.initColor();
    }

}
