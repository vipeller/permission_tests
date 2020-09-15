using System;
using System.IO;
using System.Net.Sockets;


namespace UdsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string socketFile = "C:\\ProgramData\\iotedge\\mqmt\\sock2";

            if (File.Exists(socketFile))
            {
                File.Delete(socketFile);
            }

            try
            {
                Console.WriteLine("creating unix domain socket endpoint...");
                var endPoint = new UnixDomainSocketEndPoint(socketFile);
                Console.WriteLine("endpoint created");

                Console.WriteLine("creating socket...");
                using (var server = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified))
                {
                    Console.WriteLine("socket created");

                    Console.WriteLine("binding endpoint");
                    server.Bind(endPoint);
                    Console.WriteLine("endpoint bound");

                    Console.WriteLine("start listening...");
                    server.Listen(1);
                    Console.WriteLine("entered listening state");

                    Console.WriteLine("accepting clients...");
                    using (var accepted = server.Accept())
                    {
                        Console.WriteLine("accepted");

                        Console.WriteLine("reading data...");
                        var buff = new byte[256];
                        var received = accepted.Receive(buff);
                        Console.WriteLine("data read, {0} bytes", received);
                    }
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
