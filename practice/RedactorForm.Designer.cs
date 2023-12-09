namespace AppPractice
{
    partial class RedactorForm
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
            this.platoonSoldierComboBox = new System.Windows.Forms.ComboBox();
            this.unitSoldierComboBox = new System.Windows.Forms.ComboBox();
            this.serviceSoldierComboBox = new System.Windows.Forms.ComboBox();
            this.companySoldierComboBox = new System.Windows.Forms.ComboBox();
            this.rankSoldierComboBox = new System.Windows.Forms.ComboBox();
            this.ShelfComboBox = new System.Windows.Forms.ComboBox();
            this.genderSoldierComboBox = new System.Windows.Forms.ComboBox();
            this.SaveBut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fullnameSoldierBox = new System.Windows.Forms.TextBox();
            this.telephoneSoldierBox = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dateOfBirthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateServiceDatePicker = new System.Windows.Forms.DateTimePicker();
            this.documentSoldierBox = new System.Windows.Forms.TextBox();
            this.addressSoldierBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.unitsol = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.MainMenuBut = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.soldierTextBoxAdd = new System.Windows.Forms.TextBox();
            this.dateStartMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // platoonSoldierComboBox
            // 
            this.platoonSoldierComboBox.FormattingEnabled = true;
            this.platoonSoldierComboBox.Location = new System.Drawing.Point(339, 380);
            this.platoonSoldierComboBox.Name = "platoonSoldierComboBox";
            this.platoonSoldierComboBox.Size = new System.Drawing.Size(185, 24);
            this.platoonSoldierComboBox.TabIndex = 4;
            this.platoonSoldierComboBox.SelectedIndexChanged += new System.EventHandler(this.platoonSoldierComboBox_SelectedIndexChanged);
            // 
            // unitSoldierComboBox
            // 
            this.unitSoldierComboBox.FormattingEnabled = true;
            this.unitSoldierComboBox.Location = new System.Drawing.Point(88, 375);
            this.unitSoldierComboBox.Name = "unitSoldierComboBox";
            this.unitSoldierComboBox.Size = new System.Drawing.Size(187, 24);
            this.unitSoldierComboBox.TabIndex = 5;
            // 
            // serviceSoldierComboBox
            // 
            this.serviceSoldierComboBox.FormattingEnabled = true;
            this.serviceSoldierComboBox.Location = new System.Drawing.Point(88, 261);
            this.serviceSoldierComboBox.Name = "serviceSoldierComboBox";
            this.serviceSoldierComboBox.Size = new System.Drawing.Size(187, 24);
            this.serviceSoldierComboBox.TabIndex = 6;
            this.serviceSoldierComboBox.SelectedIndexChanged += new System.EventHandler(this.serviceComboBoxAdd_SelectedIndexChanged);
            // 
            // companySoldierComboBox
            // 
            this.companySoldierComboBox.FormattingEnabled = true;
            this.companySoldierComboBox.Location = new System.Drawing.Point(339, 256);
            this.companySoldierComboBox.Name = "companySoldierComboBox";
            this.companySoldierComboBox.Size = new System.Drawing.Size(185, 24);
            this.companySoldierComboBox.TabIndex = 7;
            this.companySoldierComboBox.SelectedIndexChanged += new System.EventHandler(this.companyComboBoxAdd_SelectedIndexChanged);
            // 
            // rankSoldierComboBox
            // 
            this.rankSoldierComboBox.FormattingEnabled = true;
            this.rankSoldierComboBox.Location = new System.Drawing.Point(339, 317);
            this.rankSoldierComboBox.Name = "rankSoldierComboBox";
            this.rankSoldierComboBox.Size = new System.Drawing.Size(185, 24);
            this.rankSoldierComboBox.TabIndex = 8;
            // 
            // ShelfComboBox
            // 
            this.ShelfComboBox.FormattingEnabled = true;
            this.ShelfComboBox.Location = new System.Drawing.Point(90, 429);
            this.ShelfComboBox.Name = "ShelfComboBox";
            this.ShelfComboBox.Size = new System.Drawing.Size(185, 24);
            this.ShelfComboBox.TabIndex = 11;
            // 
            // genderSoldierComboBox
            // 
            this.genderSoldierComboBox.FormattingEnabled = true;
            this.genderSoldierComboBox.Location = new System.Drawing.Point(90, 88);
            this.genderSoldierComboBox.Name = "genderSoldierComboBox";
            this.genderSoldierComboBox.Size = new System.Drawing.Size(187, 24);
            this.genderSoldierComboBox.TabIndex = 12;
            // 
            // SaveBut
            // 
            this.SaveBut.Location = new System.Drawing.Point(830, 304);
            this.SaveBut.Name = "SaveBut";
            this.SaveBut.Size = new System.Drawing.Size(108, 35);
            this.SaveBut.TabIndex = 15;
            this.SaveBut.Text = "Вход";
            this.SaveBut.UseVisualStyleBackColor = true;
            this.SaveBut.Click += new System.EventHandler(this.SaveBut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(742, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 35);
            this.button2.TabIndex = 17;
            this.button2.Text = "Вход";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // fullnameSoldierBox
            // 
            this.fullnameSoldierBox.Location = new System.Drawing.Point(90, 40);
            this.fullnameSoldierBox.Name = "fullnameSoldierBox";
            this.fullnameSoldierBox.Size = new System.Drawing.Size(185, 22);
            this.fullnameSoldierBox.TabIndex = 18;
            this.fullnameSoldierBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fullnameSoldierBox_KeyPress);
            // 
            // telephoneSoldierBox
            // 
            this.telephoneSoldierBox.Location = new System.Drawing.Point(88, 317);
            this.telephoneSoldierBox.Name = "telephoneSoldierBox";
            this.telephoneSoldierBox.Size = new System.Drawing.Size(185, 22);
            this.telephoneSoldierBox.TabIndex = 19;
            this.telephoneSoldierBox.Enter += new System.EventHandler(this.telephoneSoldierBox_Enter_1);
            this.telephoneSoldierBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTelNumAdd_KeyPress);
            this.telephoneSoldierBox.Leave += new System.EventHandler(this.telephoneSoldierBox_Leave_1);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(660, 92);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 20);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.updateCommanderCheckBox);
            // 
            // dateOfBirthDatePicker
            // 
            this.dateOfBirthDatePicker.Location = new System.Drawing.Point(948, 208);
            this.dateOfBirthDatePicker.Name = "dateOfBirthDatePicker";
            this.dateOfBirthDatePicker.Size = new System.Drawing.Size(200, 22);
            this.dateOfBirthDatePicker.TabIndex = 21;
            // 
            // endDateServiceDatePicker
            // 
            this.endDateServiceDatePicker.Location = new System.Drawing.Point(948, 254);
            this.endDateServiceDatePicker.Name = "endDateServiceDatePicker";
            this.endDateServiceDatePicker.Size = new System.Drawing.Size(200, 22);
            this.endDateServiceDatePicker.TabIndex = 22;
            // 
            // documentSoldierBox
            // 
            this.documentSoldierBox.Location = new System.Drawing.Point(90, 147);
            this.documentSoldierBox.Name = "documentSoldierBox";
            this.documentSoldierBox.Size = new System.Drawing.Size(185, 22);
            this.documentSoldierBox.TabIndex = 23;
            this.documentSoldierBox.Enter += new System.EventHandler(this.documentSoldierBox_Enter);
            this.documentSoldierBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.documentSoldierBox_KeyPress);
            this.documentSoldierBox.Leave += new System.EventHandler(this.documentSoldierBox_Leave);
            // 
            // addressSoldierBox
            // 
            this.addressSoldierBox.Location = new System.Drawing.Point(88, 196);
            this.addressSoldierBox.Name = "addressSoldierBox";
            this.addressSoldierBox.Size = new System.Drawing.Size(187, 22);
            this.addressSoldierBox.TabIndex = 24;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(665, 40);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "телефог";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "документ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "служба";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "пол";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "адрес";
            // 
            // unitsol
            // 
            this.unitsol.AutoSize = true;
            this.unitsol.Location = new System.Drawing.Point(15, 375);
            this.unitsol.Name = "unitsol";
            this.unitsol.Size = new System.Drawing.Size(45, 16);
            this.unitsol.TabIndex = 35;
            this.unitsol.Text = "unitsol";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 437);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "shelsol";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(336, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "company";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(336, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 16);
            this.label10.TabIndex = 38;
            this.label10.Text = "ranksol";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(336, 361);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 16);
            this.label12.TabIndex = 40;
            this.label12.Text = "platoon";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(300, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 20);
            this.checkBox1.TabIndex = 41;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainMenuBut
            // 
            this.MainMenuBut.Location = new System.Drawing.Point(591, 418);
            this.MainMenuBut.Name = "MainMenuBut";
            this.MainMenuBut.Size = new System.Drawing.Size(108, 35);
            this.MainMenuBut.TabIndex = 42;
            this.MainMenuBut.Text = "Вход";
            this.MainMenuBut.UseVisualStyleBackColor = true;
            this.MainMenuBut.Click += new System.EventHandler(this.Mainmenubut_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1110, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 35);
            this.button4.TabIndex = 43;
            this.button4.Text = "Вход";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.calculationDateOfEnd);
            // 
            // soldierTextBoxAdd
            // 
            this.soldierTextBoxAdd.Location = new System.Drawing.Point(1118, 110);
            this.soldierTextBoxAdd.Name = "soldierTextBoxAdd";
            this.soldierTextBoxAdd.Size = new System.Drawing.Size(100, 22);
            this.soldierTextBoxAdd.TabIndex = 44;
            // 
            // dateStartMaskedTextBox
            // 
            this.dateStartMaskedTextBox.Location = new System.Drawing.Point(1012, 110);
            this.dateStartMaskedTextBox.Name = "dateStartMaskedTextBox";
            this.dateStartMaskedTextBox.Size = new System.Drawing.Size(100, 22);
            this.dateStartMaskedTextBox.TabIndex = 46;
            // 
            // RedactorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 485);
            this.Controls.Add(this.dateStartMaskedTextBox);
            this.Controls.Add(this.soldierTextBoxAdd);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.MainMenuBut);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.unitsol);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.addressSoldierBox);
            this.Controls.Add(this.documentSoldierBox);
            this.Controls.Add(this.endDateServiceDatePicker);
            this.Controls.Add(this.dateOfBirthDatePicker);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.telephoneSoldierBox);
            this.Controls.Add(this.fullnameSoldierBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SaveBut);
            this.Controls.Add(this.genderSoldierComboBox);
            this.Controls.Add(this.ShelfComboBox);
            this.Controls.Add(this.rankSoldierComboBox);
            this.Controls.Add(this.companySoldierComboBox);
            this.Controls.Add(this.serviceSoldierComboBox);
            this.Controls.Add(this.unitSoldierComboBox);
            this.Controls.Add(this.platoonSoldierComboBox);
            this.Name = "RedactorForm";
            this.Text = "RedactorForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RedactorForm_FormClosed);
            this.Load += new System.EventHandler(this.RedactorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox platoonSoldierComboBox;
        private System.Windows.Forms.ComboBox unitSoldierComboBox;
        private System.Windows.Forms.ComboBox serviceSoldierComboBox;
        private System.Windows.Forms.ComboBox companySoldierComboBox;
        private System.Windows.Forms.ComboBox rankSoldierComboBox;
        private System.Windows.Forms.ComboBox ShelfComboBox;
        private System.Windows.Forms.ComboBox genderSoldierComboBox;
        private System.Windows.Forms.Button SaveBut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox fullnameSoldierBox;
        private System.Windows.Forms.TextBox telephoneSoldierBox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DateTimePicker dateOfBirthDatePicker;
        private System.Windows.Forms.DateTimePicker endDateServiceDatePicker;
        private System.Windows.Forms.TextBox documentSoldierBox;
        private System.Windows.Forms.TextBox addressSoldierBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label unitsol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button MainMenuBut;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox soldierTextBoxAdd;
        private System.Windows.Forms.MaskedTextBox dateStartMaskedTextBox;
    }
}