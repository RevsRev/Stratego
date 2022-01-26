using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StgResourceLoader
{
    /*
     * Files
     */
    public static readonly string PATH_BAORD = "Board/";
    public static readonly string PATH_PIECES = "BoardPieces/";

    /*
     * Prefabs
     */
    public static readonly string PREFAB_TILE_HIGHLIGHT = PATH_BAORD + "TileHighlightPrefab";
    public static readonly string PREFAB_PIECE_GENERAL = PATH_PIECES + "stratego_general";

    public static GameObject createFromPrefab(string prefabPath)
    {
        return Resources.Load<GameObject>(prefabPath);
    }

}