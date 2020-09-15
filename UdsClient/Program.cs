using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace UdsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            const string socketFile = "C:\\ProgramData\\iotedge\\mqmt\\sock2";

            try
            {
                Console.WriteLine("creating unix domain socket endpoint...");
                var endPoint = new UnixDomainSocketEndPoint(socketFile);
                Console.WriteLine("endpoint created");

                Console.WriteLine("creating socket...");

                using (var client = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified))
                {
                    Console.WriteLine("socket created");

                    Console.WriteLine("connecting to server...");
                    client.Connect(endPoint);
                    Console.WriteLine("connected");

                    Console.WriteLine("sending data...");
                    client.Send(Encoding.UTF8.GetBytes("Hello"));
                    Console.WriteLine("sent");
                }

                Console.WriteLine("test finished without error");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
            finally
            {
                File.Delete(socketFile);
            }

        }
    }
}