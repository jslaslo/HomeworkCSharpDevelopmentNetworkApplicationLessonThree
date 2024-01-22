using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TaskThree
{

    internal class Client
    {      
        public static async Task SendMessage(string name)
        {
            bool isWork = true;
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            UdpClient udpClient = new UdpClient();

            while (isWork)
            {
                Console.WriteLine("Введите сообщение");
                string text = Console.ReadLine();

                if (text.ToLower() == "exit")
                {
                    isWork = false;
                }
                Message message = new Message(name, text);
                string responseMessageJson = message.ToJson();
                byte[] responseData = Encoding.UTF8.GetBytes(responseMessageJson);
                await udpClient.SendAsync(responseData, responseData.Length, ipEndPoint);

               /* byte[] answerData = udpClient.Receive(ref ipEndPoint);
                string answerMessageJson = Encoding.UTF8.GetString(answerData);
                Message answerMessage = Message.FromJson(answerMessageJson);
                Console.WriteLine(answerMessage.ToString());*/

            }

        }
    }
}
