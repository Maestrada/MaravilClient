using BAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Services.ClientActions;
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
        private List<Client> clientsToPrint;

        public ClientList(User user, IUserActions userActions, IClientActions clientActions)
        {
            InitializeComponent();
            loggedUser = user;
            userActionsGlobal = userActions;
            clientActionsGlobal = clientActions;
            clientsToPrint = new List<Client>();
        }

        private void agregarNuevoUsuarioDeSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cambiarMiContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient(loggedUser, clientActionsGlobal);
            addClient.ShowDialog();
        }

        private void borrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verUsuariosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarUsuarioDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cambiarMiContraseñaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
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
            List<Client> lista = clientActionsGlobal.ListClient(txtName.Text, txtLastName.Text, txtPhone.Text).ToList();
            dataGridView1.DataSource = null;
            foreach (Client client in lista)
            {
                bool selectedData = clientsToPrint.Any(x=>x.Id==client.Id) || checkAll;
                dataGridView1.Rows.Add(client.Id, client.Name, client.LastName, client.CellPhone + (string.IsNullOrEmpty(client.CellPhone2.Trim()) ? "" : " / " + client.CellPhone2), client.Address, selectedData);
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
            CleanTextBoxes();
        }

        private void btnAddPrintQeue_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[5].Value)
                    clientsToPrint.Add(new Client
                    {
                        Id = (int)item.Cells[0].Value,
                        Name = item.Cells[1].Value as string,
                        LastName = item.Cells[2].Value as string,
                        CellPhone = item.Cells[3].Value as string,
                        Address = item.Cells[4].Value as string,
                    });
            }
        }

        private void btnShowPrintQeue_Click(object sender, EventArgs e)
        {
            PrintQeue printQeue = new PrintQeue(clientsToPrint);
            DialogResult result = printQeue.ShowDialog();
            if (result == DialogResult.OK)
            {
                clientsToPrint = printQeue.listClient;
                LoadDataGrid();
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            LoadDataGrid(true);
        }
    }
}
