using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading;

public class StgClient : MonoBehaviour
{
    public bool localGame = true;

    public void Start()
    {
        //Going to do some connection testing here...
        //testSvrAndClient();

        //For testing purposes, we just create a StgGame and then add all the controllers for it.
        StgGame game = new StgGame(localGame);
        GameObject stgGameObject = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_GAME_CONTROLLER);
        StgGameController stgGameController = stgGameObject.GetComponent<StgGameController>();
        stgGameController.init(game);
    }
}