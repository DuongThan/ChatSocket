using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Server
{
    public delegate void UpdateData(string text);
    public partial class ChatBox : Form
    {
        public RichTextBox rtbHistory { get; set; }
        public Socket Client { get; set; }
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;
        int item = 0;
        public string FromNickName { get; set; }
        public ChatBox()
        {
            InitializeComponent();
        }

        private void ChatBox_Load(object sender, EventArgs e)
        {
            lblFrom.Text = "Message from :" + FromNickName;
            Thread thread = new Thread(ContectClient);
            thread.Start();
        }

        public void Update(string txt)
        {
            if(item==0)
            {
                if (rtbReceived.InvokeRequired)
                {
                    Invoke(new UpdateData(Update), new object[] { txt});
                }

                else
                {
                    rtbReceived.Text += txt + "\n"+"----------------"+"\n";
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
                    rtbSend.Text += txt  +"\n" + "----------------" + "\n";
                }
            }
            
        }
        private void ContectClient()
        {
            stream = new NetworkStream(Client);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            while(true)
            {
                try {
                    string str = reader.ReadLine();
                    item = 0;
                    if (str.ToUpper() == "EXIT")
                        break;
                    Update(str);
                }
                catch { break; }
            }
            stream.Close();
            Client.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSend.Text == "") return;
            writer.WriteLine(txtSend.Text);
            item = 1;
            Update(txtSend.Text);
            txtSend.Clear();
        }

        private void ChatBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { Client.Close(); } catch { }
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtSend.Text == "") return;
                writer.WriteLine(txtSend.Text);
                item = 1;
                Update(txtSend.Text);
                txtSend.Clear();
            }
        }
    }
}
