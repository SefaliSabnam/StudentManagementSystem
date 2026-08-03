using StudentManagementSystem.Database;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();

            // Hide password characters
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Check empty fields
            if (txtFullName.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "" ||
                txtPassword.Text.Trim() == "" ||
                txtConfirmPassword.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please fill all fields.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Password match
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtPassword.Focus();

                return;
            }

            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    con.Open();

                    // Check username
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@Username";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);

                    checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show(
                            "Username already exists.",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtUsername.Focus();
                        return;
                    }

                    // Insert user
                    string insertQuery = @"INSERT INTO Users
                                          (FullName, Username, Password)
                                          VALUES
                                          (@FullName, @Username, @Password)";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Registration Successful!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoginForm login = new LoginForm();
                    login.Show();

                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();

            login.Show();

            this.Hide();
        }
    }
}