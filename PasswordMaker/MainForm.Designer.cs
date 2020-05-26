namespace PasswordMaker
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxUppercase = new System.Windows.Forms.CheckBox();
            this.checkBoxLowercase = new System.Windows.Forms.CheckBox();
            this.checkBoxNumbers = new System.Windows.Forms.CheckBox();
            this.checkBoxSymbol = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxUppercase
            // 
            this.checkBoxUppercase.AutoSize = true;
            this.checkBoxUppercase.Location = new System.Drawing.Point(6, 18);
            this.checkBoxUppercase.Name = "checkBoxUppercase";
            this.checkBoxUppercase.Size = new System.Drawing.Size(92, 16);
            this.checkBoxUppercase.TabIndex = 1;
            this.checkBoxUppercase.Text = "英語(大文字)";
            this.checkBoxUppercase.UseVisualStyleBackColor = true;
            // 
            // checkBoxLowercase
            // 
            this.checkBoxLowercase.AutoSize = true;
            this.checkBoxLowercase.Location = new System.Drawing.Point(104, 18);
            this.checkBoxLowercase.Name = "checkBoxLowercase";
            this.checkBoxLowercase.Size = new System.Drawing.Size(92, 16);
            this.checkBoxLowercase.TabIndex = 2;
            this.checkBoxLowercase.Text = "英語(小文字)";
            this.checkBoxLowercase.UseVisualStyleBackColor = true;
            // 
            // checkBoxNumbers
            // 
            this.checkBoxNumbers.AutoSize = true;
            this.checkBoxNumbers.Location = new System.Drawing.Point(202, 18);
            this.checkBoxNumbers.Name = "checkBoxNumbers";
            this.checkBoxNumbers.Size = new System.Drawing.Size(48, 16);
            this.checkBoxNumbers.TabIndex = 3;
            this.checkBoxNumbers.Text = "数字";
            this.checkBoxNumbers.UseVisualStyleBackColor = true;
            // 
            // checkBoxSymbol
            // 
            this.checkBoxSymbol.AutoSize = true;
            this.checkBoxSymbol.Location = new System.Drawing.Point(256, 18);
            this.checkBoxSymbol.Name = "checkBoxSymbol";
            this.checkBoxSymbol.Size = new System.Drawing.Size(48, 16);
            this.checkBoxSymbol.TabIndex = 4;
            this.checkBoxSymbol.Text = "記号";
            this.checkBoxSymbol.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(162, 274);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(243, 274);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 18);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(294, 19);
            this.numericUpDown1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "最大";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 176);
            this.textBoxPassword.MaxLength = 327671;
            this.textBoxPassword.Multiline = true;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPassword.Size = new System.Drawing.Size(306, 92);
            this.textBoxPassword.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxUppercase);
            this.groupBox1.Controls.Add(this.checkBoxLowercase);
            this.groupBox1.Controls.Add(this.checkBoxNumbers);
            this.groupBox1.Controls.Add(this.checkBoxSymbol);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 45);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文字種";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 60);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文字数";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(306, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "パスワード作成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(329, 303);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "パスワード作成";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBoxUppercase;
        private System.Windows.Forms.CheckBox checkBoxLowercase;
        private System.Windows.Forms.CheckBox checkBoxNumbers;
        private System.Windows.Forms.CheckBox checkBoxSymbol;
    }
}

