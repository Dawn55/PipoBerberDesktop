namespace PipoBerberDesktop
{
    partial class NavForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavForm));
            tabImageList = new ImageList(components);
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            lblUserSearch = new Label();
            tbUserSearch = new TextBox();
            btnDelete = new MaterialSkin.Controls.MaterialButton();
            cbRole = new ComboBox();
            btnUserUpdate = new MaterialSkin.Controls.MaterialButton();
            lblRole = new Label();
            lblPhone = new Label();
            tbPhone = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblUserSurname = new Label();
            tbUserSurname = new TextBox();
            lblUserName = new Label();
            tbUserName = new TextBox();
            dataGridViewUsers = new DataGridView();
            tabPage2 = new TabPage();
            btnSendReply = new MaterialSkin.Controls.MaterialButton();
            lblSendReply = new Label();
            tbSendReply = new TextBox();
            btnDeleteAppointment = new MaterialSkin.Controls.MaterialButton();
            btnUpdateAppointment = new MaterialSkin.Controls.MaterialButton();
            lblStatus = new Label();
            cbStatus = new ComboBox();
            lblReplies = new Label();
            tbAppointmentSearch = new TextBox();
            lblAppointmentSearch = new Label();
            dataGridViewAppointmentReplies = new DataGridView();
            dataGridViewAppointments = new DataGridView();
            tabPage3 = new TabPage();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointmentReplies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).BeginInit();
            SuspendLayout();
            // 
            // tabImageList
            // 
            tabImageList.ColorDepth = ColorDepth.Depth32Bit;
            tabImageList.ImageStream = (ImageListStreamer)resources.GetObject("tabImageList.ImageStream");
            tabImageList.TransparentColor = Color.Transparent;
            tabImageList.Images.SetKeyName(0, "user-244.png");
            tabImageList.Images.SetKeyName(1, "709722.png");
            tabImageList.Images.SetKeyName(2, "appointment-4.png");
            tabImageList.Images.SetKeyName(3, "make-money.png");
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = tabImageList;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(794, 383);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(lblUserSearch);
            tabPage1.Controls.Add(tbUserSearch);
            tabPage1.Controls.Add(btnDelete);
            tabPage1.Controls.Add(cbRole);
            tabPage1.Controls.Add(btnUserUpdate);
            tabPage1.Controls.Add(lblRole);
            tabPage1.Controls.Add(lblPhone);
            tabPage1.Controls.Add(tbPhone);
            tabPage1.Controls.Add(lblEmail);
            tabPage1.Controls.Add(tbEmail);
            tabPage1.Controls.Add(lblUserSurname);
            tabPage1.Controls.Add(tbUserSurname);
            tabPage1.Controls.Add(lblUserName);
            tabPage1.Controls.Add(tbUserName);
            tabPage1.Controls.Add(dataGridViewUsers);
            tabPage1.ImageKey = "709722.png";
            tabPage1.Location = new Point(4, 31);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(786, 348);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Kullanıcılar";
            // 
            // lblUserSearch
            // 
            lblUserSearch.AutoSize = true;
            lblUserSearch.Location = new Point(145, 9);
            lblUserSearch.Name = "lblUserSearch";
            lblUserSearch.Size = new Size(123, 15);
            lblUserSearch.TabIndex = 17;
            lblUserSearch.Text = "İsme Göre Arama Yap:";
            // 
            // tbUserSearch
            // 
            tbUserSearch.Location = new Point(242, 5);
            tbUserSearch.Name = "tbUserSearch";
            tbUserSearch.Size = new Size(294, 23);
            tbUserSearch.TabIndex = 16;
            tbUserSearch.TextChanged += tbUserSearch_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDelete.Depth = 0;
            btnDelete.HighEmphasis = true;
            btnDelete.Icon = null;
            btnDelete.Location = new Point(472, 300);
            btnDelete.Margin = new Padding(4, 6, 4, 6);
            btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            btnDelete.Name = "btnDelete";
            btnDelete.NoAccentTextColor = Color.Empty;
            btnDelete.Size = new Size(64, 36);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Sil";
            btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDelete.UseAccentColor = false;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "Kullanıcı", "Yönetici" });
            cbRole.Location = new Point(340, 284);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(103, 23);
            cbRole.TabIndex = 14;
            // 
            // btnUserUpdate
            // 
            btnUserUpdate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUserUpdate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUserUpdate.Depth = 0;
            btnUserUpdate.HighEmphasis = true;
            btnUserUpdate.Icon = null;
            btnUserUpdate.Location = new Point(472, 254);
            btnUserUpdate.Margin = new Padding(4, 6, 4, 6);
            btnUserUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            btnUserUpdate.Name = "btnUserUpdate";
            btnUserUpdate.NoAccentTextColor = Color.Empty;
            btnUserUpdate.Size = new Size(94, 36);
            btnUserUpdate.TabIndex = 13;
            btnUserUpdate.Text = "Güncelle";
            btnUserUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUserUpdate.UseAccentColor = false;
            btnUserUpdate.UseVisualStyleBackColor = true;
            btnUserUpdate.Click += btnUserUpdate_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(340, 262);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(89, 19);
            lblRole.TabIndex = 12;
            lblRole.Text = "Kullanıcı Rolu";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.Location = new Point(202, 291);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(114, 19);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Telefon Numarası";
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(206, 313);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(100, 23);
            tbPhone.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(62, 291);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(94, 19);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Kullanıcı Email";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(56, 313);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(100, 23);
            tbEmail.TabIndex = 7;
            // 
            // lblUserSurname
            // 
            lblUserSurname.AutoSize = true;
            lblUserSurname.Font = new Font("Segoe UI", 10F);
            lblUserSurname.Location = new Point(202, 239);
            lblUserSurname.Name = "lblUserSurname";
            lblUserSurname.Size = new Size(102, 19);
            lblUserSurname.TabIndex = 4;
            lblUserSurname.Text = "Kullanıcı Soyadı";
            // 
            // tbUserSurname
            // 
            tbUserSurname.BackColor = SystemColors.Highlight;
            tbUserSurname.Location = new Point(204, 262);
            tbUserSurname.Name = "tbUserSurname";
            tbUserSurname.Size = new Size(100, 23);
            tbUserSurname.TabIndex = 3;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 10F);
            lblUserName.Location = new Point(65, 239);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(82, 19);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "Kullanıcı Adı";
            // 
            // tbUserName
            // 
            tbUserName.Location = new Point(56, 262);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(100, 23);
            tbUserName.TabIndex = 1;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(86, 34);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.Size = new Size(573, 202);
            dataGridViewUsers.TabIndex = 0;
            dataGridViewUsers.SelectionChanged += dataGridViewUsers_SelectionChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnSendReply);
            tabPage2.Controls.Add(lblSendReply);
            tabPage2.Controls.Add(tbSendReply);
            tabPage2.Controls.Add(btnDeleteAppointment);
            tabPage2.Controls.Add(btnUpdateAppointment);
            tabPage2.Controls.Add(lblStatus);
            tabPage2.Controls.Add(cbStatus);
            tabPage2.Controls.Add(lblReplies);
            tabPage2.Controls.Add(tbAppointmentSearch);
            tabPage2.Controls.Add(lblAppointmentSearch);
            tabPage2.Controls.Add(dataGridViewAppointmentReplies);
            tabPage2.Controls.Add(dataGridViewAppointments);
            tabPage2.ImageKey = "appointment-4.png";
            tabPage2.Location = new Point(4, 31);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(786, 348);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Randevular";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // btnSendReply
            // 
            btnSendReply.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSendReply.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSendReply.Depth = 0;
            btnSendReply.HighEmphasis = true;
            btnSendReply.Icon = null;
            btnSendReply.Location = new Point(559, 302);
            btnSendReply.Margin = new Padding(4, 6, 4, 6);
            btnSendReply.MouseState = MaterialSkin.MouseState.HOVER;
            btnSendReply.Name = "btnSendReply";
            btnSendReply.NoAccentTextColor = Color.Empty;
            btnSendReply.Size = new Size(79, 36);
            btnSendReply.TabIndex = 11;
            btnSendReply.Text = "Gönder";
            btnSendReply.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSendReply.UseAccentColor = false;
            btnSendReply.UseVisualStyleBackColor = true;
            btnSendReply.Click += btnSendReply_Click;
            // 
            // lblSendReply
            // 
            lblSendReply.AutoSize = true;
            lblSendReply.Location = new Point(514, 252);
            lblSendReply.Name = "lblSendReply";
            lblSendReply.Size = new Size(175, 15);
            lblSendReply.TabIndex = 10;
            lblSendReply.Text = "Seçilen Randevuya yantı gönder";
            // 
            // tbSendReply
            // 
            tbSendReply.Location = new Point(543, 270);
            tbSendReply.Name = "tbSendReply";
            tbSendReply.Size = new Size(118, 23);
            tbSendReply.TabIndex = 9;
            // 
            // btnDeleteAppointment
            // 
            btnDeleteAppointment.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteAppointment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeleteAppointment.Depth = 0;
            btnDeleteAppointment.HighEmphasis = true;
            btnDeleteAppointment.Icon = null;
            btnDeleteAppointment.Location = new Point(407, 260);
            btnDeleteAppointment.Margin = new Padding(4, 6, 4, 6);
            btnDeleteAppointment.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteAppointment.Name = "btnDeleteAppointment";
            btnDeleteAppointment.NoAccentTextColor = Color.Empty;
            btnDeleteAppointment.Size = new Size(64, 36);
            btnDeleteAppointment.TabIndex = 8;
            btnDeleteAppointment.Text = "Sil";
            btnDeleteAppointment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeleteAppointment.UseAccentColor = false;
            btnDeleteAppointment.UseVisualStyleBackColor = true;
            btnDeleteAppointment.Click += btnDeleteAppointment_Click;
            // 
            // btnUpdateAppointment
            // 
            btnUpdateAppointment.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUpdateAppointment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUpdateAppointment.Depth = 0;
            btnUpdateAppointment.HighEmphasis = true;
            btnUpdateAppointment.Icon = null;
            btnUpdateAppointment.Location = new Point(267, 260);
            btnUpdateAppointment.Margin = new Padding(4, 6, 4, 6);
            btnUpdateAppointment.MouseState = MaterialSkin.MouseState.HOVER;
            btnUpdateAppointment.Name = "btnUpdateAppointment";
            btnUpdateAppointment.NoAccentTextColor = Color.Empty;
            btnUpdateAppointment.Size = new Size(94, 36);
            btnUpdateAppointment.TabIndex = 7;
            btnUpdateAppointment.Text = "Güncelle";
            btnUpdateAppointment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUpdateAppointment.UseAccentColor = false;
            btnUpdateAppointment.UseVisualStyleBackColor = true;
            btnUpdateAppointment.Click += btnUpdateAppointment_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(84, 255);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(99, 15);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Randevu durumu";
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Beklemede", "Onaylandı", "İptal Edildi" });
            cbStatus.Location = new Point(75, 273);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(121, 23);
            cbStatus.TabIndex = 5;
            cbStatus.SelectedIndexChanged += cbStatus_SelectedIndexChanged;
            // 
            // lblReplies
            // 
            lblReplies.AutoSize = true;
            lblReplies.Location = new Point(505, 9);
            lblReplies.Name = "lblReplies";
            lblReplies.Size = new Size(156, 15);
            lblReplies.TabIndex = 4;
            lblReplies.Text = "Seçilen randevunun yanıtları";
            // 
            // tbAppointmentSearch
            // 
            tbAppointmentSearch.Location = new Point(202, 9);
            tbAppointmentSearch.Name = "tbAppointmentSearch";
            tbAppointmentSearch.Size = new Size(171, 23);
            tbAppointmentSearch.TabIndex = 3;
            // 
            // lblAppointmentSearch
            // 
            lblAppointmentSearch.AutoSize = true;
            lblAppointmentSearch.Location = new Point(75, 12);
            lblAppointmentSearch.Name = "lblAppointmentSearch";
            lblAppointmentSearch.Size = new Size(140, 15);
            lblAppointmentSearch.TabIndex = 2;
            lblAppointmentSearch.Text = "Randevu ismine göre ara:";
            // 
            // dataGridViewAppointmentReplies
            // 
            dataGridViewAppointmentReplies.AllowUserToAddRows = false;
            dataGridViewAppointmentReplies.AllowUserToDeleteRows = false;
            dataGridViewAppointmentReplies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointmentReplies.Location = new Point(456, 30);
            dataGridViewAppointmentReplies.Name = "dataGridViewAppointmentReplies";
            dataGridViewAppointmentReplies.ReadOnly = true;
            dataGridViewAppointmentReplies.Size = new Size(263, 211);
            dataGridViewAppointmentReplies.TabIndex = 1;
            // 
            // dataGridViewAppointments
            // 
            dataGridViewAppointments.AllowUserToAddRows = false;
            dataGridViewAppointments.AllowUserToDeleteRows = false;
            dataGridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointments.Location = new Point(50, 30);
            dataGridViewAppointments.Name = "dataGridViewAppointments";
            dataGridViewAppointments.ReadOnly = true;
            dataGridViewAppointments.Size = new Size(384, 211);
            dataGridViewAppointments.TabIndex = 0;
            dataGridViewAppointments.SelectionChanged += dataGridViewAppointments_SelectionChanged;
            // 
            // tabPage3
            // 
            tabPage3.ImageKey = "make-money.png";
            tabPage3.Location = new Point(4, 31);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(786, 348);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Gelir Gider Tablosu";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // NavForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "NavForm";
            Load += NavForm_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointmentReplies).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ImageList tabImageList;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridViewUsers;
        private Label lblUserSurname;
        private TextBox tbUserSurname;
        private Label lblUserName;
        private TextBox tbUserName;
        private MaterialSkin.Controls.MaterialButton btnUserUpdate;
        private Label lblRole;
        private Label lblPhone;
        private TextBox tbPhone;
        private Label lblEmail;
        private TextBox tbEmail;
        private ComboBox cbRole;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private Label lblUserSearch;
        private TextBox tbUserSearch;
        private DataGridView dataGridViewAppointmentReplies;
        private DataGridView dataGridViewAppointments;
        private Label lblReplies;
        private TextBox tbAppointmentSearch;
        private Label lblAppointmentSearch;
        private MaterialSkin.Controls.MaterialButton btnDeleteAppointment;
        private MaterialSkin.Controls.MaterialButton btnUpdateAppointment;
        private Label lblStatus;
        private ComboBox cbStatus;
        private TextBox tbSendReply;
        private MaterialSkin.Controls.MaterialButton btnSendReply;
        private Label lblSendReply;
    }
}