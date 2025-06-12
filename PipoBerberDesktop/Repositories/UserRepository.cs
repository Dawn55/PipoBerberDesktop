using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using PipoBerberDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = PipoBerberDesktop.Entities.User;

namespace PipoBerberDesktop.Repositories
{

    public class UserRepository
    {
        private readonly NpgsqlConnection _connection;
        public UserRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public List<User> GetAllUsers()
        {
            var users = _connection.Query<User>("SELECT * FROM Users").ToList();
            return users;
        }
        public List<User> GetFilteredUsers(string searchTerm)
        {
            var users = _connection.Query<User>("SELECT * FROM Users WHERE name LIKE @SearchTerm", new { SearchTerm = $"%{searchTerm}%" }).ToList();
            return users;
        }
        public void UpdateUser(User user)
        {
            string updateQuery = @"
                    UPDATE Users 
                    SET 
                        name = @Name, 
                        surname = @Surname, 
                        email = @Email, 
                        PhoneNumber = @PhoneNumber, 
                        isAdmin = @IsAdmin, 
                        UpdatedAt = @UpdatedAt
                    WHERE id = @Id";
            _connection.Execute(updateQuery, user);
        }
        public void DeleteUser(int userId)
        {
            _connection.Open();
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {

                    _connection.Execute(
                        @"DELETE FROM AppointmentMessages 
                              WHERE appointmentId IN (SELECT id FROM Appointments WHERE userId = @UserId)
                              OR senderId = @UserId",
                        new { UserId = userId }, transaction);


                    _connection.Execute("DELETE FROM Appointments WHERE userId = @UserId",
                        new { UserId = userId }, transaction);


                    _connection.Execute("DELETE FROM Messages WHERE sender_id = @UserId OR receiver_id = @UserId",
                        new { UserId = userId }, transaction);


                    _connection.Execute("DELETE FROM Users WHERE id = @UserId",
                        new { UserId = userId }, transaction);


                    transaction.Commit();
                    MessageBox.Show("Kullanıcı ve ilişkili tüm veriler başarıyla silindi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }
    }
}