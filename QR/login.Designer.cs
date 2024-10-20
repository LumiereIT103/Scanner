namespace QR
{
    partial class login
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
            label1 = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            buttonLogin = new Button();
            buttonSignUp = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(334, 55);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "please login";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(119, 144);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(268, 23);
            textBoxUsername.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(119, 209);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(268, 23);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(119, 115);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 3;
            label2.Text = "username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(119, 182);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "password";
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(294, 278);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(93, 23);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "buttonLogin";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonSignUp
            // 
            buttonSignUp.Location = new Point(119, 278);
            buttonSignUp.Name = "buttonSignUp";
            buttonSignUp.Size = new Size(100, 23);
            buttonSignUp.TabIndex = 6;
            buttonSignUp.Text = "buttonSignUp";
            buttonSignUp.UseVisualStyleBackColor = true;
            buttonSignUp.Click += buttonSignUp_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSignUp);
            Controls.Add(buttonLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(label1);
            Name = "login";
            Text = "login";
            Load += login_Load;
            KeyPress += login_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label label2;
        private Label label3;
        private Button buttonLogin;
        private Button buttonSignUp;
    }
}