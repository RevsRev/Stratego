using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StgPieceRenderer : MonoBehaviour
{
    public StgAbstractPiece piece;

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
        transform.position = GridGeometry.PointFromGrid(piece.position);
    }

    public static void construct(StgAbstractPiece piece)
    {
        GameObject obj = null;
        if (piece is StgGeneral)
        {
            obj = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_PIECE_GENERAL);
        }

        //If we haven't made a piece, just return out.
        if (obj == null)
        {
            return;
        }

        GameObject constructedObj = MonoBehaviour.Instantiate(obj);
        constructedObj.GetComponent<StgPieceRenderer>().piece = piece;
    }

}
