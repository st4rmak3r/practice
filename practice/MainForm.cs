using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace AppPractice
{

    public partial class MainForm : Form
    {
        private string id;
        public MainForm()
        {
            InitializeComponent();
        }


        private void ExitButton_click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            dataGridMain.Enabled = false;
            string query = "SELECT name_company FROM company";
            System.Data.DataTable dt = Database.selectStatementNotParameters(query);
            try
            {
                var select = dt.Select();

                foreach (DataRow row in select)
                {
                    companyComboBox.Items.Add(row.ItemArray[0]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Company had total fail! " + exception.Message);
            }


        }

        private void companyComboBox_TextChanged(object sender, EventArgs e)
        {
            dataGridMain.Enabled = true;
            platoonComboBox.Text = "";
            unitComboBox.Text = "";
            platoonComboBox.Items.Clear();
            unitComboBox.Items.Clear();
            string query = "SELECT name_platoon FROM platoon WHERE id_companyFK = (SELECT id_company FROM company WHERE name_company = '" + companyComboBox.Text + "');";
            System.Data.DataTable dt = Database.selectStatementNotParameters(query);

            try
            {
                var select = dt.Select();

                foreach (DataRow row in select)
                {
                    platoonComboBox.Items.Add(row.ItemArray[0]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Platoon had total fail! " + exception.Message);
            }



            try
            {
                string sqlSelect = "SELECT DISTINCT soldier.id_soldier, soldier.name_soldier, soldier.document_soldier, commander, \r\nrank_army.name_rank_army\r\nFROM soldier\r\nJOIN soldier_list ON soldier.id_soldier = \r\nsoldier_list.id_soldierSL\r\nJOIN rank_army ON soldier_list.id_rank = rank_army.id_rank_army\r\nJOIN unit ON soldier_list.id_unit = unit.id_unit\r\nJOIN platoon ON unit.id_platoonFK = platoon.id_platoon\r\nJOIN company ON platoon.id_companyFK = company.id_company\r\nWHERE company.name_company = ('"
                + companyComboBox.Text + "') ORDER BY commander DESC;";
                dt.Clear();
                dataGridMain.AutoGenerateColumns = false;
                dt = Database.selectStatementNotParameters(sqlSelect);
                dataGridMain.DataSource = dt;
                dataGridMain.Columns["Column1"].DataPropertyName = "name_soldier";
                dataGridMain.Columns["Column6"].DataPropertyName = "id_soldier";
                dataGridMain.Columns["Column2"].DataPropertyName = "name_rank_army";
                dataGridMain.Columns["Column7"].DataPropertyName = "commander";

            }
            catch (Exception exc)
            {
                MessageBox.Show("Connection error!" + exc.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.UserClosing))
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void Pechat_Click(object sender, EventArgs e)
        {
            MySqlConnection con = Database.getConnection();

            string[] query;
            query = new string[12];

            query[0] = "SELECT name_soldier FROM soldier WHERE id_soldier =" + id + ";";
            query[1] = "SELECT distinct name_rank_army\r\nFROM soldier_list sl\r\nJOIN rank_army ra ON sl.id_rank = ra.id_rank_army\r\nWHERE sl.id_soldierSL = " + id + ";";
            query[2] = "SELECT telnumber_soldier from soldier where id_soldier = " + id + ";";
            query[3] = "SELECT adress_soldier from soldier where id_soldier =" + id + ";";
            query[4] = "SELECT shelflife_category_soldier FROM soldier WHERE id_soldier = " + id + ";";
            query[5] = "SELECT s.type_service FROM service s JOIN soldier sold ON sold.id_serviceFK = s.id_service WHERE sold.id_soldier = " + id + ";";
            query[6] = "SELECT historyofsoldier FROM history_soldier, soldier WHERE id_history_soldierFK = id_history_soldier AND id_soldier = " + id + ";";
            query[7] = "SELECT commander FROM soldier_list where id_soldierSL = " + id + ";";
            query[8] = "SELECT gender_soldier FROM soldier WHERE id_soldier = " + id + ";";
            query[9] = "SELECT s.date_start_service\r\nFROM service s\r\nJOIN soldier so ON s.id_service = so.id_serviceFK\r\nWHERE so.id_soldier = " + id + ";";
            query[10] = "SELECT s.date_end_service\r\nFROM service s\r\nJOIN soldier so ON s.id_service = so.id_serviceFK\r\nWHERE so.id_soldier = " + id + ";";
            query[11] = "SELECT dateofbirth_soldier from soldier where id_soldier = " + id + ";";


            for (int i = 0; i < query.Length; i++)
            {
                System.Data.DataTable dt2 = Database.selectStatementNotParameters(query[i]);
                query[i] = dt2.Rows[0].ItemArray[0].ToString();
            }

            object missing = Missing.Value;
            object filename = "C:\\Users\\st4rm\\Desktop\\AppPractice\\template.dotx";
            object fileNameSaveAs = "C:\\Users\\st4rm\\Desktop\\AppPractice\\Личные дела\\" + query[0];
            object fileFormat = WdSaveFormat.wdFormatDocumentDefault;
            object saveChanges = WdSaveOptions.wdDoNotSaveChanges;

            object imageFilePath = "C:\\Users\\st4rm\\Desktop\\AppPractice\\Фото\\" + query[0] + ".png"; // Путь к новому изображению

            object templatePath = "C:\\Users\\st4rm\\Desktop\\AppPractice\\template.dotx"; // Путь к вашему шаблону Word

            // Создаем объект приложения Word
            Word.Application wordApp = new Word.Application();

            try
            {
                // Открываем шаблон документа
                Word.Document doc = wordApp.Documents.Open(templatePath);

                if (query[7] == "True" || query[7] == "1")
                {
                    query[7] = "Командир";
                }
                else if (query[7] == "False" || query[7] == "0")
                {
                    query[7] = "Солдат";
                }

                for (int i = 9; i < query.Length; i++)
                {
                    DateTime datetime = DateTime.Parse(query[i]); // Парсинг строки в объект DateTime
                    query[i] = datetime.ToString("dd.MM.yyyy"); // Преобразование объекта DateTime в строку без времени
                }



                ReplaceWordStub("{fio}", query[0], doc);
                ReplaceWordStub("{rank}", query[1], doc);
                ReplaceWordStub("{telnumber}", query[2], doc);
                ReplaceWordStub("{adresssoldier}", query[3], doc);
                ReplaceWordStub("{shelflife_category}", query[4], doc);
                ReplaceWordStub("{servicetype}", query[5], doc);
                ReplaceWordStub("{opis}", query[6], doc);
                ReplaceWordStub("{commander}", query[7], doc);
                ReplaceWordStub("{gendersoldier}", query[8], doc);
                ReplaceWordStub("{dateofstartservice}", query[9], doc);
                ReplaceWordStub("{dateofendtservice}", query[10], doc);
                ReplaceWordStub("{dateofbirth_soldier}", query[11], doc);



                // Сохраняем результирующий документ
                doc.SaveAs(ref fileNameSaveAs, ref fileFormat);

                // Закрываем документ
                doc.Close(ref saveChanges, ref missing, ref missing);

                MessageBox.Show("Всё прошло успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                // Закрываем приложение Word
                wordApp.Quit();
            }
        }

        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }


        private void platoonComboBox_TextChanged(object sender, EventArgs e)
        {
            unitComboBox.Text = "";
            unitComboBox.Items.Clear();
            string query = "SELECT name_unit FROM unit WHERE id_platoonFK = (SELECT id_platoon FROM platoon WHERE name_platoon = '" +
            platoonComboBox.Text + "');";
            System.Data.DataTable dt = Database.selectStatementNotParameters(query);

            try
            {
                var select = dt.Select();

                foreach (DataRow row in select)
                {
                    unitComboBox.Items.Add(row.ItemArray[0]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unit had total fail! " + exception.Message);
            }


            try
            {
                string sqlSelect = "SELECT commander, s.id_soldier, s.name_soldier, s.document_soldier, r.name_rank_army\r\nFROM soldier s\r\nJOIN soldier_list sl ON s.id_soldier = sl.id_soldierSL\r\nJOIN rank_army r ON sl.id_rank = r.id_rank_army\r\nJOIN unit u ON sl.id_unit = u.id_unit\r\nJOIN platoon p ON u.id_platoonFK = p.id_platoon\r\nJOIN company c ON p.id_companyFK = c.id_company\r\nWHERE c.name_company = '" + companyComboBox.Text + "'  AND p.name_platoon = '"
                + platoonComboBox.Text + "' ORDER BY commander DESC;";
                dt.Clear();
                dataGridMain.AutoGenerateColumns = false;
                dt = Database.selectStatementNotParameters(sqlSelect);
                dataGridMain.DataSource = dt;
                dataGridMain.Columns["Column1"].DataPropertyName = "name_soldier";
                dataGridMain.Columns["Column6"].DataPropertyName = "id_soldier";
                dataGridMain.Columns["Column2"].DataPropertyName = "name_rank_army";
                dataGridMain.Columns["Column7"].DataPropertyName = "commander";

            }
            catch (Exception exc)
            {
                MessageBox.Show("Connection error!" + exc.Message, "Error", MessageBoxButtons.OK);
            }




        }

        private void unitComboBox_TextChanged(object sender, EventArgs e)
        {

            platoonComboBox.Items.Clear();
            string query = "SELECT name_platoon FROM platoon WHERE id_companyFK = (SELECT id_company FROM company WHERE name_company = '" +
            companyComboBox.Text + "')";
            System.Data.DataTable dt = Database.selectStatementNotParameters(query);

            try
            {
                var select = dt.Select();

                foreach (DataRow row in select)
                {
                    platoonComboBox.Items.Add(row.ItemArray[0]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Platoon had total fail! " + exception.Message);
            }



            try
            {
                string sqlSelect = "SELECT commander, s.id_soldier, s.name_soldier, s.document_soldier, r.name_rank_army\r\nFROM soldier s\r\n" + "" +
                "JOIN soldier_list sl ON s.id_soldier = sl.id_soldierSL\r\nJOIN rank_army r ON sl.id_rank = r.id_rank_army\r\nJOIN unit u ON " + "" +
                "sl.id_unit = u.id_unit\r\nJOIN platoon p ON u.id_platoonFK = p.id_platoon\r\nJOIN company c ON p.id_companyFK = c.id_company\r\nWHERE " + "" +
                "c.name_company = '" + companyComboBox.Text + "' AND p.name_platoon = '" + platoonComboBox.Text + "' AND u.name_unit = '" + unitComboBox.Text + "' ORDER BY commander DESC;;";
                dt.Clear();
                dataGridMain.AutoGenerateColumns = false;
                dt = Database.selectStatementNotParameters(sqlSelect);
                dataGridMain.DataSource = dt;
                dataGridMain.Columns["Column1"].DataPropertyName = "name_soldier";
                dataGridMain.Columns["Column6"].DataPropertyName = "id_soldier";
                dataGridMain.Columns["Column2"].DataPropertyName = "name_rank_army";
                dataGridMain.Columns["Column7"].DataPropertyName = "commander";

            }
            catch (Exception exc)
            {
                MessageBox.Show("Connection error!" + exc.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form TechniqueForm = new TechniqueForm();
            TechniqueForm.Show();
            this.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form RedactorForm = new RedactorForm();
            RedactorForm.Show();
            this.Visible = false;
        }

        private void RedactorFormBut_Click(object sender, EventArgs e)
        {
            Form RedactorForm = new RedactorForm();
            this.Visible = false;
            RedactorForm.Show();


        }
        private string getSelectQuery(string query, ComboBox companyName, ComboBox platoonName, ComboBox unitName)
        {
            if (companyName.Text != "")
            {

                query = query + " and (company.name_company = (\'" + companyName.Text + "\'))";
            }
            if (platoonName.Text != "")
            {
                query = query + " and (platoon.name_platoon = \'" + platoonName.Text + "\')";
            }
            if (unitName.Text != "")
            {
                query = query + " and (unit.name_unit = \'" + unitName.Text + "\')";
            }
            return query;
        }




        private void checkBoxCommander_CheckedChanged(object sender, EventArgs e)
        {

            string query = "";

            if (checkBoxCommander.Checked)
            {
                query = "SELECT soldier.name_soldier, soldier.id_soldier, soldier_list.commander, rank_army.name_rank_army\r\nFROM soldier, company, soldier_list\r\nJOIN unit ON soldier_list.id_unit = unit.id_unit\r\nJOIN platoon ON unit.id_platoonFK = platoon.id_platoon\r\nJOIN rank_army ON soldier_list.id_rank = rank_army.id_rank_army\r\nWHERE (company.id_company = platoon.id_companyFK) \r\n  AND (soldier_list.id_soldierSL = soldier.id_soldier) \r\n  AND (soldier_list.commander = TRUE)";
            }
            else if (!checkBoxCommander.Checked)
            {
                query = "SELECT soldier.id_soldier, soldier.name_soldier, soldier_list.id_soldierSL, soldier_list.commander, rank_army.name_rank_army\r\nFROM soldier, company, soldier_list\r\nJOIN unit ON soldier_list.id_unit = unit.id_unit\r\nJOIN platoon ON unit.id_platoonFK = platoon.id_platoon\r\nJOIN rank_army ON soldier_list.id_rank = rank_army.id_rank_army\r\nWHERE (company.id_company = platoon.id_companyFK) \r\n  AND (soldier_list.id_soldierSL = soldier.id_soldier) ";

            }
            string sqlSelect = getSelectQuery(query, companyComboBox, platoonComboBox, unitComboBox);
            sqlSelect = sqlSelect + "ORDER BY commander DESC";
            System.Data.DataTable dt2 = Database.selectStatementNotParameters(sqlSelect);
            try
            {
                // Очистка данных из DataGrid
                dataGridMain.DataSource = null;
                dataGridMain.AutoGenerateColumns = false;
                dataGridMain.DataSource = dt2;

                dataGridMain.Columns["Column1"].DataPropertyName = "name_soldier";
                dataGridMain.Columns["Column6"].DataPropertyName = "id_soldier";
                dataGridMain.Columns["Column2"].DataPropertyName = "name_rank_army";
                dataGridMain.Columns["Column7"].DataPropertyName = "commander";

            }

            catch (Exception exc)
            { MessageBox.Show("Connection error!" + exc.Message, "Error", MessageBoxButtons.OK); }
        }


        private void dataGridMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridMain.Columns["Column3"].Index && e.RowIndex >= 0)
            {
                id = dataGridMain.Rows[e.RowIndex].Cells[1].Value.ToString();
                Form RedactorForm = new RedactorForm(id);
                RedactorForm.Show();
                this.Visible = false;

            }
            else if (e.ColumnIndex == dataGridMain.Columns["Column4"].Index && e.RowIndex >= 0)
            {
                string[] query;
                query = new string[2];
                query[0] = "DELETE from soldier where id_soldier = " + dataGridMain.Rows[e.RowIndex].Cells[1].Value.ToString() + "";
                query[1] = $"DELETE from history_soldier WHERE id_history_soldier = " + dataGridMain.Rows[e.RowIndex].Cells[1].Value.ToString() + "";
                dataGridMain.Rows.RemoveAt(e.RowIndex);

                for (int i = 0; i < query.Length; i++)
                {
                    Database.databaseDataQueryUpdateInsertDelete(query[i]);
                }
                MessageBox.Show("Удаление прошло успешно!");
            }
            else if (e.ColumnIndex == dataGridMain.Columns["Column5"].Index && e.RowIndex >= 0)
            {
                id = dataGridMain.Rows[e.RowIndex].Cells[1].Value.ToString();
                Pechat_Click(sender, e);

            }

            if (dataGridMain != null)
            {

                dataGridMain.Enabled = true;

            }
            else
            {

                dataGridMain.Enabled = false;

            }
        }
    }
}

