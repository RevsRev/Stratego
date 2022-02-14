using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading;

public class StgClient : MonoBehaviour
{
    public void Start()
    {
        //Going to do some connection testing here...
        testSvrAndClient();

        //For testing purposes, we just create a StgGame and then add all the controllers for it.
        StgGame game = new StgGame();
        GameObject stgGameObject = StgResourceLoader.createFromPrefab(StgResourceLoader.PREFAB_GAME_CONTROLLER);
        StgGameController stgGameController = stgGameObject.GetComponent<StgGameController>();
        stgGameController.init(game);
    }

    private void testSvrAndClient()
    {
        Thread svrThread = new Thread(() =>
        {
            StgSvr svr = new StgSvr();
            svr.doMain();
        });

        Thread clientThread = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(10000);
                StgTcpConnectionManager.testConnection("127.0.0.1", "Hello World!");
            }
        });

        svrThread.Start();
        clientThread.Start();
    }
}