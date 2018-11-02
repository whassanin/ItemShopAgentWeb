namespace AgentLogApp
{
    partial class AgentLogWindow
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
            this.agentLogrtb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // agentLogrtb
            // 
            this.agentLogrtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentLogrtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agentLogrtb.Location = new System.Drawing.Point(0, 0);
            this.agentLogrtb.Name = "agentLogrtb";
            this.agentLogrtb.ReadOnly = true;
            this.agentLogrtb.Size = new System.Drawing.Size(284, 261);
            this.agentLogrtb.TabIndex = 1;
            this.agentLogrtb.Text = "";
            this.agentLogrtb.TextChanged += new System.EventHandler(this.agentLogrtb_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.agentLogrtb);
            this.Name = "Form1";
            this.Text = "Agent Log Window";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox agentLogrtb;
    }
}

