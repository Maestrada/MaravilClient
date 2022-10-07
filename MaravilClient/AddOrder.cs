using BAL.Models;
using Org.BouncyCastle.Asn1.X509;
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
    public partial class AddOrder : Form
    {
        private User loggedUser;
        private readonly IClientActions clientActionsGlobal;
        private readonly IOrderActions orderActionsGlobal;
        Order updateOrder;

        public AddOrder(User user, IClientActions clientActions, IOrderActions orderActions, Int64 orderId=0)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.clientActionsGlobal = clientActions;
            this.orderActionsGlobal = orderActions;
            if (orderId > 0)
            {
                updateOrder = orderActionsGlobal.GetOrderById(orderId);
            }
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            LoadClientsCombo();
            if (updateOrder != null)
            {
                txtDescription.Text = updateOrder.Description;
                txtAmount.Text = updateOrder.Amount.ToString();
                foreach (Client item in cbClients.Items)
                {
                    if (item.Id == updateOrder.Id)
                    {
                        cbClients.SelectedIndex = cbClients.Items.IndexOf(item);
                    }
                }
            }
        }

        private void LoadClientsCombo()
        {
            List<Client> clients = clientActionsGlobal.ListClient(string.Empty, string.Empty, string.Empty, 0);
            List<Client> clientsDisplay = clients.Select(x => new Client { Id = x.Id, Name = x.Name + " " + x.LastName }).ToList();
            cbClients.DataSource = clientsDisplay;
            cbClients.DisplayMember = "Name";
            cbClients.ValueMember = "Id";
            cbClients.SelectedIndex =  0;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            decimal amount = 0;
            string message = "";
            if (((dynamic)cbClients.SelectedItem).Id <= 0)
            {
                message += "- Seleccione un cliente\n";
            }
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                message += "- Ingrese la descricion de la compra";
            }
            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                message += "- Ingrese el monto de la compra";
            }

            if (!string.IsNullOrEmpty(message.Trim()))
            {
                MessageBox.Show(message, "Maravil - Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (updateOrder != null)
            {
                updateOrder.ClientId = ((dynamic)cbClients.SelectedItem).Id;
                updateOrder.IsDelivered = false;
                updateOrder.Description = txtDescription.Text;
                updateOrder.Amount = amount;
                try
                {
                    if (orderActionsGlobal.UpdateOrder(updateOrder))
                    {
                        MessageBox.Show("Compra modificada satisfactoriamente.", "Maravil - Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Maravil - Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                  Order order = new Order();
                order.ClientId = ((dynamic)cbClients.SelectedItem).Id;
                order.IsDelivered = false;
                order.Description = txtDescription.Text;
                order.Amount = amount;
                try
                {
                    if (orderActionsGlobal.CreateOrder(order))
                    {
                        MessageBox.Show("Compra agregada satisfactoriamente.", "Maravil - Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Maravil - Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
