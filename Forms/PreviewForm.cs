using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace StudentManagementSystem.Forms
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        public PreviewForm(
            string name,
            string age,
            string gender,
            string course,
            string phone,
            string email,
            string address,
            System.Drawing.Image browseImage,
            System.Drawing.Image capturedImage)
        {
            InitializeComponent();

            lblName.Text = "Student Name : " + name;
            lblAge.Text = "Age : " + age;
            lblGender.Text = "Gender : " + gender;
            lblCourse.Text = "Course : " + course;
            lblPhone.Text = "Phone : " + phone;
            lblEmail.Text = "Email : " + email;
            lblAddress.Text = "Address : " + address;

            picBrowse.Image = browseImage;
            picCaptured.Image = capturedImage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = "StudentPreview.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document document = new Document(PageSize.A4);

                PdfWriter.GetInstance(document,
                    new FileStream(sfd.FileName, FileMode.Create));

                document.Open();

                iTextSharp.text.Font titleFont =
    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);

                iTextSharp.text.Font normalFont =
                    FontFactory.GetFont(FontFactory.HELVETICA, 12);

                document.Add(new Paragraph("STUDENT MANAGEMENT SYSTEM", titleFont));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph("Student Preview", titleFont));
                document.Add(new Paragraph(" "));

                //========================
                // Images
                //========================

                PdfPTable imageTable = new PdfPTable(2);
                imageTable.WidthPercentage = 100;

                PdfPCell c1 = new PdfPCell(new Phrase("Browse Photo"));
                c1.HorizontalAlignment = Element.ALIGN_CENTER;
                c1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                imageTable.AddCell(c1);

                PdfPCell c2 = new PdfPCell(new Phrase("Captured Photo"));
                c2.HorizontalAlignment = Element.ALIGN_CENTER;
                c2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                imageTable.AddCell(c2);

                // Browse Image
                if (picBrowse.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picBrowse.Image.Save(ms,
                            System.Drawing.Imaging.ImageFormat.Jpeg);

                        iTextSharp.text.Image img =
                            iTextSharp.text.Image.GetInstance(ms.ToArray());

                        img.ScaleAbsolute(150f, 170f);

                        PdfPCell cell = new PdfPCell(img);
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;

                        imageTable.AddCell(cell);
                    }
                }
                else
                {
                    imageTable.AddCell("");
                }

                // Captured Image
                if (picCaptured.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picCaptured.Image.Save(ms,
                            System.Drawing.Imaging.ImageFormat.Jpeg);

                        iTextSharp.text.Image img =
                            iTextSharp.text.Image.GetInstance(ms.ToArray());

                        img.ScaleAbsolute(150f, 170f);

                        PdfPCell cell = new PdfPCell(img);
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;

                        imageTable.AddCell(cell);
                    }
                }
                else
                {
                    imageTable.AddCell("");
                }

                document.Add(imageTable);

                document.Add(new Paragraph(" "));

                document.Add(new Paragraph(new Phrase(lblName.Text, normalFont)));
                document.Add(new Paragraph(new Phrase(lblAge.Text, normalFont)));
                document.Add(new Paragraph(new Phrase(lblGender.Text, normalFont)));
                document.Add(new Paragraph(new Phrase(lblCourse.Text, normalFont)));
                document.Add(new Paragraph(new Phrase(lblPhone.Text, normalFont)));
                document.Add(new Paragraph(new Phrase(lblEmail.Text, normalFont)));
                document.Add(new Paragraph(new Phrase(lblAddress.Text, normalFont)));

                document.Close();

                MessageBox.Show("PDF Exported Successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}