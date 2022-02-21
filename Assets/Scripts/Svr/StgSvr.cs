using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using UnityEngine; //Need to remove this, just for testing

/*
 * Main Svr Class for Stratego.
 * It's only job is to keep track of the state of a game, and validate whether requests are allowed to happen or not.
 */

public class StgSvr
{
    private static readonly object padlock = new object();
    private static StgSvr theServer = new StgSvr();

    private const int NUM_ROOMS = 100;
    private List<StgRoom> rooms = new List<StgRoom>();

    private const int NUM_CONNECTION_THREADS = 10;
    private List<Thread> threads = new List<Thread>();

    private IPAddress localAddr = IPAddress.Parse("127.0.0.1");
    Int32 START_PORT = 1300;

    private TcpListener listener;

    /*
     * Entry point to our program to start up the server.
     */
    //static void Main(String[] args)
    //{
    //    StgSvr theServer = the();
    //    while (!theServer.exit())
    //    {
    //        Thread.Sleep(1000);
    //    }
    //}
    public static StgSvr the()
    {
        if (theServer == null)
        {
            lock(padlock)
            {
                if (theServer == null)
                {
                    theServer = new StgSvr();
                }
            }
        }
        return theServer;
    }

    private StgSvr()
    {
        initRooms();
        initThreads();
        go();
    }

    private void initRooms()
    {
        for (int i=0; i<NUM_ROOMS; i++)
        {
            rooms.Add(new StgRoom());
        }
    }

    private void initThreads()
    {
        for (int i=0; i<NUM_CONNECTION_THREADS;i++)
        {
            threads.Add
            (
               new Thread(() =>
               {
                   Int32 port = START_PORT + i;
                   StgConnectionRunnable runnable = new StgConnectionRunnable(localAddr, port);
                   runnable.run();
               })
            );
        }
    }

    private void go()
    {
        for (int i=0; i<threads.Count; i++)
        {
            threads[i].Start();
        }
    }

    public bool exit()
    {
        return false;
    }

    public bool acceptClient(TcpClient client)
    {
        for (int i=0; i<rooms.Count; i++)
        {
            StgRoom room = rooms[i];
            if (!room.isFull())
            {
                //Could fail if mulitple people try to join at the same time.
                return room.join(client);
            }
        }
        return false;
    }
}
