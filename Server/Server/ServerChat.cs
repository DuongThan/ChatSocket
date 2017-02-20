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
using System.Net;
using System.Threading;
using System.IO;

namespace Server
{
    public delegate void Update(string data);
    public partial class ServerChat : Form
    {
        private TcpListener listener;
        public ServerChat()
        {
            InitializeComponent();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text));
            listener.Start();
            rtbHistory.Text += "\n" + " waiting for a connection..." + "\n";
            Thread thread = new Thread(ListenerClient);
            thread.Start();
            btnInit.Enabled = false;
            txtIP.Enabled = false;
            txtPort.Enabled = false;
        }

        public void ListenerClient()
        {
            while (true)
            {
                try
                {
                    Socket client = listener.AcceptSocket();
                    Thread thread = new Thread(ContectWithClient);
                    thread.Start(client);
                }
                catch { break; }
            }
            listener.Stop();
        }

        public void UpdateDT(string text)
        {
            if (rtbHistory.InvokeRequired)
            {
                Invoke(new Update(UpdateDT), new object[] { text });
            }

            else
            {
                rtbHistory.Text += text + "\r\n";
            }
        }
        private void ContectWithClient(object obj)
        {
            Socket client = obj as Socket;
            Stream stream = new NetworkStream(client);
            StreamReader reader = new StreamReader(stream);
            string nickName = reader.ReadLine();
            stream.Close();

            UpdateDT("ID : " + client.LocalEndPoint);
            ChatBox chatbox = new ChatBox();
            chatbox.rtbHistory = rtbHistory;
            chatbox.Client = client;
            chatbox.FromNickName = nickName;
            chatbox.ShowDialog();
        }

        private void ServerChat_Load(object sender, EventArgs e)
        {

        }

        private void ServerChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { listener.Stop(); } catch { }
            Application.Exit();
        }
    }
}
