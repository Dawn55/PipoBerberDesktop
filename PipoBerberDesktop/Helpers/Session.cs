using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Helpers
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserSurname { get; set; }
        public static string UserPhone { get; set; }
        public static string UserEmail { get; set; } 
        public static bool IsAdmin { get; set; }
        public static bool IsGuest { get; set; }
    }
}
