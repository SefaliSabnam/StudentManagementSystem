using System;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Welcome message
            lblWelcome.Text = "Welcome to Student Management System";
        }

        // Open Student Form
        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.ShowDialog();
        }

        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();

                this.Close();
            }
        }

        // Exit application when Dashboard is closed
        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["LoginForm"] == null)
            {
                Application.Exit();
            }
        }
    }
}