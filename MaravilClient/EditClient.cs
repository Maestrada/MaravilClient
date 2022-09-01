using BAL.Models;
using Microsoft.Extensions.Configuration.UserSecrets;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaravilClient
{
    public class AuxiliarClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class EditClient : Form
    {
        User loggedUser;
        Client selectedClient;
        List<Client> clients;
        private readonly IClientActions clientActionsGlobal;
        public EditClient(User user, IClientActions clientActions)
        {
            InitializeComponent();
            loggedUser = user;
            clientActionsGlobal = clientActions;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientEdit_Load(object sender, EventArgs e)
        {
            GetAllWorkData();
        }

        private void GetAllWorkData()
        {
            clients = GetClients();
            cbClient.Items.Clear();

            cbClient.DataSource = clients.Select(x => new { Id = x.Id, Name = x.Name + " " + x.LastName }).OrderBy(x => x.Name).ToList();
            cbClient.DisplayMember = "Name";
            cbClient.ValueMember = "Id";

            cbClient.AutoCompleteCustomSource = LoadAutoComplete(clients);
            cbClient.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbClient.AutoCompleteSource = AutoCompleteSource.CustomSource;

            cbClient.ResetText();
            ClearFields();
        }

        private List<Client> GetClients()
        {
            return clientActionsGlobal.ListClient(string.Empty, string.Empty, string.Empty);
        }
        private AutoCompleteStringCollection LoadAutoComplete(List<Client> listClients)
        {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (var item in listClients)
            {
                stringCol.Add(item.Name + " " + item.LastName);
            }

            return stringCol;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClient();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show("Por favor introduzca: " + message, "Maravil - Editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void SaveClient()
        {
            if (MessageBox.Show("Esta seguro de continuar?", "Maravil - Editar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                try
                {
                    selectedClient.Name = txtName.Text.Trim();
                    selectedClient.LastName = txtLastName.Text.Trim();
                    selectedClient.CellPhone = txtPhone.Text.Trim();
                    selectedClient.CellPhone2 = txtPhone2.Text.Trim();
                    selectedClient.Address = txtAddress.Text.Trim();
                    selectedClient.CreatedByUserId = loggedUser.Id;
                    selectedClient.ModifiedByUserId = loggedUser.Id;

                    label1.Focus();

                    if (clientActionsGlobal.UpdateClient(selectedClient))
                        MessageBox.Show("Cliente agregado exitosamente. ", "Maravil - Editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Maravil - Editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearFields();
            }
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        { 
            selectedClient = clients.First(x => x.Id == ((dynamic)cbClient.SelectedItem).Id);
            txtName.Text = selectedClient.Name;
            txtLastName.Text = selectedClient.LastName;
            txtPhone2.Text = selectedClient.CellPhone2;
            txtPhone.Text = selectedClient.CellPhone;
            txtAddress.Text = selectedClient.Address;
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtPhone2.Clear();
        }

    }
}
