using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace tcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Kestrell");
                   string IPaddress;
            try
            {
              
                var port = 80;
                var localAddr = IPAddress.Parse("127.0.0.1");
                var server = new TcpListener(localAddr, port);
                server.Start();
                var bytes = new byte[256];
                while (true)
                {
                    Console.Write("waiting for connection");
                    var client = server.AcceptTcpClient();
                    Console.WriteLine("Accepted connection from {0}", client.Client.RemoteEndPoint);
                    NetworkStream stream = client.GetStream();
                    var bytesReadCount = stream.Read(bytes, 0, bytes.Length);
                    var data = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesReadCount);
                    data = data.ToUpper();
                    var response = System.Text.Encoding.ASCII.GetBytes(data);
                    stream.Write(response, 0, response.Length);
                    Console.WriteLine("sent: {0}", data);
                    client.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0}", e);
            }
        }
    }
}
