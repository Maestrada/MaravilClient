using BAL.Models;
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
            if (txtNewPass.Text == txtNewPass.Text)
            {
                loggedUser.Password = txtNewPass.Text;
                try
                {
                    userActionsGlobal.UpdateUser(loggedUser);
                    MessageBox.Show("Constraseña actualizada con exito!", "Maravil - Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Maravil - Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Contraseñas no coinciden","Maravil - Cambio de contraseña",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }


        private void ValidatePasswords()
        {
            if(txtNewPass.Text == txtNewPass.Text)
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
