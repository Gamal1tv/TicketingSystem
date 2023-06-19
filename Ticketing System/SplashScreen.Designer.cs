namespace Ticketing_System
{
    partial class SplashScreen
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
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnTechnician = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(96, 79);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(191, 137);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.TabStop = false;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnTechnician
            // 
            this.btnTechnician.Location = new System.Drawing.Point(303, 79);
            this.btnTechnician.Name = "btnTechnician";
            this.btnTechnician.Size = new System.Drawing.Size(191, 137);
            this.btnTechnician.TabIndex = 0;
            this.btnTechnician.TabStop = false;
            this.btnTechnician.Text = "Technician";
            this.btnTechnician.UseVisualStyleBackColor = true;
            this.btnTechnician.Click += new System.EventHandler(this.btnTechnician_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 316);
            this.Controls.Add(this.btnTechnician);
            this.Controls.Add(this.btnCustomer);
            this.Name = "SplashScreen";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnTechnician;
    }
}