using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autorisation_and_Registration
{
    public partial class PassswordRecovery : Form
    {
        public PassswordRecovery()
        {
            InitializeComponent();
            LoginField.Text = "enter login";
            LoginField.ForeColor = Color.Gray;
            //SWField.Text = "____";
            //SWField.ForeColor = Color.Gray;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            if ((LoginField.Text == "enter login") || (SWField.Text == ""))
            {
                MessageBox.Show("Fill all the fields!");
                return;
            }

            String loginUser = LoginField.Text;
            String SWUser = SWField.Text;

            MySqlConnection sc = new MySqlConnection();

            MySqlCommand command = new MySqlCommand();

            sc.ConnectionString = ("server=127.0.0.1;port=3306;username=root;password=;database=users");
            sc.Open();
            command.Connection = sc;


            command.CommandText = ("SELECT `password` FROM `usersinfo` WHERE `login` = @ul AND `secretword` = @sw");

            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@sw", MySqlDbType.VarChar).Value = SWUser;

            object result = command.ExecuteScalar();
            string kod = Convert.ToString(result);
            MessageBox.Show("Your password is: " + kod);

            Autorisation autorisation_form = new Autorisation();
            autorisation_form.PasswordFieldText = kod;
            autorisation_form.LoginFieldText = LoginField.Text;
            autorisation_form.Show();

            sc.Close();

            if (LoginField.Text == "enter login")
            {
                MessageBox.Show("Enter your login!");
                return;
            }

        }

        private void BackAutorisationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Autorisation autorisation_form = new Autorisation();
            autorisation_form.Show();
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

        //private void SWField_Enter(object sender, EventArgs e)
        //{
        //    if (SWField.Text == "____")
        //    {
        //        SWField.Text = "";
        //        SWField.ForeColor = Color.Black;
        //    }
        //}

        //private void SWField_Leave(object sender, EventArgs e)
        //{
        //    if (SWField.Text == "")
        //    {
        //        SWField.Text = "____";
        //        SWField.ForeColor = Color.Gray;
        //    }
        //}

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
    }
}




