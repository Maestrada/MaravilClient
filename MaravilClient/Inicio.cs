
using BAL.Models;
using Services.ClientActions;
using Services.OrderActions;
using Services.StatesActions;
using Services.TownActions;
using Services.UserActions;
using System.ComponentModel.Design;
using System.Configuration;

namespace MaravilClient
{
    public partial class Inicio : Form
    {
        User? logedUser =  null;
        private readonly IUserActions userActionsGlobal;
        private readonly IClientActions clientActionsGlobal ;
        private readonly IStateActions stateActionsGlobal ;
        private readonly ITonwActions tonwActionsGlobal ;
        private readonly IOrderActions orderActionsGlobal ;

        public Inicio(IUserActions userActions, IClientActions clientActions, IStateActions stateActions, ITonwActions tonwActions, IOrderActions orderActions)
        {
            InitializeComponent();
            this.userActionsGlobal = userActions;   
            this.clientActionsGlobal = clientActions;
            this.stateActionsGlobal = stateActions;
            this.tonwActionsGlobal = tonwActions;
            this.orderActionsGlobal = orderActions;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            label1.Focus();
            if (string.IsNullOrEmpty( tbUser.Text) || string.IsNullOrEmpty(tbPass.Text)){
                MessageBox.Show("Por favor, ingrese correctamente su usuario y contraseña","Maravil - Inicio de sesion",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            logedUser = userActionsGlobal.Initsession(tbUser.Text, tbPass.Text);
            tbUser.Clear();
            tbPass.Clear();
            if (logedUser != null)
            {
                this.Hide();
                OrderList frmOrders = new OrderList(logedUser,userActionsGlobal, clientActionsGlobal,stateActionsGlobal,tonwActionsGlobal,orderActionsGlobal);
                frmOrders.FormClosed += (s, args) => this.Show();
                frmOrders.Show();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado, intente de nuevo.", "Maravil - Inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbPass_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btLogin_Click(sender, e);
        }

        private void tbUser_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                tbPass.Focus();
        }
    }
}