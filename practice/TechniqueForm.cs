using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AppPractice
{
    public partial class TechniqueForm : Form
    {
        private string id;

        public TechniqueForm()
        {
            InitializeComponent();
        }


        private void Mainmenubut_Click(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
            MainForm.Visible = true;
            this.Dispose();

        }

        private void TechniqueForm_Load(object sender, EventArgs e)
        {

            try
            {
                string sqlSelect = "SELECT t.id_technique, t.name_technique,   t.type_technique, c.inf_condition\r\nFROM technique AS t\r\nJOIN condition_ AS c ON t.id_conditionFK = c.id_condition;";
                System.Data.DataTable dt = Database.selectStatementNotParameters(sqlSelect);
                dataGridTech.AutoGenerateColumns = false;
                dataGridTech.DataSource = dt;
                dataGridTech.Columns["Column1"].DataPropertyName = "id_technique";
                dataGridTech.Columns["Column2"].DataPropertyName = "name_technique";
                dataGridTech.Columns["Column3"].DataPropertyName = "type_technique";
                dataGridTech.Columns["Column4"].DataPropertyName = "inf_condition";
                dataGridTech.Sort(dataGridTech.Columns[0], ListSortDirection.Ascending);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Connection error!" + exc.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void TechniqueForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Закрыть проект (выход из приложения)
                Application.Exit();
            }
        }

        private void AddTechnique_Click(object sender, EventArgs e)
        {
            Form TechniqueADD = new TechniqueADD();
            TechniqueADD.Show();
            this.Dispose();

        }


        private void dataGridTech_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridTech.Columns["Column5"].Index && e.RowIndex >= 0)
            {
                string id = dataGridTech.Rows[e.RowIndex].Cells[0].Value.ToString();
                Form TechniqueAdd = new TechniqueADD(id);
                TechniqueAdd.Show();
                Dispose();
            }
            else if (e.ColumnIndex == dataGridTech.Columns["Column6"].Index && e.RowIndex >= 0)
            {
                string query = "DELETE from technique where id_technique = " + dataGridTech.Rows[e.RowIndex].Cells[0].Value.ToString() + ";";
                dataGridTech.Rows.RemoveAt(e.RowIndex);
                Database.databaseDataQueryUpdateInsertDelete(query);
                MessageBox.Show("Удаление прошло успешно!");
            }

        }
    }
}

