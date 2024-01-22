using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TaskThree
{
    internal class Server
    {
        static private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        static private CancellationToken cancellationToken = cancellationTokenSource.Token;

        private static bool exitRequested = false;

        public static async Task AcceptMessage()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(1234);

            Console.WriteLine("Сервер ожидает сообщения....");

           
            while (!cancellationToken.IsCancellationRequested)
            {
                var data1 = udpClient.Receive(ref ipEndPoint);

                string data = Encoding.UTF8.GetString(data1);

                await Task.Run(async () =>
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        Message message = Message.FromJson(data);
                        Console.WriteLine(message.ToString());
                        Message responseMessage = new Message("Server", "Message accept on serv!");
                        string respunseMessageJson = responseMessage.ToJson();
                        byte[] respunseData = Encoding.UTF8.GetBytes(respunseMessageJson);
                        udpClient.Send(respunseData, respunseData.Length, ipEndPoint);
                        if (message.Text.ToLower() == "exit")
                        {
                            cancellationTokenSource.Cancel();
                        }
                    }
                }, cancellationToken);

               
            }
        }
    }
}
