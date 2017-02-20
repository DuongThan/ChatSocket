using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
    public delegate void UpdateData(string text);
    public partial class ClientChat : Form
    {
        TcpClient Client = new TcpClient();
        Stream stream;
        int item = 0;
        public string NickName;
        public ClientChat(string user)
        {
            InitializeComponent();
            this.NickName = user;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome " + NickName;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSend.Text == "") return;
            string str = txtSend.Text;
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            item = 1;
            Update(str);
            writer.WriteLine(str);
            txtSend.Clear();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                Client.Connect(txtIP.Text, int.Parse(txtPort.Text));
                stream = Client.GetStream();
                Thread thread = new Thread(ContectServer);
                thread.Start();
                btnConnect.Enabled = false;
                txtIP.Enabled = false;
                txtPort.Enabled = false;
            }
            catch { MessageBox.Show("Server chưa khởi tạo"); Application.Exit(); }
        }
        public void Update(string txt)
        {
            if (item == 0)
            {
                if (rtbReceived.InvokeRequired)
                {
                    Invoke(new UpdateData(Update), new object[] { txt });
                }

                else
                {
                    rtbReceived.Text += txt + "\n" + "----------------" + "\n";
                }
            }
            else
            {
                if (rtbSend.InvokeRequired)
                {
                    Invoke(new UpdateData(Update), new object[] { txt });
                }

                else
                {
                    rtbSend.Text += txt + "\n" + "----------------" + "\n";
                }
            }

        }
        private void ContectServer()
        {
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine(NickName);
            while (true)
            {
                try
                {
                    string str;
                    var reader = new StreamReader(stream);
                    str = reader.ReadLine();
                    item = 0;
                    Update(str);
                }
                catch { break; }
            }
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSend.Text == "") return;
                string str = txtSend.Text;
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                item = 1;
                Update(str);
                writer.WriteLine(str);
                txtSend.Clear();
            }
        }
    }
}
