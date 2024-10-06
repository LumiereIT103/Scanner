using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QR
{
    public partial class login : Form
    {
        private string qrDataBuffer = ""; // Buffer to hold scanned QR code data
        public login()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Process the QR code once 'Enter' is pressed
                LoginWithQRCode(qrDataBuffer);
                qrDataBuffer = ""; // Clear buffer after login attempt
            }
            else
            {
                // Accumulate characters for QR code
                qrDataBuffer += e.KeyChar;
            }
        }
        private void LoginWithQRCode(string qrData)
        {
            if (!string.IsNullOrEmpty(qrData))
            {
                using (MySqlConnection connection = new MySqlConnection("SERVER=LOCALHOST; DATABASE=barangay_22; UID=root; PASSWORD=bobo;"))
                {
                    connection.Open();
                    string query = "SELECT * FROM user WHERE QRCode = @qrData";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@qrData", qrData);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader["userName"].ToString();
                            MessageBox.Show($"Welcome, {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Proceed to main form or dashboard
                            this.Hide();
                            Form1 mainForm = new Form1();
                            mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid QR Code. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
