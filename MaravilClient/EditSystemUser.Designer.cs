namespace MaravilClient
{
    partial class EditSystemUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.btChangeStatus = new System.Windows.Forms.Button();
            this.btResetPass = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btChangeRol = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // btChangeStatus
            // 
            this.btChangeStatus.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btChangeStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btChangeStatus.Location = new System.Drawing.Point(3, 150);
            this.btChangeStatus.Name = "btChangeStatus";
            this.btChangeStatus.Size = new System.Drawing.Size(78, 58);
            this.btChangeStatus.TabIndex = 1;
            this.btChangeStatus.Text = "Cambiar Estado";
            this.btChangeStatus.UseVisualStyleBackColor = false;
            this.btChangeStatus.Click += new System.EventHandler(this.btChangeStatus_Click);
            // 
            // btResetPass
            // 
            this.btResetPass.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btResetPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btResetPass.Location = new System.Drawing.Point(87, 150);
            this.btResetPass.Name = "btResetPass";
            this.btResetPass.Size = new System.Drawing.Size(104, 58);
            this.btResetPass.TabIndex = 2;
            this.btResetPass.Text = "Resetear Contraseña";
            this.btResetPass.UseVisualStyleBackColor = false;
            this.btResetPass.Click += new System.EventHandler(this.btResetPass_Click);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.Coral;
            this.btClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btClose.Location = new System.Drawing.Point(291, 150);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 58);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "Salir";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Estado:";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbUser.Location = new System.Drawing.Point(97, 29);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(16, 21);
            this.lbUser.TabIndex = 5;
            this.lbUser.Text = "-";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbStatus.Location = new System.Drawing.Point(97, 67);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(16, 21);
            this.lbStatus.TabIndex = 6;
            this.lbStatus.Text = "-";
            // 
            // btChangeRol
            // 
            this.btChangeRol.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btChangeRol.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btChangeRol.FlatAppearance.BorderSize = 2;
            this.btChangeRol.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btChangeRol.Location = new System.Drawing.Point(197, 150);
            this.btChangeRol.Name = "btChangeRol";
            this.btChangeRol.Size = new System.Drawing.Size(86, 58);
            this.btChangeRol.TabIndex = 7;
            this.btChangeRol.Text = "Cambiar Rol";
            this.btChangeRol.UseVisualStyleBackColor = false;
            this.btChangeRol.Click += new System.EventHandler(this.btChangeRol_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rol:";
            // 
            // lbRol
            // 
            this.lbRol.AutoSize = true;
            this.lbRol.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbRol.Location = new System.Drawing.Point(97, 103);
            this.lbRol.Name = "lbRol";
            this.lbRol.Size = new System.Drawing.Size(16, 21);
            this.lbRol.TabIndex = 9;
            this.lbRol.Text = "-";
            // 
            // EditSystemUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(369, 210);
            this.Controls.Add(this.lbRol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btChangeRol);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btResetPass);
            this.Controls.Add(this.btChangeStatus);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.MediumBlue;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSystemUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maravil - Editar usuario";
            this.Load += new System.EventHandler(this.EditSystemUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btChangeStatus;
        private Button btResetPass;
        private Button btClose;
        private Label label2;
        private Label lbUser;
        private Label lbStatus;
        private Button btChangeRol;
        private Label label3;
        private Label lbRol;
    }
}