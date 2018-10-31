namespace XPY.Templates {
    partial class SlnWizard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.JWTPage = new AeroWizard.WizardPage();
            this.Expires = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.SecureKey = new System.Windows.Forms.TextBox();
            this.Audience = new System.Windows.Forms.TextBox();
            this.Issuer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SwaggerPage = new AeroWizard.WizardPage();
            this.SwaggerDescription = new System.Windows.Forms.TextBox();
            this.SwaggerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.EFSettingPage = new AeroWizard.WizardPage();
            this.dbConnectionString = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.JWTPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Expires)).BeginInit();
            this.SwaggerPage.SuspendLayout();
            this.EFSettingPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.JWTPage);
            this.wizardControl1.Pages.Add(this.SwaggerPage);
            this.wizardControl1.Pages.Add(this.EFSettingPage);
            this.wizardControl1.Size = new System.Drawing.Size(574, 383);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "XPY.Templates 方案設定精靈";
            // 
            // JWTPage
            // 
            this.JWTPage.Controls.Add(this.Expires);
            this.JWTPage.Controls.Add(this.label4);
            this.JWTPage.Controls.Add(this.SecureKey);
            this.JWTPage.Controls.Add(this.Audience);
            this.JWTPage.Controls.Add(this.Issuer);
            this.JWTPage.Controls.Add(this.label3);
            this.JWTPage.Controls.Add(this.label2);
            this.JWTPage.Controls.Add(this.label1);
            this.JWTPage.Name = "JWTPage";
            this.JWTPage.NextPage = this.SwaggerPage;
            this.JWTPage.Size = new System.Drawing.Size(527, 234);
            this.JWTPage.TabIndex = 0;
            this.JWTPage.Text = "JSON Web Token 設定";
            // 
            // Expires
            // 
            this.Expires.Location = new System.Drawing.Point(110, 87);
            this.Expires.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.Expires.Name = "Expires";
            this.Expires.Size = new System.Drawing.Size(414, 23);
            this.Expires.TabIndex = 15;
            this.Expires.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Expires.ThousandsSeparator = true;
            this.Expires.Value = new decimal(new int[] {
            43200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Expires(Second):";
            // 
            // SecureKey
            // 
            this.SecureKey.Location = new System.Drawing.Point(77, 59);
            this.SecureKey.Name = "SecureKey";
            this.SecureKey.Size = new System.Drawing.Size(447, 23);
            this.SecureKey.TabIndex = 14;
            this.SecureKey.Text = "DefaultSecureKey";
            // 
            // Audience
            // 
            this.Audience.Location = new System.Drawing.Point(77, 31);
            this.Audience.Name = "Audience";
            this.Audience.Size = new System.Drawing.Size(447, 23);
            this.Audience.TabIndex = 13;
            this.Audience.Text = "DefaultAudience";
            // 
            // Issuer
            // 
            this.Issuer.Location = new System.Drawing.Point(77, 3);
            this.Issuer.Name = "Issuer";
            this.Issuer.Size = new System.Drawing.Size(447, 23);
            this.Issuer.TabIndex = 12;
            this.Issuer.Text = "DefaultIssuer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "SecureKey:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Audience:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Issuer:";
            // 
            // SwaggerPage
            // 
            this.SwaggerPage.Controls.Add(this.SwaggerDescription);
            this.SwaggerPage.Controls.Add(this.SwaggerName);
            this.SwaggerPage.Controls.Add(this.label5);
            this.SwaggerPage.Controls.Add(this.label7);
            this.SwaggerPage.Name = "SwaggerPage";
            this.SwaggerPage.NextPage = this.EFSettingPage;
            this.SwaggerPage.Size = new System.Drawing.Size(527, 234);
            this.SwaggerPage.TabIndex = 1;
            this.SwaggerPage.Text = "Swagger 設定";
            // 
            // SwaggerDescription
            // 
            this.SwaggerDescription.Location = new System.Drawing.Point(6, 53);
            this.SwaggerDescription.Multiline = true;
            this.SwaggerDescription.Name = "SwaggerDescription";
            this.SwaggerDescription.Size = new System.Drawing.Size(518, 154);
            this.SwaggerDescription.TabIndex = 20;
            // 
            // SwaggerName
            // 
            this.SwaggerName.Location = new System.Drawing.Point(77, 3);
            this.SwaggerName.Name = "SwaggerName";
            this.SwaggerName.Size = new System.Drawing.Size(447, 23);
            this.SwaggerName.TabIndex = 18;
            this.SwaggerName.Text = "MyAPI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Name:";
            // 
            // EFSettingPage
            // 
            this.EFSettingPage.Controls.Add(this.dbType);
            this.EFSettingPage.Controls.Add(this.dbConnectionString);
            this.EFSettingPage.Controls.Add(this.label6);
            this.EFSettingPage.Controls.Add(this.label8);
            this.EFSettingPage.Name = "EFSettingPage";
            this.EFSettingPage.Size = new System.Drawing.Size(527, 234);
            this.EFSettingPage.TabIndex = 2;
            this.EFSettingPage.Text = "Entity Framework Core 設定";
            // 
            // dbConnectionString
            // 
            this.dbConnectionString.Location = new System.Drawing.Point(77, 31);
            this.dbConnectionString.Name = "dbConnectionString";
            this.dbConnectionString.Size = new System.Drawing.Size(447, 23);
            this.dbConnectionString.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "連線字串:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "資料庫類型:";
            // 
            // dbType
            // 
            this.dbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbType.FormattingEnabled = true;
            this.dbType.Items.AddRange(new object[] {
            "MSSQL",
            "PostgreSQL"});
            this.dbType.Location = new System.Drawing.Point(79, 3);
            this.dbType.Name = "dbType";
            this.dbType.Size = new System.Drawing.Size(445, 23);
            this.dbType.TabIndex = 18;
            // 
            // SlnWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 383);
            this.ControlBox = false;
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SlnWizard";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.JWTPage.ResumeLayout(false);
            this.JWTPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Expires)).EndInit();
            this.SwaggerPage.ResumeLayout(false);
            this.SwaggerPage.PerformLayout();
            this.EFSettingPage.ResumeLayout(false);
            this.EFSettingPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.WizardControl wizardControl1;
        private AeroWizard.WizardPage JWTPage;
        internal System.Windows.Forms.NumericUpDown Expires;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox SecureKey;
        internal System.Windows.Forms.TextBox Audience;
        internal System.Windows.Forms.TextBox Issuer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private AeroWizard.WizardPage SwaggerPage;
        internal System.Windows.Forms.TextBox SwaggerDescription;
        internal System.Windows.Forms.TextBox SwaggerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private AeroWizard.WizardPage EFSettingPage;
        internal System.Windows.Forms.TextBox dbConnectionString;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox dbType;
    }
}