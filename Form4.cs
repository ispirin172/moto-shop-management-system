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

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 forms = new Form3();
            forms.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String marka = textBox1.Text;
            String model = textBox2.Text;
            String god = textBox3.Text;
            String sostoyanie = textBox4.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `moto` (`marka`, `model`,`god`,`sostoyanie`) VALUES(@mar, @mod, @god, @sos)", db.GetConnection());
            command.Parameters.Add("@mar", MySqlDbType.VarChar).Value = marka;
            command.Parameters.Add("@mod", MySqlDbType.VarChar).Value = model;
            command.Parameters.Add("@god", MySqlDbType.VarChar).Value = god;
            command.Parameters.Add("@sos", MySqlDbType.VarChar).Value = sostoyanie;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Мотоцикл добавлен");
                this.Hide();
                Form3 form = new Form3();
                form.Show();
            }
            else
                MessageBox.Show("Есть ошибка");


            db.closeConnection();
        }
    }
}
