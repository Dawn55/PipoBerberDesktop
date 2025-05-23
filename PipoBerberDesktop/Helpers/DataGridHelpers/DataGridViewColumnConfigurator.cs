using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipoBerberDesktop.Helpers.DataGridHelpers
{
    public class DataGridViewColumnConfigurator
    {
        private DataGridView _dataGridView;
        public DataGridViewColumnConfigurator(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
        }
        public void ConfigureAppointmentColumns()
        {
            try
            {
                // Önce tüm sütunları sıfırlayalım
                _dataGridView.AutoGenerateColumns = false;

                // DataGridView'ı temizle
                _dataGridView.Columns.Clear();

                // Kolonları manuel olarak ekleyelim
                DataGridViewTextBoxColumn userNameColumn = new DataGridViewTextBoxColumn();
                userNameColumn.DataPropertyName = "UserFullName";
                userNameColumn.HeaderText = "Müşteri";
                userNameColumn.Name = "UserFullName";
                userNameColumn.Width = 150;
                _dataGridView.Columns.Add(userNameColumn);

                DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
                dateColumn.DataPropertyName = "date";
                dateColumn.HeaderText = "Randevu Tarihi";
                dateColumn.Name = "date";
                dateColumn.Width = 120;
                dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
                _dataGridView.Columns.Add(dateColumn);

                DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
                timeColumn.DataPropertyName = "time";
                timeColumn.HeaderText = "Başlangıç Saati";
                timeColumn.Name = "time";
                timeColumn.Width = 100;
                _dataGridView.Columns.Add(timeColumn);

                DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
                statusColumn.DataPropertyName = "status";
                statusColumn.HeaderText = "Durum";
                statusColumn.Name = "status";
                statusColumn.Width = 100;
                _dataGridView.Columns.Add(statusColumn);

                DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
                descriptionColumn.DataPropertyName = "description";
                descriptionColumn.HeaderText = "Açıklama";
                descriptionColumn.Name = "description";
                descriptionColumn.Width = 200;
                _dataGridView.Columns.Add(descriptionColumn);

                DataGridViewTextBoxColumn createdAtColumn = new DataGridViewTextBoxColumn();
                createdAtColumn.DataPropertyName = "createdAt";
                createdAtColumn.HeaderText = "Oluşturulma Tarihi";
                createdAtColumn.Name = "createdAt";
                createdAtColumn.Width = 150;
                createdAtColumn.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                _dataGridView.Columns.Add(createdAtColumn);

                // ID ve diğer görünmez sütunları ekle
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.DataPropertyName = "id";
                idColumn.Name = "id";
                idColumn.Visible = false;
                _dataGridView.Columns.Add(idColumn);

                DataGridViewTextBoxColumn userIdColumn = new DataGridViewTextBoxColumn();
                userIdColumn.DataPropertyName = "userId";
                userIdColumn.Name = "userId";
                userIdColumn.Visible = false;
                _dataGridView.Columns.Add(userIdColumn);

                DataGridViewTextBoxColumn tokenColumn = new DataGridViewTextBoxColumn();
                tokenColumn.DataPropertyName = "token";
                tokenColumn.Name = "token";
                tokenColumn.Visible = false;
                _dataGridView.Columns.Add(tokenColumn);


                FormatStatusColumn();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kolonları ayarlarken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ConfigureAppointmentRepliesColumns()
        {
            try
            {
                // Önce tüm sütunları sıfırlayalım
                _dataGridView.AutoGenerateColumns = false;

                // DataGridView'ı temizle
                _dataGridView.Columns.Clear();

                // Kolonları manuel olarak ekleyelim
                DataGridViewTextBoxColumn senderNameColumn = new DataGridViewTextBoxColumn();
                senderNameColumn.DataPropertyName = "SenderFullName";
                senderNameColumn.HeaderText = "Gönderen";
                senderNameColumn.Name = "SenderFullName";
                senderNameColumn.Width = 150;
                _dataGridView.Columns.Add(senderNameColumn);

                DataGridViewTextBoxColumn senderRoleColumn = new DataGridViewTextBoxColumn();
                senderRoleColumn.DataPropertyName = "SenderRole";
                senderRoleColumn.HeaderText = "Gönderen Rolü";
                senderRoleColumn.Name = "SenderRole";
                senderRoleColumn.Width = 100;
                _dataGridView.Columns.Add(senderRoleColumn);

                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.DataPropertyName = "text";
                textColumn.HeaderText = "Mesaj";
                textColumn.Name = "text";
                textColumn.Width = 300;
                _dataGridView.Columns.Add(textColumn);

                DataGridViewTextBoxColumn createdAtColumn = new DataGridViewTextBoxColumn();
                createdAtColumn.DataPropertyName = "createdAt";
                createdAtColumn.HeaderText = "Gönderilme Zamanı";
                createdAtColumn.Name = "createdAt";
                createdAtColumn.Width = 150;
                createdAtColumn.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                _dataGridView.Columns.Add(createdAtColumn);

                // ID ve diğer görünmez sütunları ekle
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                idColumn.DataPropertyName = "id";
                idColumn.Name = "id";
                idColumn.Visible = false;
                _dataGridView.Columns.Add(idColumn);

                DataGridViewTextBoxColumn appointmentIdColumn = new DataGridViewTextBoxColumn();
                appointmentIdColumn.DataPropertyName = "appointmentId";
                appointmentIdColumn.Name = "appointmentId";
                appointmentIdColumn.Visible = false;
                _dataGridView.Columns.Add(appointmentIdColumn);

                DataGridViewTextBoxColumn senderIdColumn = new DataGridViewTextBoxColumn();
                senderIdColumn.DataPropertyName = "senderId";
                senderIdColumn.Name = "senderId";
                senderIdColumn.Visible = false;
                _dataGridView.Columns.Add(senderIdColumn);

                FormatSenderRoleColumn();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kolonları ayarlarken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatStatusColumn()
        {
            if (_dataGridView.Columns.Contains("status"))
            {
                _dataGridView.CellFormatting += (sender, e) =>
                {
                    if (e.ColumnIndex == _dataGridView.Columns["status"].Index && e.RowIndex >= 0)
                    {

                        var statusValue = Convert.ToInt32(_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);


                        switch (statusValue)
                        {
                            case 0:
                                e.Value = "Beklemede";
                                e.CellStyle.ForeColor = Color.Orange;
                                break;
                            case 1:
                                e.Value = "Onaylandı";
                                e.CellStyle.ForeColor = Color.Green;
                                break;
                            case 2:
                                e.Value = "İptal Edildi";
                                e.CellStyle.ForeColor = Color.Red;
                                break;
                            case 3:
                                e.Value = "Tamamlandı";
                                e.CellStyle.ForeColor = Color.Blue;
                                break;
                            default:
                                e.Value = "Bilinmiyor";
                                break;
                        }
                    }

                };
            }
        }
        public void ConfigureTransactionColumns()
        {
            _dataGridView.Columns.Clear();
            _dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Visible = false
            });
            _dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Type",
                HeaderText = "Tür",
                DataPropertyName = "Type"
            });
            _dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Tutar",
                DataPropertyName = "Amount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            _dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Tarih",
                DataPropertyName = "Date",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });
            _dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Açıklama",
                DataPropertyName = "Description"
            });
            _dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedAt",
                HeaderText = "Oluşturulma Tarihi",
                DataPropertyName = "CreatedAt",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" }
            });
            // Tür sütunu için Türkçe görüntüleme
            _dataGridView.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && _dataGridView.Columns[e.ColumnIndex].Name == "Type")
                {
                    if (e.Value?.ToString() == "income")
                        e.Value = "Gelir";
                    else if (e.Value?.ToString() == "expense")
                        e.Value = "Gider";
                }
            };

            // Color rows based on transaction type 
            //_dataGridView.RowPrePaint += (s, e) =>
            //{
            //    if (e.RowIndex >= 0 && e.RowIndex < _dataGridView.Rows.Count)
            //    {
            //        var row = _dataGridView.Rows[e.RowIndex];
            //        var type = row.Cells["Type"].Value?.ToString();
            //        if (type == "income")
            //            row.DefaultCellStyle.BackColor = Color.LightGreen;
            //        else if (type == "expense")
            //            row.DefaultCellStyle.BackColor = Color.LightCoral;
            //    }
            //};
        }
        private void FormatSenderRoleColumn()
        {
            _dataGridView.CellFormatting += (sender, e) => {
                if (_dataGridView.Columns.Contains("SenderRole") &&
                    e.ColumnIndex == _dataGridView.Columns["SenderRole"].Index &&
                    e.RowIndex >= 0)
                {
                    string roleValue = _dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                    if (roleValue == "Yönetici")
                    {
                        e.CellStyle.ForeColor = Color.Blue;
                        e.CellStyle.BackColor = Color.LightCyan;
                    }
                    else if (roleValue == "Müşteri")
                    {
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.BackColor = Color.LightGreen;
                    }
                }
            };
        }



    }
}