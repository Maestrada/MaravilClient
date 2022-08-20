
using Services.UserActions;

namespace MaravilClient
{
    public partial class Inicio : Form
    {
        public Inicio(IUserActions userActions)
        {
            InitializeComponent();
            MessageBox.Show(userActions.MessageText());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}