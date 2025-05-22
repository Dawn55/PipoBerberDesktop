namespace PipoBerberDesktop
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbEmail = new TextBox();
            tbPassword = new TextBox();
            showPassword = new CheckBox();
            lblLogin = new Label();
            label2 = new Label();
            btnLogin = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(298, 201);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(150, 22);
            tbEmail.TabIndex = 0;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(298, 252);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(150, 22);
            tbPassword.TabIndex = 1;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // showPassword
            // 
            showPassword.AutoSize = true;
            showPassword.Location = new Point(436, 293);
            showPassword.Name = "showPassword";
            showPassword.Size = new Size(106, 18);
            showPassword.TabIndex = 2;
            showPassword.Text = "Parolayı Göster";
            showPassword.UseVisualStyleBackColor = true;
            showPassword.CheckedChanged += showPassword_CheckedChanged;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin.Location = new Point(298, 135);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(160, 39);
            lblLogin.TabIndex = 3;
            lblLogin.Text = "Giriş Yap";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(289, 172);
            label2.Name = "label2";
            label2.Size = new Size(178, 14);
            label2.TabIndex = 4;
            label2.Text = "(sadece admin kullanıcılara özel)";
            // 
            // btnLogin
            // 
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogin.Depth = 0;
            btnLogin.HighEmphasis = true;
            btnLogin.Icon = null;
            btnLogin.Location = new Point(320, 304);
            btnLogin.Margin = new Padding(4, 6, 4, 6);
            btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.NoAccentTextColor = Color.Empty;
            btnLogin.Size = new Size(89, 36);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Giriş Yap";
            btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogin.UseAccentColor = false;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(lblLogin);
            Controls.Add(showPassword);
            Controls.Add(tbPassword);
            Controls.Add(tbEmail);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Name = "LoginForm";
            Padding = new Padding(3, 60, 3, 3);
            Text = "Hoşgeldiniz";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbEmail;
        private TextBox tbPassword;
        private CheckBox showPassword;
        private Label lblLogin;
        private Label label2;
        private MaterialSkin.Controls.MaterialButton btnLogin;
    }
}
