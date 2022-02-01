using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StgClient : MonoBehaviour
{
    public void Start()
    {
        //For testing purposes, we just create a StgGame and then add all the controllers for it.
        StgGame game = new StgGame();
        GameObject stgGameObject = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_GAME_CONTROLLER);
        StgGameController stgGameController = stgGameObject.GetComponent<StgGameController>();
        stgGameController.init(game);
    }
}