namespace QR
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnChoosePdf = new Button();
            lblFilePath = new Label();
            btnGenerateQRCode = new Button();
            pictureBoxQRCode = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).BeginInit();
            SuspendLayout();
            // 
            // btnChoosePdf
            // 
            btnChoosePdf.Location = new Point(137, 325);
            btnChoosePdf.Name = "btnChoosePdf";
            btnChoosePdf.Size = new Size(173, 29);
            btnChoosePdf.TabIndex = 0;
            btnChoosePdf.Text = "btnChoosePdf";
            btnChoosePdf.UseVisualStyleBackColor = true;
            btnChoosePdf.Click += btnChoosePdf_Click;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(369, 366);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(77, 20);
            lblFilePath.TabIndex = 1;
            lblFilePath.Text = "lblFilePath";
            // 
            // btnGenerateQRCode
            // 
            btnGenerateQRCode.Location = new Point(526, 331);
            btnGenerateQRCode.Name = "btnGenerateQRCode";
            btnGenerateQRCode.Size = new Size(197, 29);
            btnGenerateQRCode.TabIndex = 2;
            btnGenerateQRCode.Text = "btnGenerateQRCode";
            btnGenerateQRCode.UseVisualStyleBackColor = true;
            btnGenerateQRCode.Click += btnGenerateQRCode_Click;
            // 
            // pictureBoxQRCode
            // 
            pictureBoxQRCode.Location = new Point(53, 12);
            pictureBoxQRCode.Name = "pictureBoxQRCode";
            pictureBoxQRCode.Size = new Size(721, 307);
            pictureBoxQRCode.TabIndex = 3;
            pictureBoxQRCode.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxQRCode);
            Controls.Add(btnGenerateQRCode);
            Controls.Add(lblFilePath);
            Controls.Add(btnChoosePdf);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxQRCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChoosePdf;
        private Label lblFilePath;
        private Button btnGenerateQRCode;
        private PictureBox pictureBoxQRCode;
    }
}
