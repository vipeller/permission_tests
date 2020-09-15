using System;
using System.IO;
using System.IO.Pipes;

namespace PipeServer
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("creating named pipe");
                using (var server = new NamedPipeServerStream("some_pipe_name", PipeDirection.InOut))
                {
                    Console.WriteLine("named pipe created");

                    Console.WriteLine("waiting for connections...");
                    server.WaitForConnection();
                    Console.WriteLine("client connected");

                    using (StreamWriter stream = new StreamWriter(server))
                    {
                        Console.WriteLine("writing pipe");
                        stream.WriteLine("hello");
                        Console.WriteLine("message written");
                    }
                }

                Console.WriteLine("test finished without error");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
    }
}
