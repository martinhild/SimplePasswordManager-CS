﻿using PasswordManagerApp.Services;
using SimplePasswordManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManagerApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtMasterPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var pw = txtMasterPassword.Text;
            var masterPwService = new MasterPasswordService();

            if (!masterPwService.IsMasterPasswordSet())
            {
                masterPwService.SetMasterPassword(pw);
                MessageBox.Show("Masterpasswort gespeichert. Bitte erneut anmelden.");
                return;
            }

            if(masterPwService.VerifyMasterPassword(pw))
            {
                var main = new MainForm();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Falsches Masterpasswort.");
            }
        }
    }
}
