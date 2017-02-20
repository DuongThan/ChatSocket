using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Join : Form
    {
        public Join()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNickname.Text=="")
            {
                MessageBox.Show("Nick name is empty");
            }
            else
            {
                ClientChat client = new ClientChat(txtNickname.Text);
                client.FormClosed += Client_FormClosed;
                this.Hide();
                client.Show();
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Join_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Join_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
