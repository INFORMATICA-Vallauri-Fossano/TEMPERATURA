namespace neveClient
{
    partial class frmClient
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnInviaMsg = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(21, 21);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(78, 16);
            this.lblMsg.TabIndex = 19;
            this.lblMsg.Text = "Messaggio:";
            // 
            // btnInviaMsg
            // 
            this.btnInviaMsg.Location = new System.Drawing.Point(330, 33);
            this.btnInviaMsg.Name = "btnInviaMsg";
            this.btnInviaMsg.Size = new System.Drawing.Size(108, 51);
            this.btnInviaMsg.TabIndex = 18;
            this.btnInviaMsg.Text = "Invia";
            this.btnInviaMsg.UseVisualStyleBackColor = true;
            this.btnInviaMsg.Click += new System.EventHandler(this.btnInviaMsg_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(24, 47);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(285, 22);
            this.txtMsg.TabIndex = 16;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(24, 107);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(414, 337);
            this.txtLog.TabIndex = 17;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 461);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnInviaMsg);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtLog);
            this.Name = "frmClient";
            this.Text = "Client Neve";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnInviaMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtLog;
    }
}

