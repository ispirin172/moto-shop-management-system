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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fio = textBox1.Text;
            String tel = textBox3.Text;
            String log = textBox4.Text;
            String pass = textBox2.Text;
            DBpl db = new DBpl();
            MySqlCommand command = new MySqlCommand("INSERT INTO `polz` (`fio`, `telephone`, `login`, `pass`) VALUES(@fio, @log, @pas, @tel)", db.GetConnection());

            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = tel;
            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = fio;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Регистрация прошла успешно!");
                this.Hide();
                Form1 forms = new Form1();
                forms.Show();
            }
            else
                MessageBox.Show("Регистрация не прошла, проверьте данные!");

            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma = new Form1();
            forma.Show();
        }
    }
}
