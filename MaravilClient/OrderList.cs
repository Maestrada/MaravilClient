using BAL.Models;
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
using System.Xml.Linq;

namespace MaravilClient
{
    public partial class OrderList : Form
    {
        private User loggedUser;
        private readonly IUserActions userActionsGlobal;
        private readonly IClientActions clientActionsGlobal;
        private readonly IStateActions stateActionsGlobal;
        private readonly ITonwActions tonwActionsGlobal;
        private readonly IOrderActions orderActionsGlobal;
        private List<Order> ordersToPrint;
        public OrderList(User user, IUserActions userActions, IClientActions clientActions, IStateActions stateActions, ITonwActions tonwActions, IOrderActions orderActions)
        {
            InitializeComponent();
            loggedUser = user;
            this.userActionsGlobal = userActions;
            this.clientActionsGlobal = clientActions;
            this.stateActionsGlobal = stateActions;
            this.tonwActionsGlobal = tonwActions;
            this.orderActionsGlobal = orderActions;
            ordersToPrint = new List<Order>();
        }

        private void OrderList_Load(object sender, EventArgs e)
        {
            cbOrderState.SelectedIndex = 1;
            LoadDataGrid();
        }

        private void btnAddToQeue_Click(object sender, EventArgs e)
        {

            foreach (var item in GetCheckedOrders())
            {
                if (!ordersToPrint.Any(x => x.Id == item.Id))
                    ordersToPrint.Add(new Order
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Client = new Client
                        {
                            Name = item.Client.Name,
                            LastName = item.Client.LastName,
                            CellPhone = item.Client.CellPhone,
                            Address = item.Client.Address,
                            Reference = item.Client.Reference
                        }
                    });
            }

            MessageBox.Show("Cola de impresion actualizada.", "Maravil - Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private List<Order> GetCheckedOrders()
        {
            List<Order> checkeds = new List<Order>();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[7].Value)
                {
                    checkeds.Add(new Order
                    {
                        Id = (Int64)item.Cells[0].Value,
                        Description = (string)item.Cells[2].Value,
                        Amount= (decimal)item.Cells[6].Value,
                        Client = new Client
                        {
                        Name = item.Cells[1].Value as string,
                        LastName = item.Cells[2].Value as string,
                        CellPhone = item.Cells[3].Value as string,
                        Address = item.Cells[4].Value as string,
                        Reference = item.Cells[5].Value as string
                        }
                    });
                }
            }

            return checkeds;
        }

        private void btnShowQeue_Click(object sender, EventArgs e)
        {

            PrintQeue printQeue = new PrintQeue(ordersToPrint,orderActionsGlobal);
            DialogResult result = printQeue.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                ordersToPrint = printQeue.listOrders;
                LoadDataGrid();
            }
        }

        private void cbOrderState_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid(bool checkAll = false)
        {
            List<Order> lista = orderActionsGlobal.ListOrder(0,cbOrderState.SelectedIndex);
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (Order order in lista)
            {
                bool selectedData = ordersToPrint.Any(x => x.Id == order.Id) || checkAll;
                dataGridView1.Rows.Add(order.Id, order.Client.Name + "" + order.Client.LastName, order.Description, order.Client.CellPhone + (string.IsNullOrEmpty(order.Client.CellPhone2.Trim()) ? "" : " / " + order.Client.CellPhone2), order.Client.Town.Name + ", " + order.Client.Town.State.Name + ", " + order.Client.Address, order.Client.Reference,order.Amount, selectedData);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            LoadDataGrid(true);
        }

        private void btnUnMarkAll_Click(object sender, EventArgs e)
        {
            List<Order> lista = orderActionsGlobal.ListOrder(cbOrderState.SelectedIndex).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            foreach (Order order in lista)
            {
                dataGridView1.Rows.Add(order.Id, order.Client.Name + "" + order.Client.LastName, order.Description, order.Client.CellPhone + (string.IsNullOrEmpty(order.Client.CellPhone2.Trim()) ? "" : " / " + order.Client.CellPhone2), order.Client.Town.Name + ", " + order.Client.Town.State.Name + ", " + order.Client.Address, order.Client.Reference,order.Amount ,false);
            }
        }

        private void verUsuariosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUsers sysUser = new SystemUsers(loggedUser, userActionsGlobal);
            sysUser.ShowDialog();
        }

        private void cambiarMiContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(loggedUser, userActionsGlobal);
            changePassword.ShowDialog();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void agregarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder(loggedUser, clientActionsGlobal, orderActionsGlobal);
            addOrder.ShowDialog();
            LoadDataGrid();
        }

        private void borrarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Order> selectedOrders = GetCheckedOrders();
            if (selectedOrders.Count <= 0)
            {
                MessageBox.Show("Debes tener seleccionado al menos 1 compra.", "Maravil - Compras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar las compras seleccionadas?", "Maravil - Compras", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                try {
                    orderActionsGlobal.DeleteOrder(selectedOrders.Select(x=>x.Id).ToList());
                    MessageBox.Show("Ordenes eliminadas exitosamente.", "Maravil - Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ordersToPrint.Clear();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Maravil - Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
           List<Order>selectedOrders = GetCheckedOrders();
            if (selectedOrders.Count!=1)
            {
                MessageBox.Show("Debes tener seleccionado 1 compra.","Maravil - Compras",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            AddOrder addOrder = new AddOrder(loggedUser, clientActionsGlobal, orderActionsGlobal, selectedOrders[0].Id);
            addOrder.ShowDialog();
            LoadDataGrid();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientList frmClients = new ClientList(loggedUser,userActionsGlobal,clientActionsGlobal,stateActionsGlobal,tonwActionsGlobal,orderActionsGlobal);
            frmClients.FormClosed += (s, args) => this.Show();
            frmClients.Show();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
