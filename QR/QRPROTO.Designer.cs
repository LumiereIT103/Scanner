namespace QR
{
    partial class QRPROTO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvUsers = new DataGridView();
            pictureBoxQRCode = new PictureBox();
            btnGenerateQR = new Button();
            btnSaveQR = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 32);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(380, 327);
            dgvUsers.TabIndex = 0;
            // 
            // pictureBoxQRCode
            // 
            pictureBoxQRCode.Location = new Point(398, 32);
            pictureBoxQRCode.Name = "pictureBoxQRCode";
            pictureBoxQRCode.Size = new Size(390, 327);
            pictureBoxQRCode.TabIndex = 1;
            pictureBoxQRCode.TabStop = false;
            // 
            // btnGenerateQR
            // 
            btnGenerateQR.Location = new Point(74, 391);
            btnGenerateQR.Name = "btnGenerateQR";
            btnGenerateQR.Size = new Size(308, 23);
            btnGenerateQR.TabIndex = 2;
            btnGenerateQR.Text = "generate qr";
            btnGenerateQR.UseVisualStyleBackColor = true;
            btnGenerateQR.Click += btnGenerateQR_Click;
            // 
            // btnSaveQR
            // 
            btnSaveQR.Location = new Point(515, 391);
            btnSaveQR.Name = "btnSaveQR";
            btnSaveQR.Size = new Size(187, 23);
            btnSaveQR.TabIndex = 3;
            btnSaveQR.Text = "button1";
            btnSaveQR.UseVisualStyleBackColor = true;
            btnSaveQR.Click += btnSaveQR_Click;
            // 
            // QRPROTO
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSaveQR);
            Controls.Add(btnGenerateQR);
            Controls.Add(pictureBoxQRCode);
            Controls.Add(dgvUsers);
            Name = "QRPROTO";
            Text = "QRPROTO";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private PictureBox pictureBoxQRCode;
        private Button btnGenerateQR;
        private Button btnSaveQR;
    }
}