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
    public static readonly string PATH_CLIENT = "Client/";
    public static readonly string PATH_PLAYER = "Player/";
    public static readonly string PATH_BAORD = "Board/";
    public static readonly string PATH_PIECES = "BoardPieces/";
    public static readonly string PATH_GAME_CONTROLLER = "GameController/";

    /*
     * Prefabs
     */
    public static readonly string PREFAB_CLIENT = PATH_CLIENT + "ClientPrefab";
    public static readonly string PREFAB_PLAYER = PATH_PLAYER + "PlayerPrefab";
    public static readonly string PREFAB_GAME_CONTROLLER = PATH_GAME_CONTROLLER + "GameControllerPrefab";
    public static readonly string PREFAB_BOARD = PATH_BAORD + "BoardPrefab";
    public static readonly string PREFAB_TILE_HIGHLIGHT = PATH_BAORD + "TileHighlightPrefab";
    public static readonly string PREFAB_PIECE_MARSHAL= PATH_PIECES + "stratego-marshal";
    public static readonly string PREFAB_PIECE_GENERAL = PATH_PIECES + "stratego-general";
    public static readonly string PREFAB_PIECE_COLONEL = PATH_PIECES + "stratego-colonel";
    public static readonly string PREFAB_PIECE_MAJOR = PATH_PIECES + "stratego-major";
    public static readonly string PREFAB_PIECE_CAPTAIN = PATH_PIECES + "stratego-captain";
    public static readonly string PREFAB_PIECE_LIEUTENANT = PATH_PIECES + "stratego-lieutenant";
    public static readonly string PREFAB_PIECE_SERGENT = PATH_PIECES + "stratego-sergeant";
    public static readonly string PREFAB_PIECE_MINER = PATH_PIECES + "stratego-miner";
    public static readonly string PREFAB_PIECE_SPY = PATH_PIECES + "stratego-spy";
    public static readonly string PREFAB_PIECE_SCOUT = PATH_PIECES + "stratego-scout";
    public static readonly string PREFAB_PIECE_MINE = PATH_PIECES + "stratego-bomb";
    public static readonly string PREFAB_PIECE_FLAG = PATH_PIECES + "stratego-flag";

    public static GameObject createFromPrefab(string prefabPath)
    {
        return Resources.Load<GameObject>(prefabPath);
    }

}