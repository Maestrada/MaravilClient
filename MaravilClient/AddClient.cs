using BAL.Models;
using Services.ClientActions;
using Services.StatesActions;
using Services.TownActions;
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
        private readonly IStateActions stateActionsGlobal;
        private readonly ITonwActions tonwActionsGlobal;

        List<State> states;
        List<Town> towns;
        public AddClient(User user, IClientActions clientActions, IStateActions stateActions, ITonwActions tonwActions)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.clientActionsGlobal = clientActions;
            this.stateActionsGlobal = stateActions;
            this.tonwActionsGlobal = tonwActions;
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
            txtReference.Clear();
            txtPhone2.Clear();
            cbState.SelectedIndex = 0;
            cbTown.SelectedIndex = 0;
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
                if (string.IsNullOrEmpty(txtReference.Text.Trim()))
                    message += "\n -txtReferencia";
                if (GetStateId() <= 0)
                    message += "\n -Departamento";
                if (GetTownId() <= 0)
                    message += "\n -Municipio";

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
                    client.Reference = txtReference.Text.Trim();
                    client.CreatedByUserId = loggedUser.Id;
                    client.ModifiedByUserId = loggedUser.Id;
                    client.TownId = GetTownId();

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
                txtReference.Focus();

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

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTown.DataSource = towns.Where(x => x.StateId == GetStateId()).ToList();
            cbTown.DisplayMember = "Name";
            cbTown.ValueMember = "Id";
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            towns = tonwActionsGlobal.GetTowns(String.Empty);
            states = stateActionsGlobal.GetStates(String.Empty);
            cbState.DataSource = states;
            cbState.DisplayMember = "Name";
            cbState.ValueMember = "Id";

        }

        private int GetTownId()
        {
            return ((dynamic)cbTown.SelectedItem).Id;
        }
        private int GetStateId()
        {
            return ((dynamic)cbState.SelectedItem).Id;
        }

        private void txtReference_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveClient();
        }
    }
}
