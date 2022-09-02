using BAL.Models;
using Services.Resources;
using Services.UserActions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaravilClient
{
    public partial class ChangePassword : Form
    {
        private User loggedUser;
        private readonly IUserActions userActionsGlobal;
        public ChangePassword(User user,IUserActions userActions)
        {
            InitializeComponent();
            loggedUser = user;
            userActionsGlobal = userActions;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {  
            string oldPass = loggedUser.Password;
            if (txtNewPass.Text == txtNewPass.Text && Encrypt.GetSHA256(txtOldPass.Text)==loggedUser.Password)
            {

                loggedUser.Password = txtNewPass.Text;
                try
                {
                    userActionsGlobal.UpdateUser(loggedUser);
                    MessageBox.Show("Constraseña actualizada con exito!", "Maravil - Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loggedUser.Password=Encrypt.GetSHA256(txtNewPass.Text);
                    txtNewPass.Clear();
                    txtNewPassConf.Clear();
                    txtOldPass.Clear();
                    this.Close();
                }
                catch(Exception ex)
                {
                    loggedUser.Password = oldPass;
                    MessageBox.Show(ex.Message, "Maravil - Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = Encrypt.GetSHA256(txtOldPass.Text) != loggedUser.Password ? "La contraseña anterior no coincide con la que ha escrito" : "Contraseñas no coinciden";
                MessageBox.Show(message, "Maravil - Cambio de contraseña",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }


        private void ValidatePasswords()
        {
            if(txtNewPass.Text == txtNewPassConf.Text)
            {
                btnSave.Enabled = true;
                lbConfirmation.Visible = false;
            }
            else
            {
                btnSave.Enabled = false;
                lbConfirmation.Visible = true;
            }
        }

        private void txtNewPassConf_KeyUp(object sender, KeyEventArgs e)
        {
            ValidatePasswords();
        }
    }
}
