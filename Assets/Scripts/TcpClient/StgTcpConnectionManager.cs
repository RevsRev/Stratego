using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using UnityEngine;
using System.Threading;

public class StgTcpConnectionManager
{
    private const int THREAD_RESPONSE_SLEEP_MILLIS = 100;
    private TcpClient tcpClient;
    private Thread responseThread;

    String serverIp = "127.0.0.1";
    Int32 port = 13000;

    public StgTcpConnectionManager()
    {
        connect();
        startResponseThread();
    }

    private void connect()
    {
        try
        {
            tcpClient = new TcpClient(serverIp, port);
        }
        //TODO - user friendly stuff when we can't connect!
        catch (ArgumentNullException e)
        {
            Debug.Log("ArgumentNullException: " + e);
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: " + e);
        }

        //If we get this far we know, by design, that we have been accepted into a room on the Svr.
        //TODO - Make this better, e.g. by requesting which rooms are available on the svr and returning them for the user to choose where they want to join.
    }

    /*
     * Used for sending msgs to the server
     */
    public void sendMsg(Byte[] msgData)
    {
        NetworkStream networkStream = tcpClient.GetStream();
        networkStream.Write(msgData, 0, msgData.Length);
    }

    /*
     * Used for receiving msgs from the server
     */
    private void startResponseThread()
    {
        responseThread = new Thread(() =>
        {
            try
            {
                TcpClient client = tcpClient;
                NetworkStream networkStream = client.GetStream();
                Int32 responseBytes;
                Byte[] responseBytesBuffer = new byte[1024];
                String responseString = "";

                while (true)
                {
                    responseBytes = networkStream.Read(responseBytesBuffer, 0, responseBytesBuffer.Length);
                    responseString = System.Text.Encoding.ASCII.GetString(responseBytesBuffer, 0, responseBytes);

                    //TODO - Don't know if we need this check!
                    if (!String.IsNullOrEmpty(responseString))
                    {
                        messageReceived(responseString);
                    }

                    Thread.Sleep(THREAD_RESPONSE_SLEEP_MILLIS);
                }
            }
            catch (Exception e)
            {
                Debug.Log("" + e);
            }
        });
        responseThread.IsBackground = true;
        responseThread.Start();
    }

    /*
     * TODO - parse the message and send it whereever it is needed!
     */
    private void messageReceived(String msg)
    {
        //For testing purposes, I'm just going to log the message for now
        Debug.Log(msg);
    }

    public static void testConnection(String server, String message)
    {
        try
        {
            Debug.Log("Attempting to connect to server");

            Int32 port = 13000;
            TcpClient client = new TcpClient(server, port);

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);

            Byte[] responseBytesBuffer = new byte[1024];
            Int32 bytes = stream.Read(responseBytesBuffer, 0, responseBytesBuffer.Length);
            String responseData = System.Text.Encoding.ASCII.GetString(responseBytesBuffer, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Debug.Log("ArgumentNullException: " + e);
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: " + e);
        }
    }
}