using BAL.Models;
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

    public partial class SystemUsers : Form
    {
        private User loggedUser;
        private readonly IUserActions userActionsGlobal;
        public SystemUsers(User user, IUserActions userActions)
        {
            InitializeComponent();
            loggedUser = user;
            userActionsGlobal = userActions;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (txtUser.Text.Trim() == string.Empty)
                message += " - Introduzca una usuario";            

            if (!string.IsNullOrEmpty(message))
            {
                showMessage(message);
                return;
            }            
            try
            {
                userActionsGlobal.CreateUser(new User
                {
                    UserName = txtUser.Text,
                    ActiveStatus = true,
                    CreatedOn = DateTime.Now,
                    IsSystemAdmin = checkBox2.Checked,
                    ModifiedOn = DateTime.Now,
                    Password = "maravil"
                });

                LoadDatagrid();
            }
            catch (Exception ex)
            {
                showMessage(ex.Message);
            }
        }

        private void showMessage(string message)
        {
            MessageBox.Show(message, "Maravil - Usuarios de sistema");
        }
        private void LoadDatagrid()
        {
            try
            {
                List<User> lista = userActionsGlobal.ListUser(string.Empty).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                foreach (User user in lista)
                { 
                    dataGridView1.Rows.Add(user.Id, user.UserName,  user.ActiveStatus,user.IsSystemAdmin);
                }
            }
            catch(Exception ex)
            {
                showMessage(ex.Message);
            }
        }

        private void SystemUsers_Load(object sender, EventArgs e)
        {            
            checkBox2.Enabled = loggedUser.IsSystemAdmin;
            LoadDatagrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = dataGridView1.Rows[e.RowIndex].Index.ToString();                     
            EditSystemUser edit = new EditSystemUser((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value,loggedUser,userActionsGlobal);
            edit.ShowDialog();
            LoadDatagrid();           
        }
    }
}
