using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int Sender_Id { get; set; }
        public int Receiver_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
