using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace TcpSupport
{
    public class TcpClient:TcpBase
    {
        public event EventHandler Connected;
        protected void OnConnected()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }
        public Socket Client { get; set; }
        public IPEndPoint IPEndPoint { get; set; }
        public TcpClient() : base()
        {
        }
        
        public bool Connect(string ipaddress, int port,out long takttime)
        {
            Stopwatch sw = Stopwatch.StartNew();

            IPAddress _ipaddress = IPAddress.Parse(ipaddress);
            IPEndPoint _serverenpoint = new IPEndPoint(_ipaddress, port);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Client.Connect(_serverenpoint);
                    if (Client.Connected) break;
                }
                catch
                {

                }
            }
            sw.Stop();
            takttime = sw.ElapsedMilliseconds;
            if (this.Client.Connected)
            {
                OnConnected();
            }
            return this.Client.Connected;
        }
        public bool Connect(IPEndPoint serverep, out long takttime)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Client.Connect(serverep);
                    if (Client.Connected) break;
                }
                catch
                {

                }
            }
            sw.Stop();
            takttime = sw.ElapsedMilliseconds;
            if (this.Client.Connected)
            {
                OnConnected();
            }
            return this.Client.Connected;
        }
    }
}