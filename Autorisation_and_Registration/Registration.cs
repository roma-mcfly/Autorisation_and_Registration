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

namespace Autorisation_and_Registration
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();

            NameField.Text = "enter name";
            NameField.ForeColor = Color.Gray;
            LoginField.Text = "enter login";
            LoginField.ForeColor = Color.Gray;
            PasswordField.Text = "____";
            PasswordField.ForeColor = Color.Gray;
            SWField.Text = "____";
            SWField.ForeColor = Color.Gray;
            SurnameField.Text = "enter surname";
            SurnameField.ForeColor = Color.Gray;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point LastPoint;

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void NameField_Enter(object sender, EventArgs e)
        {
            if (NameField.Text == "enter name")
            {
                NameField.Text = "";
                NameField.ForeColor = Color.Black;
            }
        }

        private void NameField_Leave(object sender, EventArgs e)
        {
            if (NameField.Text == "")
            {
                NameField.Text = "enter name";
                NameField.ForeColor = Color.Gray;
            }
        }

        private void LoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "enter login")
            {
                LoginField.Text = "";
                LoginField.ForeColor = Color.Black;
            }
        }

        private void LoginField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "enter login";
                LoginField.ForeColor = Color.Gray;
            }
        }

        private void PasswordField_Enter(object sender, EventArgs e)
        {
            if (PasswordField.Text == "____")
            {
                PasswordField.Text = "";
                PasswordField.ForeColor = Color.Black;
            }
        }

        private void PasswordField_Leave(object sender, EventArgs e)
        {
            if (PasswordField.Text == "")
            {
                PasswordField.Text = "____";
                PasswordField.ForeColor = Color.Gray;
            }
        }

        private void SWField_Enter(object sender, EventArgs e)
        {
            if (SWField.Text == "____")
            {
                SWField.Text = "";
                SWField.ForeColor = Color.Black;
            }
        }

        private void SWField_Leave(object sender, EventArgs e)
        {
            if (SWField.Text == "")
            {
                SWField.Text = "____";
                SWField.ForeColor = Color.Gray;
            }
        }

        private void SurnameField_Enter(object sender, EventArgs e)
        {
            if (SurnameField.Text == "enter surname")
            {
                SurnameField.Text = "";
                SurnameField.ForeColor = Color.Black;
            }
        }

        private void SurnameField_Leave(object sender, EventArgs e)
        {
            if (SurnameField.Text == "")
            {
                SurnameField.Text = "enter surname";
                SurnameField.ForeColor = Color.Gray;
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if ((NameField.Text == "enter name") || (SurnameField.Text == "enter surname") || (LoginField.Text == "enter login") || (PasswordField.Text == "____") || (SWField.Text == "____"))
            {
                MessageBox.Show("Fill all the fields!");
                return;
            }

            string symb = "ABCDEFGHIJKLMNOPRSTUVWXYZ123456789!\"#$%&'()*+,-./::<=>?@[\\]:_{|}";
            if ((PasswordField.Text.IndexOfAny(symb.ToCharArray()) == -1) || (PasswordField.Text.Length < 8) || (PasswordField.Text[0] == '.') || (PasswordField.Text[0] == ',') || (PasswordField.Text[0] == '!') || (PasswordField.Text[0] == '?') || (PasswordField.Text[0] == ' '))
            {
                MessageBox.Show("Password isn't correct!");
                return;
            }

            if (IsUserExist())
            {
                return;
            }

            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `usersinfo` (`login`, `password`, `secretword`, `name`, `surname`) VALUES (@ul, @up, @sw, @name, @surname)", db.getConnection());

            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = LoginField.Text;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = PasswordField.Text;
            command.Parameters.Add("@sw", MySqlDbType.VarChar).Value = SWField.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("You have successfully registered!");
            }
            else
            {
                MessageBox.Show("You could not register");
            }

            db.closeConnection();

            this.Hide();
            Autorisation autorisation_form = new Autorisation();
            autorisation_form.LoginFieldText = LoginField.Text;
            autorisation_form.PasswordFieldText = PasswordField.Text;
            autorisation_form.Show();
        }

        public Boolean IsUserExist()
        {
            DataBase db = new DataBase();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `usersinfo` WHERE `login` = @ul", db.getConnection());

            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = LoginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("This login is already exists!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ToRegistrLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorisation autorisation_form = new Autorisation();
            autorisation_form.Show();
        }

        private void PasswordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void SecondPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SWField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void SurnameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

