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
    public partial class EditSystemUser : Form
    {
        int userIdGlobal = 0;
        private readonly IUserActions userActionsGlobal;
        User user;
        User loggedUser;
        public EditSystemUser(int userId,User currentUser, IUserActions userActions)
        {
            InitializeComponent();
            userIdGlobal = userId;  
            userActionsGlobal = userActions;
            loggedUser = currentUser;  
        }

        private void EditSystemUser_Load(object sender, EventArgs e)
        {
            user = userActionsGlobal.GetUser(userIdGlobal);
            lbRol.Text = user.IsSystemAdmin ? "Administrador" : "Usuario Regular";
            lbStatus.Text = user.ActiveStatus ? "Activo" : "Inactivo";
            lbUser.Text = user.UserName;

            btChangeRol.Enabled = loggedUser.IsSystemAdmin;
        }

        private void btChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                user.ActiveStatus = !user.ActiveStatus;
                userActionsGlobal.UpdateUser(user,false);
                lbStatus.Text = user.ActiveStatus ? "Activo" : "Inactivo";
                MessageBox.Show("Hecho exitosamente!", "Maravil - Editar usario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Maravil - Editar usario",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btResetPass_Click(object sender, EventArgs e)
        {
            try
            {
                user.Password = "maravil";
                userActionsGlobal.UpdateUser(user);
                MessageBox.Show("Hecho exitosamente!", "Maravil - Editar usario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Maravil - Editar usario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btChangeRol_Click(object sender, EventArgs e)
        {
            try
            {
                user.IsSystemAdmin = !user.IsSystemAdmin;
                userActionsGlobal.UpdateUser(user, false);
                lbRol.Text = user.IsSystemAdmin? "Administrador" : "Usuario Regular";
                MessageBox.Show("Hecho exitosamente!", "Maravil - Editar usario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Maravil - Editar usario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
