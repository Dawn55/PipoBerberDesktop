using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }   // Tarih kısmı
        public TimeSpan Time { get; set; }   // Saat kısmı (SQL'deki TIME tipi için)
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        
    }

}
