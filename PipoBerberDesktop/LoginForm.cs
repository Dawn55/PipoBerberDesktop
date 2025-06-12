using Dapper;
using PipoBerberDesktop.Helpers;

namespace PipoBerberDesktop
{
    public partial class LoginForm : MaterialSkin.Controls.MaterialForm
    {
        public LoginForm()
        {
            InitializeComponent();
            MaterialSkinManager.ApplyMaterialSkin(this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            lblLogin.Font = new Font("Tahoma", 24, FontStyle.Bold);
           tbEmail.BackColor = Color.FromArgb(255, 255, 255);
           tbPassword.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {

                var user = connection.QueryFirstOrDefault(@"SELECT * FROM ""User"" WHERE email = @Email AND ""isAdmin"" = true",
                    new { Email = tbEmail.Text });

                if (user != null)
                {

                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(tbPassword.Text, user.password);

                    if (isPasswordValid)
                    {
                        Session.UserId = user.id;
                        Session.UserName = user.name;
                        Session.UserSurname = user.surname;
                        Session.UserPhone = user.phone;
                        Session.UserEmail = user.email;
                        Session.IsAdmin = user.isAdmin;
                        Session.IsGuest = user.isGuest;

                        Console.WriteLine(Session.IsGuest);

                        new NavForm().Show();
                        this.Hide();
                        return;
                    }
                }

                MessageBox.Show("Yetkili kullanýcý bulunamadý");
            }
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !showPassword.Checked;
        }
    }
}
