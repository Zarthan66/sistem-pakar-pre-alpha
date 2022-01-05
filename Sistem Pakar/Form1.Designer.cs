namespace Sistem_Pakar
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.datasetBtn = new System.Windows.Forms.Button();
            this.datasetTextBox = new System.Windows.Forms.TextBox();
            this.ruleTextBox = new System.Windows.Forms.TextBox();
            this.dataPLabel = new System.Windows.Forms.Label();
            this.totalRuleTxtBox = new System.Windows.Forms.TextBox();
            this.trueRadioBtn = new System.Windows.Forms.RadioButton();
            this.falseRadioBtn = new System.Windows.Forms.RadioButton();
            this.proccedBtn = new System.Windows.Forms.Button();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // datasetBtn
            // 
            this.datasetBtn.Location = new System.Drawing.Point(13, 12);
            this.datasetBtn.Name = "datasetBtn";
            this.datasetBtn.Size = new System.Drawing.Size(89, 23);
            this.datasetBtn.TabIndex = 0;
            this.datasetBtn.Text = "Open Dataset";
            this.datasetBtn.UseVisualStyleBackColor = true;
            this.datasetBtn.Click += new System.EventHandler(this.btnDataset_Click);
            // 
            // datasetTextBox
            // 
            this.datasetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.datasetTextBox.Location = new System.Drawing.Point(13, 41);
            this.datasetTextBox.Multiline = true;
            this.datasetTextBox.Name = "datasetTextBox";
            this.datasetTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datasetTextBox.Size = new System.Drawing.Size(197, 205);
            this.datasetTextBox.TabIndex = 1;
            // 
            // ruleTextBox
            // 
            this.ruleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ruleTextBox.Location = new System.Drawing.Point(216, 41);
            this.ruleTextBox.Multiline = true;
            this.ruleTextBox.Name = "ruleTextBox";
            this.ruleTextBox.ReadOnly = true;
            this.ruleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ruleTextBox.Size = new System.Drawing.Size(197, 205);
            this.ruleTextBox.TabIndex = 2;
            // 
            // dataPLabel
            // 
            this.dataPLabel.AutoSize = true;
            this.dataPLabel.Location = new System.Drawing.Point(264, 17);
            this.dataPLabel.Name = "dataPLabel";
            this.dataPLabel.Size = new System.Drawing.Size(97, 13);
            this.dataPLabel.TabIndex = 3;
            this.dataPLabel.Text = "Total tipe penyakit:";
            // 
            // totalRuleTxtBox
            // 
            this.totalRuleTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalRuleTxtBox.Location = new System.Drawing.Point(367, 15);
            this.totalRuleTxtBox.Name = "totalRuleTxtBox";
            this.totalRuleTxtBox.ReadOnly = true;
            this.totalRuleTxtBox.Size = new System.Drawing.Size(29, 20);
            this.totalRuleTxtBox.TabIndex = 4;
            // 
            // trueRadioBtn
            // 
            this.trueRadioBtn.AutoSize = true;
            this.trueRadioBtn.Location = new System.Drawing.Point(422, 85);
            this.trueRadioBtn.Name = "trueRadioBtn";
            this.trueRadioBtn.Size = new System.Drawing.Size(38, 17);
            this.trueRadioBtn.TabIndex = 6;
            this.trueRadioBtn.TabStop = true;
            this.trueRadioBtn.Text = "Ya";
            this.trueRadioBtn.UseVisualStyleBackColor = true;
            // 
            // falseRadioBtn
            // 
            this.falseRadioBtn.AutoSize = true;
            this.falseRadioBtn.Location = new System.Drawing.Point(512, 85);
            this.falseRadioBtn.Name = "falseRadioBtn";
            this.falseRadioBtn.Size = new System.Drawing.Size(52, 17);
            this.falseRadioBtn.TabIndex = 7;
            this.falseRadioBtn.TabStop = true;
            this.falseRadioBtn.Text = "Tidak";
            this.falseRadioBtn.UseVisualStyleBackColor = true;
            // 
            // proccedBtn
            // 
            this.proccedBtn.Location = new System.Drawing.Point(419, 108);
            this.proccedBtn.Name = "proccedBtn";
            this.proccedBtn.Size = new System.Drawing.Size(143, 23);
            this.proccedBtn.TabIndex = 8;
            this.proccedBtn.Text = "Pertanyaan Selanjutnya";
            this.proccedBtn.UseVisualStyleBackColor = true;
            this.proccedBtn.Click += new System.EventHandler(this.proccedBtn_Click);
            // 
            // questionTextBox
            // 
            this.questionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionTextBox.Location = new System.Drawing.Point(419, 12);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.ReadOnly = true;
            this.questionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.questionTextBox.Size = new System.Drawing.Size(158, 64);
            this.questionTextBox.TabIndex = 9;
            // 
            // resultTextBox
            // 
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTextBox.Location = new System.Drawing.Point(419, 150);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(158, 96);
            this.resultTextBox.TabIndex = 10;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(416, 134);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(34, 13);
            this.resultLabel.TabIndex = 11;
            this.resultLabel.Text = "Stats:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Disease List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(586, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Symptom List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(586, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(586, 223);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Stats";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(583, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Debug Tools:";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(583, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 64);
            this.label2.TabIndex = 17;
            this.label2.Text = "Info:\r\n- 0 = Unsassigned\r\n- 1 = Data is True\r\n- 2 = Data is False";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(692, 257);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.proccedBtn);
            this.Controls.Add(this.falseRadioBtn);
            this.Controls.Add(this.trueRadioBtn);
            this.Controls.Add(this.totalRuleTxtBox);
            this.Controls.Add(this.dataPLabel);
            this.Controls.Add(this.ruleTextBox);
            this.Controls.Add(this.datasetTextBox);
            this.Controls.Add(this.datasetBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Sistem Pakar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button datasetBtn;
        private System.Windows.Forms.TextBox datasetTextBox;
        private System.Windows.Forms.TextBox ruleTextBox;
        private System.Windows.Forms.Label dataPLabel;
        private System.Windows.Forms.TextBox totalRuleTxtBox;
        private System.Windows.Forms.RadioButton trueRadioBtn;
        private System.Windows.Forms.RadioButton falseRadioBtn;
        private System.Windows.Forms.Button proccedBtn;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

