using Dapper;
using Microsoft.Data.SqlClient;
using PipoBerberDesktop.Entities;
using PipoBerberDesktop.Helpers;
using PipoBerberDesktop.Helpers.DataGridHelpers;
using PipoBerberDesktop.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipoBerberDesktop
{
    public partial class NavForm : MaterialSkin.Controls.MaterialForm
    {
        private static string connectionString = DatabaseHelper.GetConnectionString();
        private readonly TransactionRepository _transactionRepository = new TransactionRepository(connectionString);
        private readonly AppointmentRepository _appointmentRepository = new AppointmentRepository(connectionString);
        private readonly AppointmentRepliesRepository _appointmentRepliesRepository = new AppointmentRepliesRepository(connectionString);
        private readonly UserRepository _userRepository = new UserRepository(connectionString);
        public NavForm()
        {
            InitializeComponent();
            MaterialSkinManager.ApplyMaterialSkin(this);
        }

        private async void NavForm_Load(object sender, EventArgs e)
        {
            this.Text = "Hoşgeldiniz " + Session.UserName + " " + Session.UserSurname;
            this.Font = new Font("Tahoma", 12, FontStyle.Bold);
            this.MaximizeBox = false;
            comboBoxViewType.SelectedIndex = 0;
            LoadStylesForUsersTab();
            LoadStylesForAppointmentsTab();
            LoadUsers();
            LoadAppointments();
            await LoadTransactions();

        }
        private async void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void LoadUsers()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                DataGridViewColumnConfigurator configurator = new DataGridViewColumnConfigurator(dataGridViewUsers);
                dataGridViewUsers.DataSource = _userRepository.GetAllUsers();
                configurator.ConfigureUsersColumns();
            }
        }
        private void LoadAppointments()
        {
            DataGridViewColumnConfigurator configurator = new DataGridViewColumnConfigurator(dataGridViewAppointments);
            dataGridViewAppointments.DataSource = _appointmentRepository.GetAllAppointments();
            configurator.ConfigureAppointmentColumns();
        }

        private void LoadAppointmentReplies()
        {
            if (dataGridViewAppointments.SelectedRows.Count == 0)
            {
                dataGridViewAppointmentReplies.DataSource = null;
                return;
            }
            int appointmentId = Convert.ToInt32(dataGridViewAppointments.SelectedRows[0].Cells["id"].Value);
            DataGridViewColumnConfigurator configurator = new DataGridViewColumnConfigurator(dataGridViewAppointmentReplies);
            var appointmentMessages = _appointmentRepliesRepository.GetAppointRepliesByAppointmentId(appointmentId);
            dataGridViewAppointmentReplies.DataSource = appointmentMessages;
            configurator.ConfigureAppointmentRepliesColumns();
        }
        private async Task LoadTransactions()
        {
            try
            {

                string viewType = comboBoxViewType.SelectedItem?.ToString() ?? "Tümü";

                var transactions = viewType switch
                {
                    "Bugün" => await _transactionRepository.GetTodayTransactionsAsync(),
                    "Bu Ay" => await _transactionRepository.GetTransactionsByMonthAsync(DateTime.Now.Year, DateTime.Now.Month),
                    "İstenilen Zaman dilimi" => await _transactionRepository.GetTransactionsByDateRangeAsync(dateTimePickerStart.Value.Date, dateTimePickerEnd.Value.Date),
                    "Tümü" => await _transactionRepository.GetAllTransactionsAsync()
                };
                DataGridViewColumnConfigurator configurator = new DataGridViewColumnConfigurator(dataGridViewTransactions);
                configurator.ConfigureTransactionColumns();

                dataGridViewTransactions.DataSource = transactions.ToList();



                await UpdateSummaryLabels(viewType);

                if (dataGridViewTransactions.Columns["Id"] != null)
                {
                    dataGridViewTransactions.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateSummaryLabels(string viewType)
        {
            DateTime? startDate = null, endDate = null;

            switch (viewType)
            {
                case "Bugün":
                    startDate = endDate = DateTime.Now.Date;
                    break;
                case "Bu Ay":
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    endDate = startDate.Value.AddMonths(1).AddDays(-1);
                    break;
                case "İstenilen Zaman dilimi":
                    startDate = dateTimePickerStart.Value.Date;
                    endDate = dateTimePickerEnd.Value.Date;
                    break;
            }

            var summary = await _transactionRepository.GetTransactionSummaryAsync(startDate, endDate);
            var summaryList = summary.ToList();

            var income = summaryList.FirstOrDefault(s => s.Type == "income")?.TotalAmount ?? 0;
            var expenses = summaryList.FirstOrDefault(s => s.Type == "expense")?.TotalAmount ?? 0;
            var balance = income - expenses;

            labelIncome.Text = $"Toplam Gelir: {income:C}";
            labelExpenses.Text = $"Toplam Gider: {expenses:C}";
            labelBalance.Text = $"Net Bakiye: {balance:C}";
            labelBalance.ForeColor = balance >= 0 ? Color.Green : Color.Red;
        }

        private void LoadStylesForUsersTab()
        {
            lblUserName.Font = new Font("Tahoma", 9, FontStyle.Regular);
            lblUserSurname.Font = new Font("Tahoma", 9, FontStyle.Regular);
            lblPhone.Font = new Font("Tahoma", 9, FontStyle.Regular);
            lblEmail.Font = new Font("Tahoma", 9, FontStyle.Regular);
            tbEmail.BackColor = Color.FromArgb(255, 255, 255);
            tbUserName.BackColor = Color.FromArgb(255, 255, 255);
            tbUserSurname.BackColor = Color.FromArgb(255, 255, 255);
            tbPhone.BackColor = Color.FromArgb(255, 255, 255);
            cbRole.BackColor = Color.FromArgb(255, 255, 255);
            tbUserSearch.BackColor = Color.FromArgb(255, 255, 255);
            lblUserSearch.Font = new Font("Tahoma", 9, FontStyle.Regular);

        }
        private void LoadStylesForAppointmentsTab()
        {
            lblStatus.Font = new Font("Tahoma", 9, FontStyle.Regular);
            cbStatus.BackColor = Color.FromArgb(255, 255, 255);
            lblAppointmentSearch.Font = new Font("Tahoma", 9, FontStyle.Regular);
            lblSendReply.Font = new Font("Tahoma", 9, FontStyle.Regular);
            tbSendReply.BackColor = Color.FromArgb(255, 255, 255);
            tbAppointmentSearch.BackColor = Color.FromArgb(255, 255, 255);
            tbSendReply.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                tbUserName.Text = dataGridViewUsers.SelectedRows[0].Cells["name"].Value.ToString();
                tbUserSurname.Text = dataGridViewUsers.SelectedRows[0].Cells["surname"].Value.ToString();
                tbEmail.Text = dataGridViewUsers.SelectedRows[0].Cells["email"].Value.ToString();
                tbPhone.Text = dataGridViewUsers.SelectedRows[0].Cells["PhoneNumber"].Value.ToString();
                cbRole.SelectedItem = dataGridViewUsers.SelectedRows[0].Cells["isAdmin"].Value.ToString() == "True" ? "Yönetici" : "Kullanıcı";

            }
        }

        private async void btnUserUpdate_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Seçili kullanıcıyı güncellemek istediğinize emin misiniz?", "Kullanıcı Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                if (dataGridViewUsers.SelectedRows.Count > 0)
                {

                    int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["id"].Value);

                    if (userId == Session.UserId)
                    {
                        MessageBox.Show("Kendi rolünüzü değiştiremezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string updatedName = tbUserName.Text.Trim();
                    string updatedSurname = tbUserSurname.Text.Trim();
                    string updatedEmail = tbEmail.Text.Trim();
                    string updatedPhone = tbPhone.Text.Trim();
                    bool isAdmin = cbRole.SelectedItem.ToString() == "Yönetici";



                    _userRepository.UpdateUser(new User
                    {
                        Name = updatedName,
                        Surname = updatedSurname,
                        Email = updatedEmail,
                        PhoneNumber = updatedPhone,
                        IsAdmin = isAdmin,
                        UpdatedAt = DateTime.Now,
                        Id = userId
                    });



                    MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    LoadUsers();
                    ClearFields();
                    
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek için bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private async void dataGridViewAppointments_SelectionChanged(object sender, EventArgs e)
        {

            
            if (dataGridViewAppointments.SelectedRows.Count > 0)
            {
                LoadAppointmentReplies();
                cbStatus.SelectedIndex = Convert.ToInt32(dataGridViewAppointments.SelectedRows[0].Cells["status"].Value);
            }
        }
        private void ClearFields()
        {
            tbUserName.Clear();
            tbUserSurname.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
        }

        private void tbUserSearch_TextChanged(object sender, EventArgs e)
        {

            dataGridViewUsers.DataSource = _userRepository.GetFilteredUsers(tbUserSearch.Text);

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["id"].Value);


            if (userId == Session.UserId)
            {
                MessageBox.Show("Kendi hesabınızı silemezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var result = MessageBox.Show("Bu kullanıcıyı silmek istediğinize emin misiniz? Bu işlem, kullanıcının tüm randevularını, mesajlarını ve ilgili diğer verileri de silecektir.",
                                        "Kullanıcı Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _userRepository.DeleteUser(userId);
                    LoadUsers();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Veritabanı bağlantısı sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDeleteAppointment_Click(object sender, EventArgs e)
        {

            if (dataGridViewAppointmentReplies.SelectedRows.Count > 0)
            {

                int replyId = Convert.ToInt32(dataGridViewAppointmentReplies.SelectedRows[0].Cells["id"].Value);


                var result = MessageBox.Show("Seçili mesajı silmek istediğinize emin misiniz?",
                                             "Mesaj Silme",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _appointmentRepliesRepository.DeleteAppointmentReply(replyId);
                        MessageBox.Show("Mesaj başarıyla silindi.",
                                           "İşlem Başarılı",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);


                       LoadAppointmentReplies();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Mesaj silme işlemi sırasında bir hata oluştu: {ex.Message}",
                                       "Hata",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                    }
                }
            }

            else if (dataGridViewAppointments.SelectedRows.Count > 0)
            {

                int appointmentId = Convert.ToInt32(dataGridViewAppointments.SelectedRows[0].Cells["id"].Value);


                var result = MessageBox.Show("Seçili randevuyu ve tüm mesajlarını silmek istediğinize emin misiniz?",
                                             "Randevu Silme",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _appointmentRepository.DeleteAppointment(appointmentId);

                        LoadAppointments();

                        dataGridViewAppointmentReplies.DataSource = null;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Veritabanı bağlantısı sırasında bir hata oluştu: {ex.Message}",
                                       "Hata",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir randevu veya mesaj seçin.",
                               "Uyarı",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        private async void btnUpdateAppointment_Click(object sender, EventArgs e)
        {

            if (dataGridViewAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir randevu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int appointmentId = Convert.ToInt32(dataGridViewAppointments.SelectedRows[0].Cells["id"].Value);


            int newStatus = cbStatus.SelectedIndex;


            var result = MessageBox.Show("Randevu durumunu güncellemek istediğinize emin misiniz?",
                                       "Randevu Güncelleme",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _appointmentRepository.UpdateAppointment(appointmentId, newStatus);

                    MessageBox.Show("Randevu durumu başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    LoadAppointments();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Randevu güncelleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSendReply_Click(object sender, EventArgs e)
        {

            if (dataGridViewAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen yanıt göndermek için bir randevu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(tbSendReply.Text))
            {
                MessageBox.Show("Lütfen göndermek için bir mesaj yazın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int appointmentId = Convert.ToInt32(dataGridViewAppointments.SelectedRows[0].Cells["id"].Value);

            try
            {
                _appointmentRepliesRepository.AddAppointmentReply(new AppointmentMessage
                {
                    AppointmentId = appointmentId,
                    SenderId = Session.UserId,
                    Text = tbSendReply.Text.Trim(),
                    CreatedAt = DateTime.Now
                });


                MessageBox.Show("Yanıtınız başarıyla gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                tbSendReply.Clear();


               LoadAppointmentReplies();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yanıt gönderme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void comboBoxViewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCustomRange = comboBoxViewType.SelectedItem.ToString() == "İstenilen Zaman dilimi";
            dateTimePickerStart.Enabled = isCustomRange;
            dateTimePickerEnd.Enabled = isCustomRange;

            await LoadTransactions();
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditTransactionForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await _transactionRepository.AddTransactionAsync(addForm.Transaction);
                await LoadTransactions();
            }
        }

        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridViewTransactions.SelectedRows[0];
            var transaction = new Transaction
            {
                Id = (int)selectedRow.Cells["Id"].Value,
                Type = selectedRow.Cells["Type"].Value.ToString(),
                Amount = (decimal)selectedRow.Cells["Amount"].Value,
                Date = (DateTime)selectedRow.Cells["Date"].Value,
                Description = selectedRow.Cells["Description"].Value?.ToString()
            };

            var editForm = new AddEditTransactionForm(transaction);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await LoadTransactions();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedRow = dataGridViewTransactions.SelectedRows[0];
                int id = (int)selectedRow.Cells["Id"].Value;

                await _transactionRepository.DeleteTransactionAsync(id);
                await LoadTransactions();
            }
        }

        private async void buttonRefresh_Click(object sender, EventArgs e)
        {
            await LoadTransactions();
        }

        private void tbAppointmentSearch_TextChanged(object sender, EventArgs e)
        {
            DataGridViewColumnConfigurator configurator = new DataGridViewColumnConfigurator(dataGridViewAppointments);
            dataGridViewAppointments.DataSource = _appointmentRepository.GetFilteredAppointments(tbAppointmentSearch.Text.Trim().ToLower());
            configurator.ConfigureAppointmentColumns();

        }

        private void dataGridViewUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "Rol" && e.Value != null)
            {
                bool isAdmin = (bool)e.Value;
                e.Value = isAdmin ? "Yönetici" : "Kullanıcı";
                e.FormattingApplied = true;
            }
        }

    }
}