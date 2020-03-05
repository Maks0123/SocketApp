using System;
using System.Net.Sockets;

namespace tcpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("tcp client started");
            var message = "GET / HTTP/1.0\nHost: selin.in.ua\n\n";

            try
            {
               var port = 80;
               //var serverAddr = "0.tcp.ngrok.io";
               var serverAddr = "127.0.0.1";
               var client = new TcpClient(serverAddr, port);
               var data = System.Text.Encoding.ASCII.GetBytes(message);
               NetworkStream stream = client.GetStream();

               stream.Write(data, 0, data.Length);

               Console.WriteLine("Sent {0}", message);

               var responseData = new byte[256];
               int bytesRead = stream.Read(responseData, 0, responseData.Length);
               var responseMessage = System.Text.Encoding.ASCII.GetString(responseData, 0, bytesRead);
               Console.WriteLine("Received {0}", responseMessage);
               stream.Close();
               client.Close();

            }
            catch (System.IO.IOException e)
        {
            Console.WriteLine("Error reading from {0}. Message = {1}",  e.Message);
        }
        
          
           
        }
    }
}
