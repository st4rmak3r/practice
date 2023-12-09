using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace AppPractice
{
    public partial class TechniqueADD : Form
    {
        private string id;
        private bool updatetech;
        public TechniqueADD()
        {
            InitializeComponent();
            updatetech = false;
        }
        public TechniqueADD(string id)
        {
            InitializeComponent();
            this.id = id;
            updatetech = true;
        }

        private void CloseButton(object sender, EventArgs e)
        {
            Form TechniqueForm = new TechniqueForm();
            TechniqueForm.Show();
            Dispose();
        }

        private void Mainmenubut_Click(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Show();
            Dispose();
        }

        private void SaveOrUpdateButton(object sender, EventArgs e)
        {
            // Добавление
            if (!updatetech)
            {
                if ((techtypeComboBoxAdd.Text == "Выберите") || (currentconComboBox.Text == "Выберите") || (textBoxtechNameAdd.Text == ""))
                {
                    MessageBox.Show("Введите все данные!");
                    return;
                }
                string query = "INSERT INTO technique (name_technique, type_technique, id_battalionFK, id_conditionFK) VALUES ('" + textBoxtechNameAdd.Text + "','" + techtypeComboBoxAdd.Text + "', '1', (SELECT id_condition FROM condition_ WHERE inf_condition = '" + currentconComboBox.Text + "'));";
                Database.databaseDataQueryUpdateInsertDelete(query);
                MessageBox.Show("Добавление прошло успешно!");
            }
            // Изменение
            else
            {
                if ((techtypeComboBoxAdd.Text == "Выберите") || (currentconComboBox.Text == "Выберите") || (textBoxtechNameAdd.Text == ""))
                {
                    MessageBox.Show("Введите все данные!");
                    return;
                }
                string query = $"UPDATE technique SET name_technique = '{textBoxtechNameAdd.Text}'," +
                    $"type_technique = '{techtypeComboBoxAdd.Text}'," +
                    $"id_conditionFK = (SELECT id_condition FROM condition_ WHERE inf_condition = '{currentconComboBox.Text}')" +
                    $"WHERE (id_technique = {id})";
                Database.databaseDataQueryUpdateInsertDelete(query);
                MessageBox.Show("Операция закончена!");
            }
        }

        private void TechniqueADD_Load(object sender, EventArgs e)
        {


            // Добавление
            if (!updatetech)
            {
                button2.Text = "Добавить";
                if (!techtypeComboBoxAdd.Items.Contains("Выберите"))
                {
                    techtypeComboBoxAdd.Items.Clear();
                    object[] typeTechnique = new object[8]
                    {
                        "Выберите",
                        "Боевая техника",
                        "Ракетная техника",
                        "Зенитная техника",
                        "Артиллерийская техника",
                        "Военная авиация",
                        "Подводная техника",
                        "Морская техника"
                    };
                    techtypeComboBoxAdd.Items.AddRange(typeTechnique);
                }
                currentconComboBox.Items.Add("Выберите");
                currentconComboBox.Text = currentconComboBox.Items[0].ToString();

            }
            // Изменение
            else
            {
                techtypeComboBoxAdd.Items.RemoveAt(0);
                string queryInitializeTechnique = $"SELECT name_technique, type_technique, inf_condition FROM technique, condition_ WHERE (id_condition = id_conditionFK) and (id_technique = {id});";
                DataTable initializeTechnique = Database.selectStatementNotParameters(queryInitializeTechnique);
                textBoxtechNameAdd.Text = initializeTechnique.Rows[0].ItemArray[0].ToString();
                techtypeComboBoxAdd.Text = initializeTechnique.Rows[0].ItemArray[1].ToString();
                currentconComboBox.Text = initializeTechnique.Rows[0].ItemArray[2].ToString();
            }
            // Общее
            string queryInitializeConditionTech = "SELECT DISTINCT inf_condition FROM condition_";
            DataTable conditionList = Database.selectStatementNotParameters(queryInitializeConditionTech);
            for (int i = 0; i < conditionList.Rows.Count; i++)
                currentconComboBox.Items.Add(conditionList.Rows[i].ItemArray[0].ToString());
        }

        private void TechniqueADD_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                Application.Exit();
        }
    }
}

