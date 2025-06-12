using Dapper;
using Microsoft.Data.SqlClient;
using PipoBerberDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PipoBerberDesktop.Repositories
{
    public class AppointmentRepository
    {
        private readonly NpgsqlConnection _connection;

        public AppointmentRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }
        public List<dynamic> GetAllAppointments()
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
            var appointmentsWithUserNames = _connection.Query(query);
            return appointmentsWithUserNames.ToList();
        }
        public List<dynamic> GetFilteredAppointments(string searchTearm)
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
            WHERE name LIKE @SearchTerm
            ORDER BY a.date DESC, a.time DESC";

            var appointmentsWithUserNames = _connection.Query(query, new { SearchTerm = "%" + searchTearm + "%" });
            return appointmentsWithUserNames.ToList();


        }
        public void UpdateAppointment(int appointmentId, int status)
        {

            string updateQuery = "UPDATE Appointments SET status = @Status WHERE id = @Id";

            _connection.Execute(updateQuery, new
            {
                Status = status,
                Id = appointmentId
            });
        }
        public void DeleteAppointment(int appointmentId)
        {
            _connection.Open();
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {


                    _connection.Execute("DELETE FROM AppointmentMessages WHERE appointmentId = @AppointmentId",
                                     new { AppointmentId = appointmentId }, transaction);


                    _connection.Execute("DELETE FROM Appointments WHERE id = @AppointmentId",
                                     new { AppointmentId = appointmentId }, transaction);


                    transaction.Commit();
                    _connection.Close();

                    MessageBox.Show("Randevu ve ilişkili tüm mesajlar başarıyla silindi.",
                                  "İşlem Başarılı",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Randevu silme işlemi sırasında bir hata oluştu: {ex.Message}",
                                  "Hata",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }

            }

        }

    }
}