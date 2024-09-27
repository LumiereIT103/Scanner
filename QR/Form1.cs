using QRCoder;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QR
{
    public partial class Form1 : Form
    {
        private string selectedPdfPath;
        private Bitmap GenerateQRCode(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20); // Size of the QR code
            return qrCodeImage;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnChoosePdf_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the selected PDF file path
                    selectedPdfPath = openFileDialog.FileName;
                    lblFilePath.Text = "Selected PDF: " + selectedPdfPath;
                }
            }
        }

        private void btnGenerateQRCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedPdfPath))
            {
                MessageBox.Show("Please select a PDF file first.");
                return;
            }

            // Generate QR code for the selected PDF file path
            Bitmap qrCodeImage = GenerateQRCode(selectedPdfPath);

            // Display the QR code in the PictureBox
            pictureBoxQRCode.Image = qrCodeImage;
            pictureBoxQRCode.SizeMode = PictureBoxSizeMode.Zoom; // Adjust PictureBox size mode if needed
        }
    }
}
