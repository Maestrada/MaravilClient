
using BAL.Models;
using Services.ClientActions;
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
        public Inicio(IUserActions userActions, IClientActions clientActions)
        {
            InitializeComponent();
            this.userActionsGlobal = userActions;   
            this.clientActionsGlobal = clientActions;
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
            tbUser.Focus();
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
                ClientList frmCLients = new ClientList(logedUser,userActionsGlobal, clientActionsGlobal);
                frmCLients.FormClosed += (s, args) => this.Show();
                frmCLients.Show();
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