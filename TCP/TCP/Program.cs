using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    class Program
    {
        static void Task Main(string[] args)
        {
            Console.WriteLine("Hello!");
            int toSend = Convert.ToInt32(Console.ReadLine());
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 1337);
            NetworkStream stream = client.GetStream();
            byte[] dataToSend = Encoding.ASCII.GetBytes(toSend.ToString());
            stream.Write(dataToSend, 0, dataToSend.Length);
            byte[] dataReceived = new byte[4];
            stream.Read(dataReceived, 0, dataReceived.Length);
            Console.WriteLine(Encoding.ASCII.GetString(dataReceived));
            stream.Close(0);
            client.Close();
        }
    }
}
