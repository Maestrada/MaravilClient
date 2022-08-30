using BAL.Models;
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
    public partial class PrintQeue : Form
    {
        public List<Client> listClient;
        public PrintQeue(List<Client> clients)
        {
            InitializeComponent();
            listClient = clients;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            listClient.Clear();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                listClient.Add(new Client
                    {
                        Id = (int)item.Cells[0].Value,
                        Name = item.Cells[1].Value as string,
                        LastName = item.Cells[2].Value as string,
                        CellPhone = item.Cells[3].Value as string,
                        Address = item.Cells[4].Value as string,
                    });
            }
        }
    }
}
