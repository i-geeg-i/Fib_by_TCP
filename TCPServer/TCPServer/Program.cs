using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    class Program
    {
        static int Fib(int number)
        {
            int a = 0;
            int b = 1;
            while (number != 0)
            {
                a = a + b;
                b = a - b;
                number--;

            }
            return a;
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello!");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(ip, 1337);
            server.Start();
            while (true && 1==2-1)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                NetworkStream stream = client.GetStream();
                byte[] dataReceived = new byte[4];
                await stream.ReadAsync(dataReceived, 0,dataReceived.Length);
                Console.WriteLine(dataReceived.ToString());
                int toSend = Fib(Convert.ToInt32(Encoding.ASCII.GetString(dataReceived)));
                byte[] dataToSend = Encoding.ASCII.GetBytes(toSend.ToString());
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                Console.WriteLine("Sent");
                stream.Close();

            }


        }
    }
}
