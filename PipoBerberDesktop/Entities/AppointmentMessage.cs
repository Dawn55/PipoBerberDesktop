using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Entities
{
    public class AppointmentMessage
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
