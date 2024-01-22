using System.Runtime.CompilerServices;

namespace TaskThree
{
    internal class Program
    {
        //Добавляем многопоточность в чат позволяя серверной части получать сообщения сразу от нескольких респондентов.Перепишем многопоточность с помощью Task
        
        static async Task Main(string[] args)
        {
            
            if (args.Length == 0)
            {
                
                await Server.AcceptMessage();
            }
            else
            {
                await Client.SendMessage($"{args[0]}");
            }
        }
    }
}
