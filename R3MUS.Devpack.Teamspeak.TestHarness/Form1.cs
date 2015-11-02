using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R3MUS.Devpack.Teamspeak.TestHarness
{
    public partial class Form1 : Form
    {
        Plugin plugin; 
        public Form1()
        {
            InitializeComponent();
            lstvwClients.Columns.Add("DbId");
            lstvwClients.Columns.Add("Ticker");
            lstvwClients.Columns.Add("Name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTSClients();
        }

        private async Task GetTSClients()
        {
            plugin = new Plugin()
            {
                Url = txtbxUrl.Text,
                Login = txtbxSQName.Text,
                Password = txtbxSQPWrd.Text
            };
            await plugin.GetAllClients();
            plugin.ClientList.ForEach(client =>
                {
                    var lvI = new ListViewItem(client.ClientId.ToString());
                    lvI.SubItems.Add(new ListViewItem.ListViewSubItem()
                    { Text = client.ClientTicker() });
                    lvI.SubItems.Add(new ListViewItem.ListViewSubItem()
                    { Text = client.ClientName() });
                    lstvwClients.Items.Add(lvI);
                });
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Poke();
        }
        
        private async Task Poke()
        {
            try
            {
                //var bollox = await plugin.Send(lstvwClients.SelectedItems[0].Text, txtbxMsg.Text);
                plugin.Send(lstvwClients.SelectedItems[0].Text, txtbxMsg.Text);
                txtbxMsg.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("You need to select someone to poke");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetUserFromDB();
        }
        private async Task GetUserFromDB()
        {
            if(plugin == null)
            {
                plugin = new Plugin()
                {
                    Url = txtbxUrl.Text,
                    Login = txtbxSQName.Text,
                    Password = txtbxSQPWrd.Text
                };
            }
            try
            {
                await plugin.DeleteUser(txtbxMsg.Text);
                txtbxMsg.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("You need to select someone to poke");
            }
        }

    }
}
