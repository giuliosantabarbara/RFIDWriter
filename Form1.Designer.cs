namespace AnimalCS
{
  partial class Form1
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
            this.btnStop = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rbHDX = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rbFDXHitag = new System.Windows.Forms.RadioButton();
            this.rbFDXEm = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lblScritture = new System.Windows.Forms.Label();
            this.lblRigheFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCaricaFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trspScritto = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(208, 120);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(420, 34);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.Close_Click);
            // 
            // fileName
            // 
            this.fileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileName.Location = new System.Drawing.Point(208, 43);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(344, 22);
            this.fileName.TabIndex = 6;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(208, 20);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(80, 20);
            this.fileNameLabel.TabIndex = 7;
            this.fileNameLabel.Text = "Nome File";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl);
            this.groupBox3.Location = new System.Drawing.Point(12, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 155);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipologia Transponder";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(8, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(174, 119);
            this.tabControl.TabIndex = 13;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rbHDX);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(166, 86);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HDX";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rbHDX
            // 
            this.rbHDX.AutoSize = true;
            this.rbHDX.Location = new System.Drawing.Point(16, 20);
            this.rbHDX.Name = "rbHDX";
            this.rbHDX.Size = new System.Drawing.Size(105, 24);
            this.rbHDX.TabIndex = 10;
            this.rbHDX.TabStop = true;
            this.rbHDX.Text = "TMS37190";
            this.rbHDX.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rbFDXHitag);
            this.tabPage2.Controls.Add(this.rbFDXEm);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(166, 86);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FDX-B";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rbFDXHitag
            // 
            this.rbFDXHitag.AutoSize = true;
            this.rbFDXHitag.Location = new System.Drawing.Point(16, 20);
            this.rbFDXHitag.Name = "rbFDXHitag";
            this.rbFDXHitag.Size = new System.Drawing.Size(107, 24);
            this.rbFDXHitag.TabIndex = 12;
            this.rbFDXHitag.TabStop = true;
            this.rbFDXHitag.Text = "Hitag micro";
            this.rbFDXHitag.UseVisualStyleBackColor = true;
            // 
            // rbFDXEm
            // 
            this.rbFDXEm.AutoSize = true;
            this.rbFDXEm.Location = new System.Drawing.Point(16, 50);
            this.rbFDXEm.Name = "rbFDXEm";
            this.rbFDXEm.Size = new System.Drawing.Size(87, 24);
            this.rbFDXEm.TabIndex = 12;
            this.rbFDXEm.TabStop = true;
            this.rbFDXEm.Text = "EM4305";
            this.rbFDXEm.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(208, 80);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(420, 33);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trspScritto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblScritture);
            this.groupBox1.Controls.Add(this.lblRigheFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 207);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info elaborazione";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(307, 168);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 99);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(598, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Scritture effettuate:";
            // 
            // lblScritture
            // 
            this.lblScritture.AutoSize = true;
            this.lblScritture.Location = new System.Drawing.Point(168, 61);
            this.lblScritture.Name = "lblScritture";
            this.lblScritture.Size = new System.Drawing.Size(14, 20);
            this.lblScritture.TabIndex = 2;
            this.lblScritture.Text = "-";
            // 
            // lblRigheFile
            // 
            this.lblRigheFile.AutoSize = true;
            this.lblRigheFile.Location = new System.Drawing.Point(168, 32);
            this.lblRigheFile.Name = "lblRigheFile";
            this.lblRigheFile.Size = new System.Drawing.Size(14, 20);
            this.lblRigheFile.TabIndex = 1;
            this.lblRigheFile.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numero righe file:";
            // 
            // btnCaricaFile
            // 
            this.btnCaricaFile.Location = new System.Drawing.Point(558, 39);
            this.btnCaricaFile.Name = "btnCaricaFile";
            this.btnCaricaFile.Size = new System.Drawing.Size(70, 28);
            this.btnCaricaFile.TabIndex = 15;
            this.btnCaricaFile.Text = "Carica";
            this.btnCaricaFile.UseVisualStyleBackColor = true;
            this.btnCaricaFile.Click += new System.EventHandler(this.btnCaricaFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Trasponder scritto: ";
            // 
            // trspScritto
            // 
            this.trspScritto.AutoSize = true;
            this.trspScritto.Location = new System.Drawing.Point(168, 137);
            this.trspScritto.Name = "trspScritto";
            this.trspScritto.Size = new System.Drawing.Size(14, 20);
            this.trspScritto.TabIndex = 7;
            this.trspScritto.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(640, 390);
            this.Controls.Add(this.btnCaricaFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.btnStop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Animal Code Looped Write v.1.1";
            this.groupBox3.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbFDXEm;
        private System.Windows.Forms.RadioButton rbFDXHitag;
        private System.Windows.Forms.RadioButton rbHDX;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRigheFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCaricaFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblScritture;
        private System.Windows.Forms.Label trspScritto;
        private System.Windows.Forms.Label label1;
    }
}

