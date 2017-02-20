namespace Server
{
    partial class ChatBox
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
            this.lblFrom = new System.Windows.Forms.Label();
            this.rtbReceived = new System.Windows.Forms.RichTextBox();
            this.rtbSend = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(25, 9);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(82, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "Message from : ";
            // 
            // rtbReceived
            // 
            this.rtbReceived.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbReceived.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbReceived.Location = new System.Drawing.Point(28, 25);
            this.rtbReceived.Name = "rtbReceived";
            this.rtbReceived.ReadOnly = true;
            this.rtbReceived.Size = new System.Drawing.Size(156, 361);
            this.rtbReceived.TabIndex = 3;
            this.rtbReceived.TabStop = false;
            this.rtbReceived.Text = "";
            // 
            // rtbSend
            // 
            this.rtbSend.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSend.Location = new System.Drawing.Point(190, 25);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.ReadOnly = true;
            this.rtbSend.Size = new System.Drawing.Size(156, 361);
            this.rtbSend.TabIndex = 3;
            this.rtbSend.TabStop = false;
            this.rtbSend.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(295, 399);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(51, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(28, 401);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(263, 20);
            this.txtSend.TabIndex = 5;
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 442);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbSend);
            this.Controls.Add(this.rtbReceived);
            this.Controls.Add(this.lblFrom);
            this.Name = "ChatBox";
            this.Text = "ChatBox";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatBox_FormClosed);
            this.Load += new System.EventHandler(this.ChatBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.RichTextBox rtbReceived;
        private System.Windows.Forms.RichTextBox rtbSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
    }
}