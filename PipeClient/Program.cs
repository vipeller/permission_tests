using System;
using System.IO;
using System.IO.Pipes;

namespace PipeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("creating named pipe");
                using (var client = new NamedPipeClientStream(".", "some_pipe_name", PipeDirection.InOut))
                {
                    Console.WriteLine("named pipe created");
                    Console.Write("connecting...");
                    client.Connect();
                    Console.WriteLine("connected");

                    using (var sr = new StreamReader(client))
                    {
                        Console.WriteLine("reading pipe");
                        var message = sr.ReadLine();
                        Console.WriteLine("Received: {0}", message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
    }
}
