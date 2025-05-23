using PipoBerberDesktop.Entities;
using PipoBerberDesktop.Helpers;
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
    public partial class AddEditTransactionForm : MaterialSkin.Controls.MaterialForm
    {

        public Transaction Transaction { get; private set; }
        private readonly bool _isEdit;
        public AddEditTransactionForm(Transaction transaction = null)
        {

            Transaction = transaction ?? new Transaction();
            _isEdit = transaction != null;
            InitializeComponent();
            if (_isEdit)
            {
                LoadTransactionData();
            }
        }

        private void AddEditTransactionForm_Load(object sender, EventArgs e)
        {
            MaterialSkinManager.ApplyMaterialSkin(this);
        }
        private void LoadTransactionData()
        {
            comboBoxType.SelectedItem = Transaction.Type;
            numericUpDownAmount.Value = Transaction.Amount;
            dateTimePickerDate.Value = Transaction.Date;
            textBoxDescription.Text = Transaction.Description ?? string.Empty;
        }


        private bool ValidateInput()
        {
            if (comboBoxType.SelectedItem == null)
            {
                MessageBox.Show("Please select a transaction type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxType.Focus();
                return false;
            }

            if (numericUpDownAmount.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownAmount.Focus();
                return false;
            }

            if (dateTimePickerDate.Value.Date > DateTime.Now.Date)
            {
                var result = MessageBox.Show("The selected date is in the future. Do you want to continue?", "Future Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    dateTimePickerDate.Focus();
                    return false;
                }
            }

            return true;
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {

            if (!ValidateInput())
                return;

            Transaction.Type = comboBoxType.SelectedItem.ToString();
            Transaction.Amount = numericUpDownAmount.Value;
            Transaction.Date = dateTimePickerDate.Value.Date;
            Transaction.Description = string.IsNullOrWhiteSpace(textBoxDescription.Text) ? null : textBoxDescription.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
