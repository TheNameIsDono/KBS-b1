namespace kbs1b
{
    partial class HoofdMenu
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
            this.StartButton = new System.Windows.Forms.Button();
            this.ControlsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.ForestGreen;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(50, 50);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(250, 400);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ControlsButton
            // 
            this.ControlsButton.BackColor = System.Drawing.Color.Crimson;
            this.ControlsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ControlsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlsButton.Location = new System.Drawing.Point(385, 50);
            this.ControlsButton.Name = "ControlsButton";
            this.ControlsButton.Size = new System.Drawing.Size(250, 400);
            this.ControlsButton.TabIndex = 1;
            this.ControlsButton.Text = "Wissel Controls";
            this.ControlsButton.UseVisualStyleBackColor = false;
            this.ControlsButton.Click += new System.EventHandler(this.ControllsButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.Black;
            this.ExitButton.Location = new System.Drawing.Point(720, 50);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(250, 400);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Afsluiten";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HoofdMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1034, 507);
            this.ControlBox = false;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ControlsButton);
            this.Controls.Add(this.StartButton);
            this.Name = "HoofdMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HoofdMenu";
            this.Load += new System.EventHandler(this.HoofdMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        internal static bool getSpelStarted;
        private System.Windows.Forms.Button ControlsButton;
        private System.Windows.Forms.Button ExitButton;
    }
}