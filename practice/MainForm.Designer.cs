namespace AppPractice
{
    partial class MainForm
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
            this.platoonComboBox = new System.Windows.Forms.ComboBox();
            this.companyComboBox = new System.Windows.Forms.ComboBox();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Pechat = new System.Windows.Forms.Button();
            this.checkBoxCommander = new System.Windows.Forms.CheckBox();
            this.dataGridMain = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).BeginInit();
            this.SuspendLayout();
            // 
            // platoonComboBox
            // 
            this.platoonComboBox.FormattingEnabled = true;
            this.platoonComboBox.Location = new System.Drawing.Point(34, 163);
            this.platoonComboBox.Name = "platoonComboBox";
            this.platoonComboBox.Size = new System.Drawing.Size(121, 24);
            this.platoonComboBox.TabIndex = 0;
            this.platoonComboBox.TextChanged += new System.EventHandler(this.platoonComboBox_TextChanged);
            // 
            // companyComboBox
            // 
            this.companyComboBox.FormattingEnabled = true;
            this.companyComboBox.Location = new System.Drawing.Point(34, 62);
            this.companyComboBox.Name = "companyComboBox";
            this.companyComboBox.Size = new System.Drawing.Size(121, 24);
            this.companyComboBox.TabIndex = 1;
            this.companyComboBox.TextChanged += new System.EventHandler(this.companyComboBox_TextChanged);
            // 
            // unitComboBox
            // 
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Location = new System.Drawing.Point(34, 235);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(121, 24);
            this.unitComboBox.TabIndex = 2;
            this.unitComboBox.TextChanged += new System.EventHandler(this.unitComboBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "О технике";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RedactorFormBut_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(20, 362);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 43);
            this.button3.TabIndex = 5;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button2_Click);
            // 
            // Pechat
            // 
            this.Pechat.Location = new System.Drawing.Point(162, 350);
            this.Pechat.Name = "Pechat";
            this.Pechat.Size = new System.Drawing.Size(99, 42);
            this.Pechat.TabIndex = 6;
            this.Pechat.Text = "button4";
            this.Pechat.UseVisualStyleBackColor = true;
            this.Pechat.Click += new System.EventHandler(this.Pechat_Click);
            // 
            // checkBoxCommander
            // 
            this.checkBoxCommander.AutoSize = true;
            this.checkBoxCommander.Location = new System.Drawing.Point(44, 273);
            this.checkBoxCommander.Name = "checkBoxCommander";
            this.checkBoxCommander.Size = new System.Drawing.Size(103, 20);
            this.checkBoxCommander.TabIndex = 7;
            this.checkBoxCommander.Text = "Командиры";
            this.checkBoxCommander.UseVisualStyleBackColor = true;
            this.checkBoxCommander.CheckedChanged += new System.EventHandler(this.checkBoxCommander_CheckedChanged);
            // 
            // dataGridMain
            // 
            this.dataGridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridMain.Location = new System.Drawing.Point(321, 94);
            this.dataGridMain.Name = "dataGridMain";
            this.dataGridMain.RowHeadersWidth = 51;
            this.dataGridMain.RowTemplate.Height = 24;
            this.dataGridMain.Size = new System.Drawing.Size(1005, 550);
            this.dataGridMain.TabIndex = 8;
            this.dataGridMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMain_CellContentClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1003, 760);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "ExitButton";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ExitButton_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Выберите роту :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Выберите взвод :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Выберите отделение :";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Командир";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ФИО";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ранг";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Редактировать";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Удалить";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Печать";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1818, 823);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridMain);
            this.Controls.Add(this.checkBoxCommander);
            this.Controls.Add(this.Pechat);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.unitComboBox);
            this.Controls.Add(this.companyComboBox);
            this.Controls.Add(this.platoonComboBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox platoonComboBox;
        private System.Windows.Forms.ComboBox companyComboBox;
        private System.Windows.Forms.ComboBox unitComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Pechat;
        private System.Windows.Forms.CheckBox checkBoxCommander;
        private System.Windows.Forms.DataGridView dataGridMain;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}