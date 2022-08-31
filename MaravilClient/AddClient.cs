using BAL.Models;
using Services.ClientActions;
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
    public partial class AddClient : Form
    {
        User loggedUser;
        private readonly IClientActions clientActionsGlobal;
        public AddClient(User user, IClientActions clientActions)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.clientActionsGlobal = clientActions;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClient();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show("Por favor introduzca: " + message, "Maravil - Nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtPhone2.Clear();
        }

        private void SaveClient()
        {
            if (MessageBox.Show("Esta seguro de continuar?", "Maravil - Nuevo cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string message = string.Empty;

                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                    message += "\n -Nombre";
                if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
                    message += "\n -Apellido";
                if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
                    message += "\n -Phone";
                if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
                    message += "\n -Direccion";

                if (!string.IsNullOrEmpty(message))
                {
                    ShowMessage(message);
                    return;
                }
                Client client = new Client();
                try
                {
                    client.Name = txtName.Text.Trim();
                    client.LastName = txtLastName.Text.Trim();
                    client.CellPhone = txtPhone.Text.Trim();
                    client.CellPhone2 = txtPhone2.Text.Trim();
                    client.Address = txtAddress.Text.Trim();
                    client.CreatedByUserId = loggedUser.Id;
                    client.ModifiedByUserId = loggedUser.Id;

                    label1.Focus();

                    if (clientActionsGlobal.CreateClient(client))
                        MessageBox.Show("Cliente agregado exitosamente. ", "Maravil - Nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Maravil - Nuevo cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearFields();
            }
        }

        private void txtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveClient();
        }

        private void txtPhone2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAddress.Focus();

        }

        private void txtPhone_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPhone2.Focus();
        }

        private void txtLastName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPhone.Focus();
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLastName.Focus();
        }
    }
}
