using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerClientConsole
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 888;
        public static TcpListener listener;

        static ASCIIEncoding encoding = new ASCIIEncoding();

        public static void Main()
        {
            try
            {
                IPAddress address = IPAddress.Parse("127.0.0.1");

                listener = new TcpListener(address, PORT_NUMBER);
                listener.Start();
                Console.WriteLine("Server started on " + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");

                // 1. listen
                while (true)
                {
                    Socket socket = listener.AcceptSocket();
                    Thread thread = new Thread(ContectClient);
                    thread.Start(socket);
                }
                listener.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            Console.Read();
        }

        public static void ContectClient(object obj)
        {
            Socket socket = obj as Socket;
            Console.WriteLine("Connection received from " + socket.RemoteEndPoint);

            var stream = new NetworkStream(socket);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            while (true)
            {
                // 2. receive
                string str = reader.ReadLine();
                if (str.ToUpper() == "EXIT")
                {
                    writer.WriteLine("bye");
                    break;
                }
                // 3. send
                writer.WriteLine("Hello " + str);
            }
            // 4. close
            stream.Close();
            socket.Close();
        }
    }
}
