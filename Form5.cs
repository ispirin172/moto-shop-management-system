using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 forma = new Form3();
            forma.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fio = textBox1.Text;
            String telephone = textBox2.Text;
            String pokupka = textBox3.Text;

            DBcl db = new DBcl();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `clients` (`fio`, `telephone`, `pokupka`) VALUES(@fio, @tel, @pok)", db.GetConnection());
            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = fio;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telephone;
            command.Parameters.Add("@pok", MySqlDbType.VarChar).Value = pokupka;


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Покупатель добавлен");
                this.Hide();
                Form3 forms = new Form3();
                forms.Show();
            }
            else
                MessageBox.Show("Есть ошибка");


            db.closeConnection();
        }
    }
}
