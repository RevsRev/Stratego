using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

public class StgConnectionRunnable
{
    private TcpListener listener = null;
    public String state { get; private set; } = "";

    public StgConnectionRunnable(IPAddress localAddress, Int32 port) 
    {
        initListener(localAddress, port);
    }

    private void initListener(IPAddress localAddress, Int32 port)
    {
        listener = new TcpListener(localAddress, port);
    }

    public void run()
    {
        while(true)
        {
            try
            {
                listener.Start();

                Byte[] bytes = new Byte[1024];
                String data = null;

                while (true)
                {
                    Console.Write("Waiting for a connection...");

                    TcpClient client = listener.AcceptTcpClient();
                    //Console.WriteLine("Connection accepted!");
                    state = "Connection accepted";

                    if (StgSvr.the().acceptClient(client))
                    {
                        //Do we need to do anything here?
                    }
                    else {
                        //TODO - some code here to send a rejection message back to the client.

                        client.Close();
                    }

                    //data = null;

                    //NetworkStream stream = client.GetStream();
                    //int i = 0;

                    //while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    //{
                    //    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    //    //Console.WriteLine("Received {0}", data);
                    //    state = "Received " + data;

                    //    data = data.ToUpper();

                    //    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    //    stream.Write(msg, 0, msg.Length);
                    //    //Console.WriteLine("Sent {0}", data);
                    //    state = "Sent " + data;
                    //}

                    //client.Close();
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


}