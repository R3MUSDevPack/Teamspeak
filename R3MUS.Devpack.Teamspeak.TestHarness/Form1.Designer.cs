namespace R3MUS.Devpack.Teamspeak.TestHarness
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtbxUrl = new System.Windows.Forms.TextBox();
            this.txtbxSQName = new System.Windows.Forms.TextBox();
            this.txtbxSQPWrd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstvwClients = new System.Windows.Forms.ListView();
            this.txtbxMsg = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show All Clients";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbxUrl
            // 
            this.txtbxUrl.Location = new System.Drawing.Point(121, 13);
            this.txtbxUrl.Name = "txtbxUrl";
            this.txtbxUrl.Size = new System.Drawing.Size(189, 20);
            this.txtbxUrl.TabIndex = 1;
            this.txtbxUrl.Text = "ah.nerfedalliance.com";
            // 
            // txtbxSQName
            // 
            this.txtbxSQName.Location = new System.Drawing.Point(121, 40);
            this.txtbxSQName.Name = "txtbxSQName";
            this.txtbxSQName.Size = new System.Drawing.Size(189, 20);
            this.txtbxSQName.TabIndex = 2;
            this.txtbxSQName.Text = "Clyde_ServerAdmin";
            // 
            // txtbxSQPWrd
            // 
            this.txtbxSQPWrd.Location = new System.Drawing.Point(121, 66);
            this.txtbxSQPWrd.Name = "txtbxSQPWrd";
            this.txtbxSQPWrd.Size = new System.Drawing.Size(189, 20);
            this.txtbxSQPWrd.TabIndex = 3;
            this.txtbxSQPWrd.Text = "vtLA4ucx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "TS URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "SQ Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "SQ Password";
            // 
            // lstvwClients
            // 
            this.lstvwClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvwClients.FullRowSelect = true;
            this.lstvwClients.Location = new System.Drawing.Point(28, 127);
            this.lstvwClients.Name = "lstvwClients";
            this.lstvwClients.Size = new System.Drawing.Size(388, 172);
            this.lstvwClients.TabIndex = 7;
            this.lstvwClients.UseCompatibleStateImageBehavior = false;
            this.lstvwClients.View = System.Windows.Forms.View.Details;
            // 
            // txtbxMsg
            // 
            this.txtbxMsg.Location = new System.Drawing.Point(121, 93);
            this.txtbxMsg.Name = "txtbxMsg";
            this.txtbxMsg.Size = new System.Drawing.Size(189, 20);
            this.txtbxMsg.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Poke Selected User";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 311);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtbxMsg);
            this.Controls.Add(this.lstvwClients);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxSQPWrd);
            this.Controls.Add(this.txtbxSQName);
            this.Controls.Add(this.txtbxUrl);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtbxUrl;
        private System.Windows.Forms.TextBox txtbxSQName;
        private System.Windows.Forms.TextBox txtbxSQPWrd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lstvwClients;
        private System.Windows.Forms.TextBox txtbxMsg;
        private System.Windows.Forms.Button button2;
    }
}

