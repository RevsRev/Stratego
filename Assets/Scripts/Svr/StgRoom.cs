using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

/*
 * A room is used for hosting a game of stratego. The server will have multiple rooms for mulitple games.
 */
public class StgRoom
{
    private TcpClient clientOne = null;
    private TcpClient clientTwo = null;

    private readonly object padlock = new Object();

    //Not currently using this for anything but feels like it will be useful
    private Thread gameThread = null;

    public StgRoom()
    {

    }

    public void start()
    {
        if (!isFull())
        {
            return;
        }

        gameThread = new Thread(() =>
        {
            play();
        });

        gameThread.Start();
    }

    public void play()
    {
        while (true)
        {
            //TODO
            //Play the game
            Thread.Sleep(100);
        }
    }

    /*
     * Threadsafe method for joining a room.
     */
    public bool join(TcpClient clientRequest)
    {
        lock (padlock)
        {
            if (clientOne == null)
            {
                clientOne = clientRequest;
                return true;
            }

            if (clientTwo == null)
            {
                clientTwo = clientRequest;
                start(); //Now we have two players, start the game!
                return true;
            }
        
        }
        return false;
    }

    public bool isFull()
    {
        return clientOne != null && clientTwo != null;
    }
}
