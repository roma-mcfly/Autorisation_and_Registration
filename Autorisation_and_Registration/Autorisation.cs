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
    public partial class Autorisation : Form
    {
        //public string LoginText = "enter login";

        public Autorisation()
        {
            InitializeComponent();
          
            LoginField.Text = "enter login";
            LoginField.ForeColor = Color.Gray;
      
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point LastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = LoginField.Text;
            String passUser = PasswordField.Text;

            DataBase db = new DataBase();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `usersinfo` WHERE `login` = @ul AND `password` = @up", db.getConnection());

            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (LoginField.Text == "enter login") 
            {
                MessageBox.Show("Enter your login!");
                return;
            }

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("You have successfully logged in!");
                this.Hide();
                MainForm main_form = new MainForm();
                main_form.Show();
            }
            else
            {
                MessageBox.Show("Login or password is not correct!");
            }
        }

        private void ToRegistrLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration_form = new Registration();
            registration_form.Show();
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

        private void FPlogin_Click(object sender, EventArgs e)
        {
            PassswordRecovery recoveryn_form = new PassswordRecovery();
            if (LoginField.Text != "enter login")
            {
                recoveryn_form.LoginFieldText = LoginField.Text;
            }
            this.Hide();      
            recoveryn_form.Show();
        }

        public string PasswordFieldText
        {
            set
            {
                PasswordField.Text = value;
            }
            get
            {
                return PasswordField.Text;
            }
        }

        public string LoginFieldText
        {
            set
            {
                LoginField.Text = value;
            }
            get
            {
                return LoginField.Text;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PasswordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void SecondPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
