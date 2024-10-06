using QRCoder;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QR
{
    public partial class QRPROTO : Form
    {
        private string selectedUsername;
        public QRPROTO()
        {
            InitializeComponent();
            LoadUsers();
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false; // Ensure that only one row is selected at a time

        }
        private void LoadUsers()
        {
            using (MySqlConnection connection = new MySqlConnection("SERVER=LOCALHOST; DATABASE=barangay_22; UID=root; PASSWORD=bobo;"))
            {
                connection.Open();
                string query = "SELECT iduser, userName FROM user";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt; // Bind the DataGridView with the user data
            }
        }
        private void btnGenerateQR_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Get selected user's data
                string selectedUserID = dgvUsers.SelectedRows[0].Cells["iduser"].Value.ToString();
                selectedUsername = dgvUsers.SelectedRows[0].Cells["userName"].Value.ToString(); // Store the selected username

                // Generate QR code based on user's data
                string qrData = selectedUserID; // Use UserID for uniqueness
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                // Resize the QR code image to fit the PictureBox
                Bitmap resizedImage = new Bitmap(qrCodeImage, new Size(150, 150)); // Set the size as per your requirements

                // Display QR code in PictureBox
                pictureBoxQRCode.Image = resizedImage;

                // Save QR code data to the database
                SaveQRCodeToDatabase(selectedUserID, qrData);
            }
            else
            {
                MessageBox.Show("Please select a user.");
            }
        }

        private void SaveQRCodeToDatabase(string userID, string qrData)
        {
            using (MySqlConnection connection = new MySqlConnection("SERVER=LOCALHOST; DATABASE=barangay_22; UID=root; PASSWORD=bobo;"))
            {
                connection.Open();
                string query = "UPDATE user SET QRCode = @qrData WHERE iduser = @userID"; // Column name updated
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@qrData", qrData);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            if (pictureBoxQRCode.Image != null)
            {
                // Create a SaveFileDialog to prompt user for a file location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                    saveFileDialog.Title = "Save QR Code Image";

                    // Set the default file name to the selected username
                    saveFileDialog.FileName = $"{selectedUsername}_QRCode"; // Automatically name it based on username

                    // Show the dialog and get result
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the QR code image to the selected file path
                        pictureBoxQRCode.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show("QR Code saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No QR Code image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
 