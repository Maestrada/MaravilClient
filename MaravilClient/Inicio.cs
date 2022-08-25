
using Services.UserActions;
using System.ComponentModel.Design;
using System.Configuration;

namespace MaravilClient
{
    public partial class Inicio : Form
    {
        private readonly IUserActions userActionsGlobal;
        public Inicio(IUserActions userActions)
        {
            InitializeComponent();
            this.userActionsGlobal = userActions;   
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}