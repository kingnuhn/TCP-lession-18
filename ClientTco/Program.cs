using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientTco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ip = "107.0.0.1";
            const int port = 8083;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);

            Console.WriteLine("Введите сообщение");
            var message = Console.ReadLine();

            var data = Encoding.UTF8.GetBytes(message);
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);

            byte[] buffer = new byte[256];
            int size = 0;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size);
            } while (tcpSocket.Available > 0);

            Console.WriteLine(answer.ToString());
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();



        }
    }
}
