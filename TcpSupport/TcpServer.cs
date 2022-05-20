using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpSupport
{
    public class TcpServer:TcpBase
    {
        #region TcpServer Event
        public class TcpServerEventArgs : EventArgs
        {
            public Socket Client { get; set; }
            public TcpServerEventArgs(Socket client)
            {
                Client = client;
            }
        }
        public event EventHandler Opened;
        public event EventHandler Closed;
        public event EventHandler Accepted;

        public void OnOpened()
        {
            Opened?.Invoke(this, EventArgs.Empty);
        }
        public void OnClosed()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
        public void OnAccepted(Socket client)
        {
            Accepted?.Invoke(this, new TcpServerEventArgs(client));
        }
        #endregion
        public Socket Server { get; set; }
        public IPEndPoint ServerEndpoint { get; set; }
        public bool EnableServer { get; set; } = false;
        public TcpServer() : base()
        {
        }
        public async Task Open(string ipaddress, int port)
        {
            try
            {
                Task _task = new Task(() =>
                {
                    EnableServer = true;
                    InitialServer(ipaddress, port);
                    Thread _thread = new Thread(() =>
                    {
                        try
                        {
                            while (true)
                            {
                                try
                                {
                                    Socket client = Server.Accept();
                                    this.OnAccepted(client);
                                    Thread.Sleep(5);
                                }
                                catch
                                {
                                    if(this.Server != null)
                                    {
                                        this.Server.Close();
                                    }
                                    InitialServer(ipaddress, port);
                                }
                            }
                        }
                        catch
                        {

                        }
                    });
                    _thread.IsBackground = true;
                    _thread.Start();
                    while (this.EnableServer)
                    {
                        Thread.Sleep(5);
                    }
                    if(_thread.IsAlive)
                        _thread.Abort();
                });
                _task.Start();
                await _task;
            }
            catch(CustomTcpException.TaskInterupptByUser ignor)
            {

            }
            catch(Exception ex)
            {

            }
            finally
            {
                this.OnClosed();
            }
        }
        public void Close()
        {
            this.EnableServer = false;
        }
        public bool InitialServer(string ipaddress, int port)
        {
            if (string.IsNullOrEmpty(ipaddress)) throw new ArgumentNullException("IPAddress Error!");
            IPAddress _ipaddress = IPAddress.Parse(ipaddress);
            this.ServerEndpoint = new IPEndPoint(_ipaddress, port);
            this.Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.Server.Bind(ServerEndpoint);
            this.Server.Listen(10);
            return true;
        }
    }
}