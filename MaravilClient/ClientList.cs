using BAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        User loggedUser;
        public ClientList(User user)
        {
            InitializeComponent();
            loggedUser = user;
        }

        private void agregarNuevoUsuarioDeSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cambiarMiContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
           
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void LoadDataGrid()
        {

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
    }
}
