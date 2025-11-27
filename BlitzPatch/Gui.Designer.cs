namespace BlitzPatch
{
    partial class Gui
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
            this.landingPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.landingStartButton = new System.Windows.Forms.Button();
            this.landingTitleLabel = new System.Windows.Forms.Label();
            this.unitPanel = new System.Windows.Forms.Panel();
            this.landingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // landingPanel
            // 
            this.landingPanel.Controls.Add(this.unitPanel);
            this.landingPanel.Controls.Add(this.button1);
            this.landingPanel.Controls.Add(this.textBox1);
            this.landingPanel.Controls.Add(this.label1);
            this.landingPanel.Controls.Add(this.landingStartButton);
            this.landingPanel.Controls.Add(this.landingTitleLabel);
            this.landingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.landingPanel.Location = new System.Drawing.Point(0, 0);
            this.landingPanel.Name = "landingPanel";
            this.landingPanel.Size = new System.Drawing.Size(390, 288);
            this.landingPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 245);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select your Blitzkrieg 3 directory to continue.";
            // 
            // landingStartButton
            // 
            this.landingStartButton.Location = new System.Drawing.Point(328, 242);
            this.landingStartButton.Name = "landingStartButton";
            this.landingStartButton.Size = new System.Drawing.Size(59, 24);
            this.landingStartButton.TabIndex = 3;
            this.landingStartButton.Text = "Continue";
            this.landingStartButton.UseVisualStyleBackColor = true;
            this.landingStartButton.Click += new System.EventHandler(this.landingStartButton_Click);
            // 
            // landingTitleLabel
            // 
            this.landingTitleLabel.AutoSize = true;
            this.landingTitleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.landingTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.landingTitleLabel.Name = "landingTitleLabel";
            this.landingTitleLabel.Size = new System.Drawing.Size(203, 30);
            this.landingTitleLabel.TabIndex = 0;
            this.landingTitleLabel.Text = "BlitzPatch (0.00.0)";
            // 
            // unitPanel
            // 
            this.unitPanel.Location = new System.Drawing.Point(283, 272);
            this.unitPanel.Name = "unitPanel";
            this.unitPanel.Size = new System.Drawing.Size(390, 288);
            this.unitPanel.TabIndex = 1;
            this.unitPanel.Visible = false;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 288);
            this.Controls.Add(this.landingPanel);
            this.Name = "Gui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlitzPatch";
            this.Load += new System.EventHandler(this.Gui_Load);
            this.landingPanel.ResumeLayout(false);
            this.landingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel landingPanel;
        private System.Windows.Forms.Button landingStartButton;
        private System.Windows.Forms.Label landingTitleLabel;
        private System.Windows.Forms.Panel unitPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
