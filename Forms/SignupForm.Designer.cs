namespace StudentManagementSystem.Forms
{
    partial class SignupForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();

            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();

            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();

            this.btnSignup = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            this.panelHeader = new System.Windows.Forms.Panel();

            this.panelHeader.SuspendLayout();

            this.SuspendLayout();


            // ==========================
            // panelHeader
            // ==========================

            this.panelHeader.BackColor =
                System.Drawing.Color.RoyalBlue;

            this.panelHeader.Dock =
                System.Windows.Forms.DockStyle.Top;

            this.panelHeader.Height = 70;

            this.panelHeader.Name =
                "panelHeader";


            // ==========================
            // lblTitle
            // ==========================

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;


            this.lblTitle.Location =
                new System.Drawing.Point(260, 20);


            this.lblTitle.Name =
                "lblTitle";


            this.lblTitle.Text =
                "CREATE ACCOUNT";


            this.panelHeader.Controls.Add(
                this.lblTitle);



            // ==========================
            // lblName
            // ==========================


            this.lblName.AutoSize = true;

            this.lblName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);


            this.lblName.ForeColor =
                System.Drawing.Color.RoyalBlue;


            this.lblName.Location =
                new System.Drawing.Point(220, 110);


            this.lblName.Text =
                "Full Name";


            // ==========================
            // txtFullName
            // ==========================


            this.txtFullName.Location =
                new System.Drawing.Point(220, 140);


            this.txtFullName.Size =
                new System.Drawing.Size(350, 35);


            this.txtFullName.Name =
                "txtFullName";


            this.txtFullName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            this.txtFullName.TabIndex = 1;

            // ==========================
            // lblUsername
            // ==========================

            this.lblUsername.AutoSize = true;

            this.lblUsername.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblUsername.ForeColor =
                System.Drawing.Color.RoyalBlue;

            this.lblUsername.Location =
                new System.Drawing.Point(220, 190);

            this.lblUsername.Name =
                "lblUsername";

            this.lblUsername.Text =
                "Username";


            // ==========================
            // txtUsername
            // ==========================

            this.txtUsername.Location =
                new System.Drawing.Point(220, 220);

            this.txtUsername.Size =
                new System.Drawing.Size(350, 35);

            this.txtUsername.Name =
                "txtUsername";

            this.txtUsername.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.txtUsername.TabIndex = 2;



            // ==========================
            // lblPassword
            // ==========================

            this.lblPassword.AutoSize = true;

            this.lblPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblPassword.ForeColor =
                System.Drawing.Color.RoyalBlue;

            this.lblPassword.Location =
                new System.Drawing.Point(220, 270);

            this.lblPassword.Name =
                "lblPassword";

            this.lblPassword.Text =
                "Password";



            // ==========================
            // txtPassword
            // ==========================

            this.txtPassword.Location =
                new System.Drawing.Point(220, 300);

            this.txtPassword.Size =
                new System.Drawing.Size(350, 35);

            this.txtPassword.Name =
                "txtPassword";

            this.txtPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.txtPassword.UseSystemPasswordChar =
                true;

            this.txtPassword.TabIndex = 3;



            // ==========================
            // lblConfirm
            // ==========================

            this.lblConfirm.AutoSize = true;

            this.lblConfirm.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblConfirm.ForeColor =
                System.Drawing.Color.RoyalBlue;

            this.lblConfirm.Location =
                new System.Drawing.Point(220, 350);

            this.lblConfirm.Name =
                "lblConfirm";

            this.lblConfirm.Text =
                "Confirm Password";



            // ==========================
            // txtConfirmPassword
            // ==========================

            this.txtConfirmPassword.Location =
                new System.Drawing.Point(220, 380);

            this.txtConfirmPassword.Size =
                new System.Drawing.Size(350, 35);

            this.txtConfirmPassword.Name =
                "txtConfirmPassword";

            this.txtConfirmPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.txtConfirmPassword.UseSystemPasswordChar =
                true;

            this.txtConfirmPassword.TabIndex = 4;



            // ==========================
            // btnSignup
            // ==========================

            this.btnSignup.BackColor =
                System.Drawing.Color.RoyalBlue;

            this.btnSignup.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSignup.FlatAppearance.BorderSize = 0;

            this.btnSignup.ForeColor =
                System.Drawing.Color.White;

            this.btnSignup.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnSignup.Location =
                new System.Drawing.Point(220, 450);

            this.btnSignup.Size =
                new System.Drawing.Size(150, 40);

            this.btnSignup.Name =
                "btnSignup";

            this.btnSignup.Text =
                "SIGN UP";

            this.btnSignup.UseVisualStyleBackColor =
                false;

            this.btnSignup.Click +=
                new System.EventHandler(
                    this.btnSignup_Click);

            // ==========================
            // btnBack
            // ==========================

            this.btnBack.BackColor =
                System.Drawing.Color.Gray;

            this.btnBack.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBack.FlatAppearance.BorderSize = 0;

            this.btnBack.ForeColor =
                System.Drawing.Color.White;


            this.btnBack.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);


            this.btnBack.Location =
                new System.Drawing.Point(420, 450);


            this.btnBack.Size =
                new System.Drawing.Size(150, 40);


            this.btnBack.Name =
                "btnBack";


            this.btnBack.Text =
                "BACK TO LOGIN";


            this.btnBack.UseVisualStyleBackColor =
                false;


            this.btnBack.Click +=
                new System.EventHandler(
                    this.btnBack_Click);



            // ==========================
            // Add Controls To Form
            // ==========================


            this.Controls.Add(
                this.panelHeader);


            this.Controls.Add(
                this.lblName);


            this.Controls.Add(
                this.txtFullName);


            this.Controls.Add(
                this.lblUsername);


            this.Controls.Add(
                this.txtUsername);


            this.Controls.Add(
                this.lblPassword);


            this.Controls.Add(
                this.txtPassword);


            this.Controls.Add(
                this.lblConfirm);


            this.Controls.Add(
                this.txtConfirmPassword);


            this.Controls.Add(
                this.btnSignup);


            this.Controls.Add(
                this.btnBack);



            // ==========================
            // SignupForm
            // ==========================


            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    8F,
                    16F);


            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;


            this.BackColor =
                System.Drawing.Color.Gainsboro;


            this.ClientSize =
                new System.Drawing.Size(
                    800,
                    550);


            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;


            this.Name =
                "SignupForm";


            this.Text =
                "Create Account";


            this.Load +=
                new System.EventHandler(
                    this.SignupForm_Load);



            // ==========================
            // Finish Layout
            // ==========================


            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();


            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion



        // ==========================
        // Controls Declaration
        // ==========================


        private System.Windows.Forms.Panel panelHeader;


        private System.Windows.Forms.Label lblTitle;


        private System.Windows.Forms.Label lblName;

        private System.Windows.Forms.Label lblUsername;

        private System.Windows.Forms.Label lblPassword;

        private System.Windows.Forms.Label lblConfirm;


        private System.Windows.Forms.TextBox txtFullName;

        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.TextBox txtConfirmPassword;


        private System.Windows.Forms.Button btnSignup;

        private System.Windows.Forms.Button btnBack;

    }
}