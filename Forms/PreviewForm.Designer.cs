namespace StudentManagementSystem.Forms
{
    partial class PreviewForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.PictureBox picBrowse;
        private System.Windows.Forms.PictureBox picCaptured;

        private System.Windows.Forms.Label lblBrowse;
        private System.Windows.Forms.Label lblCaptured;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;

        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();

            this.picBrowse = new System.Windows.Forms.PictureBox();
            this.picCaptured = new System.Windows.Forms.PictureBox();

            this.lblBrowse = new System.Windows.Forms.Label();
            this.lblCaptured = new System.Windows.Forms.Label();

            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();

            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptured)).BeginInit();

            this.SuspendLayout();
            this.panelHeader.Name = "panelHeader";
            this.lblHeader.Name = "lblHeader";
            this.lblTitle.Name = "lblTitle";

            this.lblBrowse.Name = "lblBrowse";
            this.lblCaptured.Name = "lblCaptured";

            this.lblName.Name = "lblName";
            this.lblAge.Name = "lblAge";
            this.lblGender.Name = "lblGender";
            this.lblCourse.Name = "lblCourse";
            this.lblPhone.Name = "lblPhone";

            //
            // PreviewForm
            //

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1050, 700);
            this.Name = "PreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Preview";

            //
            // panelHeader
            //

            this.panelHeader.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1050, 65);

            //
            // lblHeader
            //

            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F,
            System.Drawing.FontStyle.Bold);

            this.lblHeader.ForeColor = System.Drawing.Color.White;

            this.lblHeader.Location = new System.Drawing.Point(18, 14);

            this.lblHeader.Text = "STUDENT MANAGEMENT SYSTEM";

            // Header Label

            this.panelHeader.Controls.Add(this.lblHeader);

            //
            // lblTitle
            //

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F,
            System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(360, 85);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Student Preview";

            //
            // Browse Label
            //

            this.lblBrowse.AutoSize = true;
            this.lblBrowse.Font = new System.Drawing.Font("Segoe UI", 10F,
            System.Drawing.FontStyle.Bold);

            this.lblBrowse.Location = new System.Drawing.Point(560, 135);
            this.lblBrowse.Text = "Browse Photo";

            //
            // Capture Label
            //

            this.lblCaptured.AutoSize = true;
            this.lblCaptured.Font = new System.Drawing.Font("Segoe UI", 10F,
            System.Drawing.FontStyle.Bold);

            this.lblCaptured.Location = new System.Drawing.Point(800, 135);
            this.lblCaptured.Text = "Captured Photo";

            //
            // picBrowse
            //

            this.picBrowse.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;

            this.picBrowse.Location =
            new System.Drawing.Point(540, 165);

            this.picBrowse.Name = "picBrowse";

            this.picBrowse.Size =
            new System.Drawing.Size(180, 180);

            this.picBrowse.SizeMode =
            System.Windows.Forms.PictureBoxSizeMode.Zoom;

            //
            // picCaptured
            //

            this.picCaptured.BorderStyle =
            System.Windows.Forms.BorderStyle.FixedSingle;

            this.picCaptured.Location =
            new System.Drawing.Point(770, 165);

            this.picCaptured.Name = "picCaptured";

            this.picCaptured.Size =
            new System.Drawing.Size(180, 180);

            this.picCaptured.SizeMode =
            System.Windows.Forms.PictureBoxSizeMode.Zoom;

            //
            // lblName
            //

            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblName.Location = new System.Drawing.Point(60, 150);
            this.lblName.Text = "Student Name :";

            //
            // lblAge
            //

            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAge.Location = new System.Drawing.Point(60, 190);
            this.lblAge.Text = "Age :";

            //
            // lblGender
            //

            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGender.Location = new System.Drawing.Point(60, 230);
            this.lblGender.Text = "Gender :";

            //
            // lblCourse
            //

            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCourse.Location = new System.Drawing.Point(60, 270);
            this.lblCourse.Text = "Course :";

            //
            // lblPhone
            //

            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPhone.Location = new System.Drawing.Point(60, 310);
            this.lblPhone.Text = "Phone :";

            //
            // lblEmail
            //

            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEmail.Location = new System.Drawing.Point(60, 350);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email :";

            //
            // lblAddress
            //

            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAddress.Location = new System.Drawing.Point(60, 390);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address :";

            //
            // btnExportPDF
            //

            this.btnExportPDF.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.FlatAppearance.BorderSize = 0;
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 10F,
            System.Drawing.FontStyle.Bold);
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Location = new System.Drawing.Point(290, 610);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(170, 45);
            this.btnExportPDF.Text = "Export PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);

            //
            // btnClose
            //

            this.btnClose.BackColor = System.Drawing.Color.Firebrick;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F,
            System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(520, 610);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(170, 45);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            //
            // Add Controls
            //

            this.Controls.Add(this.panelHeader);

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.lblBrowse);
            this.Controls.Add(this.lblCaptured);

            this.Controls.Add(this.picBrowse);
            this.Controls.Add(this.picCaptured);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAddress);

            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnClose);

            ((System.ComponentModel.ISupportInitialize)(this.picBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptured)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}