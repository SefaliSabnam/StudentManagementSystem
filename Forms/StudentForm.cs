using System.Data;
using StudentManagementSystem.Database;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;



namespace StudentManagementSystem.Forms
{
    public partial class StudentForm : Form
    {
        private FilterInfoCollection cameras;
        private VideoCaptureDevice camera;
        private int selectedStudentId = 0;
        private Bitmap currentFrame;
        private Bitmap capturedImage;
     
        private string selectedImagePath = "";

        public StudentForm()
        {
            InitializeComponent();
            this.BackColor = Color.Gainsboro;
        }





        // SAVE STUDENT BUTTON
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text.Trim() == "" ||
                txtAge.Text.Trim() == "" ||
                txtPhone.Text.Trim() == "" ||
                cmbCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            string gender = "";

            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked)
            {
                gender = "Female";
            }
            else
            {
                gender = "Not Selected";
            }

            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    con.Open();

                    string query = @"INSERT INTO Students
                            (StudentName,
                             Age,
                             Gender,
                             Course,
                             Phone,
                             Email,
                             Address,
                             Photo)
                            VALUES
                            (@StudentName,
                             @Age,
                             @Gender,
                             @Course,
                             @Phone,
                             @Email,
                             @Address,
                             @Photo)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@StudentName", txtStudentName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Course", cmbCourse.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    // Save the selected browse image path
                    cmd.Parameters.AddWithValue("@Photo", selectedImagePath);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Student Saved Successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadStudents();
                    ClearFields();
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



