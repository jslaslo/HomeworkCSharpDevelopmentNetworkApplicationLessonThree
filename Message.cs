using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskThree
{
    internal class Message
    {
        public string Name { get; set; }

        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public static Message? FromJson(string somemessage)
        {
            return JsonSerializer.Deserialize<Message>(somemessage);
        }
        public Message(string nickname, string text)
        {
            Name = nickname;
            Text = text;
            DateTime = DateTime.Now;
        }
        public Message()
        {
            
        }

        public override string ToString()
        {
            return $"Получено сообщение от {Name} ({DateTime.ToShortDateString()}): \n{Text}";
        }
    }
}
