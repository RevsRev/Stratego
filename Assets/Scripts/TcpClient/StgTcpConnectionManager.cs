using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

public class StgTcpConnectionManager
{
    private TcpClient tcpClient;

    public StgTcpConnectionManager()
    {

    }

    public static void testConnection(String server, String message)
    {
        try
        {
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
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
    }
}