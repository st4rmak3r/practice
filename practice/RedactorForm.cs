
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace AppPractice
{

    public partial class RedactorForm : Form
    {
        private string id;
        private bool isUpdate;
        public RedactorForm(string id)
        {
            InitializeComponent();
            this.id = id;
            isUpdate = true;

        }

        public RedactorForm()
        {
            InitializeComponent();
            isUpdate = false;
        }

        private void Mainmenubut_Click(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Show();
            this.Dispose();
        }



        private void RedactorForm_Load(object sender, EventArgs e)
        {
            telephoneSoldierBox.Text = "89XXXXXXXXX"; // Восстанавливаем текст-подсказку
            telephoneSoldierBox.ForeColor = SystemColors.GrayText; // Устанавливаем серый цвет текста
            documentSoldierBox.Text = "AF1234567"; // Восстанавливаем текст-подсказку
            documentSoldierBox.ForeColor = SystemColors.GrayText; // Устанавливаем серый цвет текста

            // Инициализация начальных combobox`ов
            SaveBut.Enabled = false;
            platoonSoldierComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            unitSoldierComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            string[] query;
            query = new string[5];
            query[0] = "SELECT name_rank_army FROM rank_army order by id_rank_army desc";
            query[1] = "SELECT type_service FROM service";
            query[2] = "SELECT name_company FROM company";
            query[3] = "SELECT DISTINCT gender_soldier FROM soldier";
            query[4] = "SELECT DISTINCT shelflife_category_soldier FROM soldier";

            List<ComboBox> ComboBoxList = new List<ComboBox>
            {
                rankSoldierComboBox,
                serviceSoldierComboBox,
                companySoldierComboBox,
                genderSoldierComboBox,
                ShelfComboBox
            };

            for (int i = 0; i < query.Length; i++)
            {
                ComboBoxList[i].DropDownStyle = ComboBoxStyle.DropDownList;

                DataTable dt = Database.selectStatementNotParameters(query[i]);
                try
                {
                    var select = dt.Select();
                    foreach (DataRow row in select)
                    {
                        string item = row.ItemArray[0].ToString();
                        if (!ComboBoxList[i].Items.Contains(item))
                            ComboBoxList[i].Items.Add(item);

                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Auto field had total fail! " + exception.Message);
                }
            }

            // Привязка по id soldier
            if (isUpdate)
            {

                string date_start_service = "SELECT s.date_start_service\r\nFROM service s\r\nJOIN soldier so ON s.id_service = so.id_serviceFK\r\nWHERE so.id_soldier = " + id + ";";
                DataTable dataTableStartService = Database.selectStatementNotParameters(date_start_service);
                dateStartMaskedTextBox.Text = dataTableStartService.Rows[0].ItemArray[0].ToString();

                string[] startQueryInitialize;
                startQueryInitialize = new string[5];

                List<TextBox> startTextBox = new List<TextBox>
                {
                    fullnameSoldierBox,
                    telephoneSoldierBox,
                    documentSoldierBox,
                    addressSoldierBox,
                    soldierTextBoxAdd
                };

                startQueryInitialize[0] = "SELECT name_soldier from soldier where id_soldier = " + id + ";";
                startQueryInitialize[1] = "SELECT telnumber_soldier from soldier where id_soldier = " + id + ";";
                startQueryInitialize[2] = "SELECT document_soldier from soldier where id_soldier =" + id + ";";
                startQueryInitialize[3] = "SELECT adress_soldier from soldier where id_soldier =" + id + ";";
                startQueryInitialize[4] = "SELECT historyofsoldier FROM history_soldier, soldier WHERE id_history_soldierFK = id_history_soldier AND id_soldier = " + id + ";";

                for (int i = 0; i < startQueryInitialize.Length; i++)
                {

                    DataTable startInitialize = Database.selectStatementNotParameters(startQueryInitialize[i]);
                    startTextBox[i].Text = startInitialize.Rows[0].ItemArray[0].ToString();
                    if (startTextBox[i].Name == fullnameSoldierBox.Name)
                    {
                        string[] words = startInitialize.Rows[0].ItemArray[0].ToString().Split(' ');
                        if (words.Length <= 2)
                        {
                            checkBox2.Checked = true;
                        }
                    }
                }

                List<DateTimePicker> dateTimePickers = new List<DateTimePicker>()
                {
                    dateOfBirthDatePicker, endDateServiceDatePicker
                };

                List<string> dateQueries = new List<string>()
                {
                    "SELECT dateofbirth_soldier from soldier where id_soldier = " + id + ";",
                    "SELECT s.date_end_service\r\nFROM service s\r\nJOIN soldier so ON s.id_service = so.id_serviceFK\r\nWHERE so.id_soldier = " + id + ";"
                };

                for (int i = 0; i < dateQueries.Count; i++)
                {
                    DataTable resultQuery = Database.selectStatementNotParameters(dateQueries[i]);
                    DateTime parseDate = DateTime.Parse(resultQuery.Rows[0].ItemArray[0].ToString());
                    dateTimePickers[i].Value = parseDate;
                }

                string checkBoxQuery = $"SELECT commander FROM soldier_list WHERE id_soldierSL = {id}";
                DataTable resultCommander = Database.selectStatementNotParameters(checkBoxQuery);
                checkBox1.Checked = Convert.ToBoolean(resultCommander.Rows[0].ItemArray[0]);

                List<ComboBox> soldierComboBoxes = new List<ComboBox>
                {
                    genderSoldierComboBox,
                    ShelfComboBox,
                    rankSoldierComboBox,
                    serviceSoldierComboBox,
                    companySoldierComboBox,
                    platoonSoldierComboBox,
                    unitSoldierComboBox,
                    rankSoldierComboBox
                };

                string[] fieldSoldierWithID;
                fieldSoldierWithID = new string[8];
                fieldSoldierWithID[0] = $"SELECT gender_soldier FROM soldier WHERE id_soldier = {id};";
                fieldSoldierWithID[1] = $"SELECT shelflife_category_soldier FROM soldier WHERE id_soldier = {id};";
                fieldSoldierWithID[2] = $"SELECT distinct name_rank_army\r\nFROM soldier_list sl\r\nJOIN rank_army ra ON sl.id_rank = ra.id_rank_army\r\nWHERE sl.id_soldierSL = {id};";
                fieldSoldierWithID[3] = $"SELECT s.type_service FROM service s JOIN soldier sold ON sold.id_serviceFK = s.id_service WHERE sold.id_soldier = {id};";
                fieldSoldierWithID[4] = $"SELECT c.name_company FROM company c JOIN battalion b ON c.id_battalionFK = b.id_battalion JOIN platoon p ON p.id_companyFK = c.id_company JOIN unit u ON u.id_platoonFK = p.id_platoon JOIN soldier_list sl ON sl.id_unit = u.id_unit WHERE sl.id_soldierSL = {id};";
                fieldSoldierWithID[5] = $"SELECT p.name_platoon FROM platoon p JOIN unit u ON u.id_platoonFK = p.id_platoon JOIN soldier_list sl ON sl.id_unit = u.id_unit WHERE sl.id_soldierSL = {id};";
                fieldSoldierWithID[6] = $"SELECT u.name_unit FROM unit u JOIN platoon p ON u.id_platoonFK = p.id_platoon JOIN company c ON p.id_companyFK = c.id_company JOIN soldier_list sl ON sl.id_unit = u.id_unit WHERE sl.id_soldierSL = {id};";
                fieldSoldierWithID[7] = $"SELECT name_rank_army from rank_army, soldier_list, soldier where (id_rank_army = id_rank) and (id_soldier = id_soldierSL) and (id_soldier = {id});";

                for (int i = 0; i < fieldSoldierWithID.Length; i++)
                {
                    DataTable queryDataTable = Database.selectStatementNotParameters(fieldSoldierWithID[i]);

                    try
                    {
                        if (soldierComboBoxes[i].Name == platoonSoldierComboBox.Name)
                        {

                            string queryPlatoon = $"SELECT name_platoon FROM platoon, company WHERE (id_platoon = id_companyFK) and (name_company = '{companySoldierComboBox.Text}')";
                            DataTable dataTable = Database.selectStatementNotParameters(queryPlatoon);
                            soldierComboBoxes[i].Text = queryDataTable.Rows[0].ItemArray[0].ToString();

                        }
                        else if (soldierComboBoxes[i].Name == unitSoldierComboBox.Name)
                        {
                            string queryUnit = $"SELECT name_unit FROM unit, platoon WHERE (id_unit = id_platoonFK) and (name_platoon = '{platoonSoldierComboBox.Text}')";
                            DataTable dataTable = Database.selectStatementNotParameters(queryUnit);
                            soldierComboBoxes[i].Text = queryDataTable.Rows[0].ItemArray[0].ToString();
                        }
                        else if (soldierComboBoxes[i].Name == rankSoldierComboBox.Name)
                        {

                            soldierComboBoxes[i].Text = queryDataTable.Rows[0].ItemArray[0].ToString();
                        }
                        else
                        {

                            soldierComboBoxes[i].Text = queryDataTable.Rows[0].ItemArray[0].ToString();
                        }

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Platoon had total fail! " + exception.Message);
                    }
                }
                if (serviceSoldierComboBox.Text == "Срочная")
                {
                    button1.Enabled = false;
                    textBox3.Enabled = false;
                }
                else if (serviceSoldierComboBox.Text != "Срочная")
                {
                    button1.Enabled = true;
                    textBox3.Enabled = true;
                }
            }
            else
            {
                SaveBut.Text = "Добавить";
            }
        }



        private void companyComboBoxAdd_SelectedIndexChanged(object sender, EventArgs e)
        {

            platoonSoldierComboBox.Items.Clear();
            string query = "SELECT name_platoon FROM platoon WHERE id_companyFK = (SELECT id_company FROM company WHERE name_company = '" +
            companySoldierComboBox.Text + "')";
            DataTable dt = Database.selectStatementNotParameters(query);

            try
            {
                var select = dt.Select();

                foreach (DataRow row in select)
                {
                    platoonSoldierComboBox.Items.Add(row.ItemArray[0]);
                }
                unitSoldierComboBox.Items.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Platoon had total fail! " + exception.Message);
            }
        }

        private void platoonSoldierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            unitSoldierComboBox.Items.Clear();
            string query = $"select name_unit FROM unit, platoon WHERE (id_platoon = id_platoonFK) and (name_platoon = '{platoonSoldierComboBox.Text}')";
            DataTable dt = Database.selectStatementNotParameters(query);

            try
            {
                var select = dt.Select();

                foreach (DataRow row in select)
                {
                    unitSoldierComboBox.Items.Add(row.ItemArray[0]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unit had total fail! " + exception.Message);
            }
        }

        private void RedactorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Закрыть проект (выход из приложения)
                System.Windows.Forms.Application.Exit();
            }
        }


        private bool AreTextBoxesEmpty(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    // Поле пустое или не содержит символов
                    return true;
                }
            }

            // Все поля содержат текст
            return false;
        }

        private bool AreComboBoxesValid(params ComboBox[] comboBoxes)
        {
            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox.SelectedItem == null || comboBox.SelectedItem.ToString() == "")
                {
                    // В комбинированном поле не выбран элемент или поле пустое
                    return false;
                }
            }

            // Все комбинированные поля содержат выбранный элемент
            return true;
        }

        private bool HasThreeWords(string text)
        {
            string[] words = text.Split(' ');

            if (checkBox2.Checked)
            {
                return words.Length == 2;
            }
            else
            {
                return words.Length >= 3;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            string text = fullnameSoldierBox.Text.Trim();



            if (HasThreeWords(text))
            {


            }
            else
            {
                if (checkBox2.Checked)
                {
                    // Вывести ошибку для случая checkbox2.Checked == true
                    MessageBox.Show("Ошибка! ФИ должен содержать два слова, разделенных пробелами.");
                }
                else
                {
                    // Вывести ошибку для случая checkbox2.Checked == false
                    MessageBox.Show("Ошибка! ФИО должен содержать три или более слов, разделенных пробелами.");
                }
            }

            if (AreTextBoxesEmpty(addressSoldierBox, documentSoldierBox, fullnameSoldierBox, telephoneSoldierBox))
            {

                DialogResult result = MessageBox.Show("Введите значения во все поля.\nВы хотите узнать где нужно исправить ввод?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Пользователь выбрал "Да"



                    int minLength = 11;

                    if (telephoneSoldierBox.Text.Length < minLength)
                    {
                        MessageBox.Show("Минимальное количество символов в номере телефона: " + minLength);
                    }

                    if (documentSoldierBox.Text.Length < 9)
                    {
                        MessageBox.Show("Минимальное количество символов в номере документа: " + 9);
                    }

                    if (addressSoldierBox.Text.Length < 1)
                    {
                        MessageBox.Show("Минимальное количество символов в адресе: " + 1);
                    }

                    if (dateStartMaskedTextBox.Text.Length < 9)
                    {
                        MessageBox.Show("Минимальное количество символов в дате начала службы: " + 9);
                    }

                    if (genderSoldierComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите пол!");
                    }

                    if (ShelfComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите категорию!");
                    }

                    if (rankSoldierComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите звание!");
                    }

                    if (serviceSoldierComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите вид службы!");
                    }

                    if (companySoldierComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите роту!");
                    }

                    if (platoonSoldierComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите взвод!");
                    }

                    if (unitSoldierComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("Выберите отделение!");
                    }
                }
                else if (result == DialogResult.No)
                {
                    // Пользователь выбрал "Нет"

                }

                // Установите фокус на первое невалидное текстовое поле
                if (string.IsNullOrEmpty(fullnameSoldierBox.Text))
                {
                    fullnameSoldierBox.Focus();
                }
                else if (string.IsNullOrEmpty(telephoneSoldierBox.Text))
                {
                    telephoneSoldierBox.Focus();
                }
                else if (string.IsNullOrEmpty(documentSoldierBox.Text))
                {
                    documentSoldierBox.Focus();
                }
                else if (string.IsNullOrEmpty(addressSoldierBox.Text))
                {
                    addressSoldierBox.Focus();
                }
                else if (string.IsNullOrEmpty(soldierTextBoxAdd.Text))
                {
                    soldierTextBoxAdd.Focus();
                }
                else if (string.IsNullOrEmpty(dateStartMaskedTextBox.Text))
                {
                    dateStartMaskedTextBox.Focus();
                }


                return;
            }
            // Если все поля содержат текст, продолжите выполнение других операций
            // ...
            if (!AreComboBoxesValid(genderSoldierComboBox, ShelfComboBox, rankSoldierComboBox, serviceSoldierComboBox, companySoldierComboBox, platoonSoldierComboBox, unitSoldierComboBox))
            {
                MessageBox.Show("Выберите значение во всех полях.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Установите фокус на первое невалидное комбинированное поле
                if (genderSoldierComboBox.SelectedItem == null || genderSoldierComboBox.SelectedItem.ToString() == "")
                {
                    genderSoldierComboBox.Focus();
                }
                else if (ShelfComboBox.SelectedItem == null || ShelfComboBox.SelectedItem.ToString() == "")
                {
                    ShelfComboBox.Focus();
                }
                else if (rankSoldierComboBox.SelectedItem == null || rankSoldierComboBox.SelectedItem.ToString() == "")
                {
                    rankSoldierComboBox.Focus();
                }
                else if (serviceSoldierComboBox.SelectedItem == null || serviceSoldierComboBox.SelectedItem.ToString() == "")
                {
                    serviceSoldierComboBox.Focus();
                }
                else if (companySoldierComboBox.SelectedItem == null || companySoldierComboBox.SelectedItem.ToString() == "")
                {
                    companySoldierComboBox.Focus();
                }
                else if (platoonSoldierComboBox.SelectedItem == null || platoonSoldierComboBox.SelectedItem.ToString() == "")
                {
                    platoonSoldierComboBox.Focus();
                }
                else if (unitSoldierComboBox.SelectedItem == null || unitSoldierComboBox.SelectedItem.ToString() == "")
                {
                    unitSoldierComboBox.Focus();
                }

                return;
            }
            else

            {
                SaveBut.Enabled = true;
            }


        }



        private void textBoxTelNumAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            telephoneSoldierBox.MaxLength = 11;
            // Проверяем, является ли введенный символ первым символом и равен ли он "8"
            if (telephoneSoldierBox.Text.Length == 0 && e.KeyChar != '8' && e.KeyChar != '\0')
            {
                e.Handled = true; // Отменяем ввод символа
            }
            // Проверяем, является ли введенный символ вторым символом и равен ли он "9"
            else if (telephoneSoldierBox.Text.Length == 1 && e.KeyChar != '9' && e.KeyChar != '\0')
            {
                e.Handled = true; // Отменяем ввод символа
            }
            // Проверяем, является ли введенный символ цифрой или клавишей Backspace
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\0')
            {
                e.Handled = true; // Отменяем ввод символа
            }



        }




        private void updateCommanderCheckBox(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                if (checkBox1.Checked == true)
                {
                    string query = $"UPDATE soldier_list SET commander = 1 WHERE id_soldierSL = {id};";
                    Database.databaseDataQueryUpdateInsertDelete(query);


                }
                else if (checkBox1.Checked == false)
                {

                    string query = $"UPDATE soldier_list SET commander = 0  WHERE id_soldierSL = {id};";
                    Database.databaseDataQueryUpdateInsertDelete(query);
                }
                MessageBox.Show("Операция завершена");
            }


        }



        private void calculationDateOfEnd(object sender, EventArgs e)
        {
            if (!(serviceSoldierComboBox.Text == "Срочная"))
            {
                try
                {
                    int year = Convert.ToInt32(textBox3.Text.Substring(0, textBox3.Text.IndexOf(" ")));
                    DateTime startDateService = DateTime.Parse(dateStartMaskedTextBox.Text);
                    endDateServiceDatePicker.Value = startDateService;
                    endDateServiceDatePicker.Value = endDateServiceDatePicker.Value.AddYears(year);
                }
                catch
                {
                    MessageBox.Show("Некорректная дата!");
                }
            }
            else if (serviceSoldierComboBox.Text == "Срочная")
            {
                try
                {
                    DateTime startDateService = DateTime.Parse(dateStartMaskedTextBox.Text);
                    endDateServiceDatePicker.Value = startDateService;
                    endDateServiceDatePicker.Value = endDateServiceDatePicker.Value.AddYears(1);
                }
                catch
                {
                    MessageBox.Show("Некорректная дата!");
                }
            }
        }



        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox3.MaxLength = 2;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отменить обработку символа, если это не цифра и не управляющий символ (например, Backspace).
            }
        }




        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int year))
            {
                string yearsText = "лет";

                if (year % 10 == 1 && year % 100 != 11)
                {
                    yearsText = "год";
                }
                else if ((year % 10 >= 2 && year % 10 <= 4) && !(year % 100 >= 12 && year % 100 <= 14))
                {
                    yearsText = "года";
                }

                textBox3.Text = $"{year} {yearsText}";
            }
            else
            {
                textBox3.Text = "Некорректный год";
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {


            {
                if (e.KeyCode == Keys.Back)
                {
                    // Clear the text box when Backspace key is pressed
                    textBox3.Clear();
                }
            }

        }

        private void serviceComboBoxAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serviceSoldierComboBox.Text == "Срочная")
            {
                textBox3.Text = "";
                textBox3.Enabled = false;
                button1.Enabled = true;
            }
            else
            {
                textBox3.Text = "";
                textBox3.Enabled = true;
                button1.Enabled = true;
            }
        }




        private void SaveBut_Click(object sender, EventArgs e)
        {
            DateTime dateStartService;
            try
            {
                dateStartService = DateTime.Parse(dateStartMaskedTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Некорректная дата!");
                return;
            }
            string[] query;
            query = new string[4];
            if (!isUpdate)
            {

                query[0] = $"INSERT INTO service (type_service, date_start_service, date_end_service)\r\nVALUES\r\n    ('{serviceSoldierComboBox.Text}', '{dateStartService.ToString("yyyy/MM/dd")}', '{endDateServiceDatePicker.Value.ToString("yyyy/MM/dd")}');";
                query[1] = $"INSERT INTO history_soldier (historyofsoldier)\r\nVALUES\r\n('{soldierTextBoxAdd.Text}');";
                query[2] = $"INSERT INTO soldier (document_soldier, name_soldier, dateofbirth_soldier, telnumber_soldier, adress_soldier, gender_soldier, shelflife_category_soldier, id_serviceFK, id_history_soldierFK)\r\nVALUES\r\n('{documentSoldierBox.Text}', '{fullnameSoldierBox.Text}', '{dateOfBirthDatePicker.Value.ToString("yyyy/MM/dd")}', '{telephoneSoldierBox.Text}', '{addressSoldierBox.Text}', '{genderSoldierComboBox.Text}', '{ShelfComboBox.Text}', (SELECT id_service FROM service ORDER BY id_service DESC LIMIT 1), (SELECT id_history_soldier FROM history_soldier ORDER BY id_history_soldier DESC LIMIT 1));";
                query[3] = $"INSERT INTO soldier_list(id_soldierSL, id_rank, id_unit, commander) VALUES ((SELECT id_soldier FROM soldier ORDER BY id_soldier DESC LIMIT 1), (SELECT id_rank_army FROM rank_army WHERE name_rank_army = '{rankSoldierComboBox.Text}'), (SELECT id_unit FROM unit WHERE name_unit = '{unitSoldierComboBox.Text}'), {checkBox1.Checked});";

                string transactionQuery = "START TRANSACTION;";
                for (int i = 0; i < query.Length; i++)
                    transactionQuery = transactionQuery + query[i];
                transactionQuery = transactionQuery + "COMMIT;";
                Database.databaseDataQueryUpdateInsertDelete(transactionQuery);
                MessageBox.Show("Операция завершена!");
            }


            else
            {
                List<string> queriesUpdate = new List<string>()
                {
                    // Обновление Soldier
                    $"UPDATE soldier SET name_soldier = '{fullnameSoldierBox.Text}'," +
                    $"telnumber_soldier = '{telephoneSoldierBox.Text}'," +
                    $"adress_soldier = '{addressSoldierBox.Text}'," +
                    $"shelflife_category_soldier = '{ShelfComboBox.Text}'," +
                    $"id_serviceFK = {id}," +
                    $"id_history_soldierFK = '{id}'," +
                    $"document_soldier = '{documentSoldierBox.Text}'" +
                    $"WHERE id_soldier = '{id}';",
                    // Обновление Service
                    $"UPDATE service SET type_service = '{serviceSoldierComboBox.Text}'," +
                    $"date_start_service = '{DateTime.Parse(dateStartMaskedTextBox.Text).ToString("yyyy/MM/dd")}'," +
                    $"date_end_service = '{endDateServiceDatePicker.Value.ToString("yyyy/MM/dd")}'" +
                    $"WHERE id_service = (SELECT id_serviceFK FROM soldier WHERE id_soldier = {id});",
                    // Обновление SoldierList
                    $"UPDATE soldier_list SET id_rank = (SELECT id_rank_army FROM rank_army WHERE name_rank_army = '{rankSoldierComboBox.Text}'), " +
                    $"id_unit = (SELECT id_unit FROM unit WHERE name_unit = '{unitSoldierComboBox.Text}')" +
                    $"WHERE id_soldierSL = {id};",
                    // Обновление HistorySoldier
                    $"UPDATE history_soldier SET historyofsoldier = '{soldierTextBoxAdd.Text}' WHERE id_history_soldier = (SELECT id_history_soldierFK FROM soldier WHERE id_soldier = {id});"
                };
                string queryUpdate = "";
                for (int i = 0; i < queriesUpdate.Count; i++)
                {
                    queryUpdate = queryUpdate + queriesUpdate[i] + "\n";
                }

                Database.databaseDataQueryUpdateInsertDelete(queryUpdate);
                MessageBox.Show("Операция завершена");
            }

        }


        private void documentSoldierBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            documentSoldierBox.MaxLength = 9;

            if (documentSoldierBox.Text.Length < 2) // Первые два символа - буквы
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true; // Игнорируем ввод символов, отличных от букв и Backspace
                }
            }
            else // Оставшиеся семь символов - цифры
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true; // Игнорируем ввод символов, отличных от цифр и Backspace
                }
            }

        }





        private void fullnameSoldierBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка, является ли нажатая клавиша буквой, пробелом или клавишей Backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 32 && e.KeyChar != '\b')
            {
                // Если нажатая клавиша не является буквой, пробелом или клавишей Backspace,
                // то предотвращаем ее ввод в текстовое поле
                e.Handled = true;
            }
        }

        private void telephoneSoldierBox_Leave_1(object sender, EventArgs e)
        {
            // Проверяем, является ли поле пустым после снятия фокуса
            if (string.IsNullOrWhiteSpace(telephoneSoldierBox.Text))
            {
                telephoneSoldierBox.Text = "89XXXXXXXXX"; // Восстанавливаем текст-подсказку
                telephoneSoldierBox.ForeColor = SystemColors.GrayText; // Устанавливаем серый цвет текста
            }

        }

        private void telephoneSoldierBox_Enter_1(object sender, EventArgs e)
        {
            // Проверяем, является ли текущий текст в поле текстом-подсказкой
            if (telephoneSoldierBox.Text == "89XXXXXXXXX")
            {
                telephoneSoldierBox.Text = ""; // Очищаем поле, чтобы пользователь мог ввести свои данные

                telephoneSoldierBox.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста по умолчанию
            }

        }

        private void documentSoldierBox_Leave(object sender, EventArgs e)
        {
            // Проверяем, является ли поле пустым после снятия фокуса
            if (string.IsNullOrWhiteSpace(documentSoldierBox.Text))
            {
                documentSoldierBox.Text = "AF1234567"; // Восстанавливаем текст-подсказку
                documentSoldierBox.ForeColor = SystemColors.GrayText; // Устанавливаем серый цвет текста
            }
        }

        private void documentSoldierBox_Enter(object sender, EventArgs e)
        {
            // Проверяем, является ли текущий текст в поле текстом-подсказкой
            if (documentSoldierBox.Text == "AF1234567")
            {
                documentSoldierBox.Text = ""; // Очищаем поле, чтобы пользователь мог ввести свои данные

                documentSoldierBox.ForeColor = SystemColors.WindowText; // Восстанавливаем цвет текста по умолчанию
            }
        }
    }


}
