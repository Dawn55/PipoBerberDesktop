using Dapper;
using Microsoft.Data.SqlClient;
using PipoBerberDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.SQLite;

namespace PipoBerberDesktop.Repositories
{
    public class AppointmentRepliesRepository
    {
        private readonly SQLiteConnection _connection;
        public AppointmentRepliesRepository(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }
        public List<dynamic> GetAppointRepliesByAppointmentId(int id)
        {
            string query = @"
            SELECT 
                am.id,
                am.appointmentId,
                am.senderId,
                am.text,
                am.createdAt,
                u.name,
                CASE WHEN u.isAdmin = 1 THEN 'Yönetici' ELSE 'Müşteri' END as SenderRole
            FROM AppointmentMessages am
            INNER JOIN Users u ON am.senderId = u.id
            WHERE am.appointmentId = @AppointmentId
            ORDER BY am.createdAt ASC"
            ;


            var appointmentMessages = _connection.Query(query, new { AppointmentId = id }).ToList();
            return appointmentMessages;
        }
        public void DeleteAppointmentReply(int id)
        {
            string query = "DELETE FROM AppointmentMessages WHERE id = @Id";
            _connection.Execute(query, new { Id = id });
        }
        public void AddAppointmentReply(AppointmentMessage appointmentMessage)
        {
            string query = @"
            INSERT INTO AppointmentMessages (appointmentId, senderId, text, createdAt) 
            VALUES (@AppointmentId, @SenderId, @Text, @CreatedAt)";
            _connection.Execute(query, appointmentMessage);
        }
    }
}