        // CLEAR BUTTON
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            selectedStudentId = 0;
        }
        private void LoadStudents()
        {
            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    con.Open();

                    string query = "SELECT * FROM Students";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvStudents.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void ClearFields()
        {
            txtStudentName.Clear();
            txtAge.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            rbMale.Checked = false;
            rbFemale.Checked = false;

            cmbCourse.SelectedIndex = 0;

            // Clear Browse Image
            if (picStudent.Image != null)
            {
                picStudent.Image.Dispose();
                picStudent.Image = null;
            }

            // Clear Captured Camera Image
            if (picCamera.Image != null)
            {
                picCamera.Image.Dispose();
                picCamera.Image = null;
            }

            // Clear Variables
            capturedImage = null;
            currentFrame = null;

            // Clear saved image path
            selectedImagePath = string.Empty;
        }



        // CAMERA BUTTONS (Coming Next)
        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            MessageBox.Show("Cameras Found: " + cameras.Count);

            if (cameras.Count == 0)
            {
                MessageBox.Show("No Camera Found");
                return;
            }

            MessageBox.Show("Using Camera: " + cameras[0].Name);

            int index = -1;

            for (int i = 0; i < cameras.Count; i++)
            {
                MessageBox.Show(i + " : " + cameras[i].Name);

                if (!cameras[i].Name.Contains("OBS"))
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                MessageBox.Show("No physical webcam found.");
                return;
            }

            camera = new VideoCaptureDevice(cameras[index].MonikerString);
            camera.NewFrame += Video_NewFrame;
            camera.Start();
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            currentFrame = (Bitmap)frame.Clone();

            picCamera.Invoke(new Action(() =>
            {
                if (picCamera.Image != null)
                    picCamera.Image.Dispose();

                picCamera.Image = (Bitmap)frame.Clone();
            }));
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (currentFrame == null)
            {
                MessageBox.Show("No camera image available.");
                return;
            }

            capturedImage = (Bitmap)currentFrame.Clone();

            if (camera != null && camera.IsRunning)
            {
                camera.SignalToStop();
                camera.WaitForStop();
            }

            picCamera.Image = (Bitmap)capturedImage.Clone();

            MessageBox.Show("Photo Captured Successfully");
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            if (camera != null && camera.IsRunning)
            {
                camera.SignalToStop();
                camera.WaitForStop();
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (camera != null && camera.IsRunning)
            {
                camera.SignalToStop();
                camera.WaitForStop();
            }

            base.OnFormClosing(e);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            string gender = "";

            if (rbMale.Checked)
                gender = "Male";
            else if (rbFemale.Checked)
                gender = "Female";
            else
                gender = "Not Selected";

            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    con.Open();

                    string query = @"UPDATE Students
                             SET StudentName=@StudentName,
                                 Age=@Age,
                                 Gender=@Gender,
                                 Course=@Course,
                                 Phone=@Phone,
                                 Email=@Email,
                                 Address=@Address,
                                 Photo=@Photo
                             WHERE StudentId=@StudentId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@StudentName", txtStudentName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Course", cmbCourse.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    // Save Browse Image Path
                    cmd.Parameters.AddWithValue("@Photo", selectedImagePath);

                    cmd.Parameters.AddWithValue("@StudentId", selectedStudentId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Student Updated Successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadStudents();
                    ClearFields();
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
           
        


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    con.Open();

                    string query = "DELETE FROM Students WHERE StudentId=@StudentId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentId", selectedStudentId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Student Deleted Successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadStudents();
                    ClearFields();
                    selectedStudentId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourse.SelectedIndex != -1)
            {
                MessageBox.Show("Selected Course: " + cmbCourse.Text);
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                selectedStudentId = Convert.ToInt32(row.Cells["StudentId"].Value);

                txtStudentName.Text = row.Cells["StudentName"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();

                if (row.Cells["Gender"].Value.ToString() == "Male")
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;

                cmbCourse.Text = row.Cells["Course"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();

                // Load Browse Image
                if (row.Cells["Photo"].Value != DBNull.Value)
                {
                    selectedImagePath = row.Cells["Photo"].Value.ToString();

                    if (File.Exists(selectedImagePath))
                    {
                        if (picStudent.Image != null)
                            picStudent.Image.Dispose();

                        picStudent.Image = System.Drawing.Image.FromFile(selectedImagePath);
                    }
                    else
                    {
                        picStudent.Image = null;
                    }
                }
                else
                {
                    selectedImagePath = "";
                    picStudent.Image = null;
                }
            }
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;

                if (picStudent.Image != null)
                    picStudent.Image.Dispose();

                picStudent.Image = System.Drawing.Image.FromFile(selectedImagePath);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files|*.pdf";
            sfd.FileName = txtStudentName.Text + ".pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document document = new Document(PageSize.A4);

                PdfWriter.GetInstance(document,
                    new FileStream(sfd.FileName, FileMode.Create));

                document.Open();

                iTextSharp.text.Font titleFont =
    iTextSharp.text.FontFactory.GetFont(
        iTextSharp.text.FontFactory.HELVETICA_BOLD, 18);

                iTextSharp.text.Font normalFont =
                    iTextSharp.text.FontFactory.GetFont(
                        iTextSharp.text.FontFactory.HELVETICA, 12);

                document.Add(new Paragraph("Student Registration Form", titleFont));
                document.Add(new Paragraph(" "));

                //======================
                // Photo Table
                //======================

                PdfPTable photoTable = new PdfPTable(2);
                photoTable.WidthPercentage = 100;
            
                PdfPCell leftTitle = new PdfPCell(new Phrase("Browse Photo"));
                leftTitle.HorizontalAlignment = Element.ALIGN_CENTER;
                leftTitle.Border = iTextSharp.text.Rectangle.NO_BORDER;
                photoTable.AddCell(leftTitle);

                PdfPCell rightTitle = new PdfPCell(new Phrase("Captured Photo"));
                rightTitle.HorizontalAlignment = Element.ALIGN_CENTER;
                rightTitle.Border = iTextSharp.text.Rectangle.NO_BORDER;
                photoTable.AddCell(rightTitle);

                // Browse Photo

                if (picStudent.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picStudent.Image.Save(ms,
                            System.Drawing.Imaging.ImageFormat.Jpeg);

                        iTextSharp.text.Image img =
                            iTextSharp.text.Image.GetInstance(ms.ToArray());

                        img.ScaleAbsolute(150f, 170f);

                        PdfPCell cell = new PdfPCell(img);
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;

                        photoTable.AddCell(cell);
                    }
                }
                else
                {
                    photoTable.AddCell("");
                }

                // Captured Photo

                if (capturedImage != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        capturedImage.Save(ms,
                            System.Drawing.Imaging.ImageFormat.Jpeg);

                        iTextSharp.text.Image img =
                            iTextSharp.text.Image.GetInstance(ms.ToArray());

                        img.ScaleAbsolute(150f, 170f);

                        PdfPCell cell = new PdfPCell(img);
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;

                        photoTable.AddCell(cell);
                    }
                }
                else
                {
                    photoTable.AddCell("");
                }

                document.Add(photoTable);

                document.Add(new Paragraph(" "));

                string gender = rbMale.Checked ? "Male" :
                                rbFemale.Checked ? "Female" : "Not Selected";

                document.Add(new Paragraph("Student Name : " + txtStudentName.Text, normalFont));
                document.Add(new Paragraph("Age : " + txtAge.Text, normalFont));
                document.Add(new Paragraph("Gender : " + gender, normalFont));
                document.Add(new Paragraph("Course : " + cmbCourse.Text, normalFont));
                document.Add(new Paragraph("Phone : " + txtPhone.Text, normalFont));
                document.Add(new Paragraph("Email : " + txtEmail.Text, normalFont));
                document.Add(new Paragraph("Address : " + txtAddress.Text, normalFont));

                document.Close();

                MessageBox.Show("PDF Exported Successfully!");
            }
        }




        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
        

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string gender = rbMale.Checked ? "Male" :
                     rbFemale.Checked ? "Female" : "Not Selected";

            PreviewForm previewForm = new PreviewForm(
                txtStudentName.Text,
                txtAge.Text,
                gender,
                cmbCourse.Text,
                txtPhone.Text,
                txtEmail.Text,
                txtAddress.Text,
                picStudent.Image,
                capturedImage
            );

            previewForm.ShowDialog();
        }

        
    }
    }
    
    
