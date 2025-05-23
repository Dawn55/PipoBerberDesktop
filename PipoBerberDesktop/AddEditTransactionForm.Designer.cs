namespace PipoBerberDesktop
{
    partial class AddEditTransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonSave = new MaterialSkin.Controls.MaterialButton();
            buttonCancel = new MaterialSkin.Controls.MaterialButton();
            comboBoxType = new ComboBox();
            numericUpDownAmount = new NumericUpDown();
            dateTimePickerDate = new DateTimePicker();
            textBoxDescription = new RichTextBox();
            lblDescription = new Label();
            lblQuantity = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).BeginInit();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonSave.Depth = 0;
            buttonSave.HighEmphasis = true;
            buttonSave.Icon = null;
            buttonSave.Location = new Point(34, 211);
            buttonSave.Margin = new Padding(4, 6, 4, 6);
            buttonSave.MouseState = MaterialSkin.MouseState.HOVER;
            buttonSave.Name = "buttonSave";
            buttonSave.NoAccentTextColor = Color.Empty;
            buttonSave.Size = new Size(76, 36);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Kaydet";
            buttonSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonSave.UseAccentColor = false;
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click_1;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonCancel.Depth = 0;
            buttonCancel.HighEmphasis = true;
            buttonCancel.Icon = null;
            buttonCancel.Location = new Point(141, 211);
            buttonCancel.Margin = new Padding(4, 6, 4, 6);
            buttonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            buttonCancel.Name = "buttonCancel";
            buttonCancel.NoAccentTextColor = Color.Empty;
            buttonCancel.Size = new Size(64, 36);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "İptal";
            buttonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonCancel.UseAccentColor = false;
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // comboBoxType
            // 
            comboBoxType.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Items.AddRange(new object[] { "Gelir", "Gider" });
            comboBoxType.Location = new Point(141, 100);
            comboBoxType.Margin = new Padding(1);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(49, 21);
            comboBoxType.TabIndex = 2;
            // 
            // numericUpDownAmount
            // 
            numericUpDownAmount.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            numericUpDownAmount.Location = new Point(156, 151);
            numericUpDownAmount.Margin = new Padding(1);
            numericUpDownAmount.Name = "numericUpDownAmount";
            numericUpDownAmount.Size = new Size(49, 21);
            numericUpDownAmount.TabIndex = 3;
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dateTimePickerDate.Location = new Point(34, 67);
            dateTimePickerDate.Margin = new Padding(1);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(158, 21);
            dateTimePickerDate.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxDescription.Location = new Point(18, 132);
            textBoxDescription.Margin = new Padding(1);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(111, 41);
            textBoxDescription.TabIndex = 5;
            textBoxDescription.Text = "";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDescription.Location = new Point(18, 108);
            lblDescription.Margin = new Padding(1, 0, 1, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(48, 13);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Açıklama";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblQuantity.Location = new Point(156, 132);
            lblQuantity.Margin = new Padding(1, 0, 1, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(36, 13);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "Değer";
            // 
            // AddEditTransactionForm
            // 
            AutoScaleDimensions = new SizeF(4F, 8F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 300);
            Controls.Add(lblQuantity);
            Controls.Add(lblDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(dateTimePickerDate);
            Controls.Add(numericUpDownAmount);
            Controls.Add(comboBoxType);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Font = new Font("Tahoma", 5.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(1);
            MaximizeBox = false;
            Name = "AddEditTransactionForm";
            Padding = new Padding(1, 35, 1, 1);
            Text = "EkleYadaDüzenle";
            Load += AddEditTransactionForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton buttonSave;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
        private ComboBox comboBoxType;
        private NumericUpDown numericUpDownAmount;
        private DateTimePicker dateTimePickerDate;
        private RichTextBox textBoxDescription;
        private Label lblDescription;
        private Label lblQuantity;
    }
}