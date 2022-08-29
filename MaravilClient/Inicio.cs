
using BAL.Models;
using Services.UserActions;
using System.ComponentModel.Design;
using System.Configuration;

namespace MaravilClient
{
    public partial class Inicio : Form
    {
        User? logedUser =  null;
        private readonly IUserActions userActionsGlobal;
        public Inicio(IUserActions userActions)
        {
            InitializeComponent();
            this.userActionsGlobal = userActions;   
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
            if(string.IsNullOrEmpty( tbUser.Text) || string.IsNullOrEmpty(tbPass.Text)){
                MessageBox.Show("Por favor, ingrese correctamente su usuario y contraseña","Maravil - Inicio de sesion",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            logedUser = userActionsGlobal.Initsession(tbUser.Text, tbPass.Text);
            if (logedUser != null)
            {
                this.Hide();
                ClientList frmCLients = new ClientList(logedUser);
                frmCLients.FormClosed += (s, args) => this.Show();
                frmCLients.Show();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado, intente de nuevo.", "Maravil - Inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}