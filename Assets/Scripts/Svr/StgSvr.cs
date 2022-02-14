using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using UnityEngine; //Need to remove this, just for testing

/*
 * Main Svr Class for Stratego.
 * It's only job is to keep track of the state of a game, and validate whether requests are allowed to happen or not.
 */

public class StgSvr
{
    private TcpListener listener;
    //static void Main(String[] args)
    //{
    //    //For testing purposes only
    //    bool server = true;

    //    if (server)
    //    {
    //        //create a server
    //        StgSvr theSvr = new StgSvr();
    //        theSvr.doMain();
    //    }
    //    else
    //    {
    //        //try to connect to an existing server
    //        StgTcpConnectionManager.testConnection("127.0.0.1", "Hello World!");
    //    }
    //}

    public StgSvr()
    {
    }

    public void doMain()
    {
        try
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            listener = new TcpListener(localAddr, port);
            listener.Start();

            Byte[] bytes = new Byte[1024];
            String data = null;

            while (true)
            {
                Console.Write("Waiting for a connection...");
                Debug.Log("Waiting for a connection...");

                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Connection accepted!");
                Debug.Log("Connection accepted!");

                data = null;

                NetworkStream stream = client.GetStream();
                int i = 0;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received {0}", data);
                    Debug.Log("Received " + data);

                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent {0}", data);
                    Debug.Log("Sent " + data);
                }

                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            listener.Stop();
        }
    }
}
