using BAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Services.ClientActions;
using Services.OrderActions;
using Services.StatesActions;
using Services.TownActions;
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
    public partial class ClientList : Form
    {
        private User loggedUser;
        private readonly IUserActions userActionsGlobal;
        private readonly IClientActions clientActionsGlobal;
        private readonly IStateActions stateActionsGlobal;
        private readonly ITonwActions tonwActionsGlobal;
        private readonly IOrderActions orderActionsGlobal;
        List<State> states;

        public ClientList(User user, IUserActions userActions, IClientActions clientActions, IStateActions stateActions, ITonwActions tonwActions, IOrderActions orderActions)
        {
            InitializeComponent();
            loggedUser = user;
            this.userActionsGlobal = userActions;
            this.clientActionsGlobal = clientActions;
            this.stateActionsGlobal = stateActions;
            this.tonwActionsGlobal = tonwActions;
            this.orderActionsGlobal = orderActions;
        }
        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient(loggedUser, clientActionsGlobal,stateActionsGlobal,tonwActionsGlobal);
            addClient.ShowDialog();
            LoadDataGrid();
        }

        private void borrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Client> clients = GetCheckedClients();
            if (clients.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar los clientes seleccionados?", "Maravil - Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (Client client in clients)
                    {
                        clientActionsGlobal.DeleteClient(client);
                    }
                    LoadDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Seleccione los clientes a eliminar.", "Maravil - Eliminar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void verUsuariosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUsers sysUser = new SystemUsers(loggedUser, userActionsGlobal);
            sysUser.ShowDialog();
        }

        private void cambiarMiContraseñaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(loggedUser, userActionsGlobal);
            changePassword.ShowDialog();
        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            LoadStates();
            LoadDataGrid();
        }

        private void LoadStates()
        {
            states = stateActionsGlobal.GetStates(String.Empty);
            states.Insert(0,new State()
            {
                Id = 0,
                Name = "Todos"
            });

            cbState.DataSource = states;
            cbState.DisplayMember = "Name";
            cbState.ValueMember = "Id";
            cbState.SelectedValue = 0;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadDataGrid(bool checkAll = false)
        {
            List<Client> lista = clientActionsGlobal.ListClient(txtName.Text, txtLastName.Text, txtPhone.Text, GetStateId()).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (Client client in lista)
            {
                bool selectedData =  checkAll;
                dataGridView1.Rows.Add(client.Id, client.Name, client.LastName, client.CellPhone + (string.IsNullOrEmpty(client.CellPhone2.Trim()) ? "" : " / " + client.CellPhone2), client.Town.Name+", "+ client.Town.State.Name+", "+ client.Address,client.Reference, selectedData);
            }
        }
        private void CleanTextBoxes()
        {
            txtLastName.Clear();
            txtName.Clear();
            txtPhone.Clear();
        }

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
        }
       
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            LoadDataGrid(true);
        }

        private List<Client> GetCheckedClients()
        {
            List<Client> checkeds = new List<Client>();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[6].Value)
                {
                    checkeds.Add(new Client
                    {
                        Id = (int)item.Cells[0].Value,
                        Name = item.Cells[1].Value as string,
                        LastName = item.Cells[2].Value as string,
                        CellPhone = item.Cells[3].Value as string,
                        Address = item.Cells[4].Value as string,
                        Reference = item.Cells[5].Value as string
                    });
                }
            }

            return checkeds;
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadDataGrid();
        }

        private void txtLastName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadDataGrid();
        }

        private void txtPhone_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                LoadDataGrid();
        }

        private void editarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditClient editClient = new EditClient(loggedUser,clientActionsGlobal, stateActionsGlobal, tonwActionsGlobal);
            editClient.ShowDialog();
            LoadDataGrid();
        }

        private void btnUnMarkAll_Click(object sender, EventArgs e)
        {
            List<Client> lista = clientActionsGlobal.ListClient(txtName.Text, txtLastName.Text, txtPhone.Text,GetStateId()).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (Client client in lista)
            {
                dataGridView1.Rows.Add(client.Id, client.Name, client.LastName, client.CellPhone + (string.IsNullOrEmpty(client.CellPhone2.Trim()) ? "" : " / " + client.CellPhone2), client.Town.Name + ", " + client.Town.State.Name + ", " + client.Address,client.Reference,false);
            }
        }

        private int GetStateId()
        {
            return ((dynamic)cbState.SelectedItem).Id;
        }

        private void btClean_Click(object sender, EventArgs e)
        {
            txtLastName.Clear();
            txtName.Clear();
            txtPhone.Clear();
            cbState.SelectedValue = 0;
            LoadDataGrid();
        }        
    }
}
