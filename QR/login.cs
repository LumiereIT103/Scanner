using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

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

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            // Get username and password from input
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // Hash the password
            string hashedPassword = HashPassword(password);

            // Save the username and hashed password to MySQL
            SaveUserToDatabase(username, hashedPassword);

            // Inform the user
            MessageBox.Show("Sign-up successful! Your password has been securely stored.");
        }
        private void SaveUserToDatabase(string username, string hashedPassword)
        {
            string connectionString = "SERVER=LOCALHOST; DATABASE=barangay_22; UID=root; PASSWORD=bobo;";

            string query = "INSERT INTO user (userName, Hashedpassword) VALUES (@Username, @HashedPassword)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@HashedPassword", hashedPassword);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            

            // Connection string
            string connectionString = "SERVER=LOCALHOST; DATABASE=barangay_22; UID=root; PASSWORD=bobo;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Fetch the user details (raw or hashed password)
                string query = "SELECT password, Hashedpassword FROM user WHERE userName = @Username";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedRawPassword = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : reader.GetString("Password");
                            string storedHashedPassword = reader.IsDBNull(reader.GetOrdinal("HashedPassword")) ? null : reader.GetString("HashedPassword");

                            // Check if user has a hashed password
                            if (!string.IsNullOrEmpty(storedHashedPassword))
                            {
                                // User is already migrated, so compare hashed passwords
                                string hashedPassword = HashPassword(password);
                                if (storedHashedPassword == hashedPassword)
                                {
                                    MessageBox.Show("Login successful (hashed password)!");
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password.");
                                }
                            }
                            else if (!string.IsNullOrEmpty(storedRawPassword))
                            {
                                // User still has a raw password, compare directly, then migrate
                                if (storedRawPassword == password)
                                {
                                    // Raw password matches, so hash it and update the database
                                    string newHashedPassword = HashPassword(password);
                                    MigratePasswordToHashed(username, newHashedPassword);

                                    MessageBox.Show("Login successful! Your password has been migrated to a secure hash.");
                                    this.Hide();
                                    Form1 mainForm = new Form1();
                                    mainForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username not found.");
                        }
                    }
                }
            }
            
        }
        private string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder hashString = new StringBuilder();

                foreach (byte b in hashedBytes)
                {
                    hashString.Append(b.ToString("x2"));
                }

                return hashString.ToString();
            }
        }
        private void MigratePasswordToHashed(string username, string hashedPassword)
        {
            string connectionString = "SERVER=LOCALHOST; DATABASE=barangay_22; UID=root; PASSWORD=bobo;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE user SET Hashedpassword = @HashedPassword WHERE userName = @Username";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
