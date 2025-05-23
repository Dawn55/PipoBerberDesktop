using Dapper;
using Microsoft.Data.SqlClient;
using PipoBerberDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Repositories
{
    public class AppointmentRepository
    {
        private readonly SqlConnection _connection;

        public AppointmentRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public async  Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {

            string query = @"
            SELECT 
                a.id, 
                a.userId, 
                a.description, 
                a.date, 
                a.time, 
                a.status,
                a.token,
                a.createdAt,
                u.name + ' ' + u.surname as UserFullName
            FROM Appointments a
            INNER JOIN Users u ON a.userId = u.id
            ORDER BY a.date DESC, a.time DESC";

            // Genişletilmiş veri modelini tutmak için anonim bir tip kullanıyoruz
            var appointmentsWithUserNames = _connection.QueryAsync<Appointment>(query);
            return  await appointmentsWithUserNames;
        }


    }
}
