using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpSupport
{
    public class TcpBase
    {
        public class TcpSendArgs : EventArgs
        {
            public long TaktTime { get; set; }
            public Socket TcpSocket { get; set; }
            public TcpSendArgs(Socket tcpsocket,long takttime)
            {
                this.TcpSocket = tcpsocket;
                this.TaktTime = takttime;
            }
        }

        public class TcpReceiveArgs : EventArgs
        {
            public long TaktTime { get; set; }
            public Socket TcpSocket { get; set; }
            public byte[] Data { get; set; }
            public TcpReceiveArgs(Socket tcpsocket, byte[] data, long takttime)
            {
                this.TcpSocket = tcpsocket;
                this.Data = data;
                this.TaktTime = takttime;
            }
        }
        public int SendTimeout { get; set; } = 2000;
        public int ReceiveTimout { get; set; } = 2000;
        public event EventHandler Sended;
        public event EventHandler Received;
        public event EventHandler SendTimeouted;
        public event EventHandler ReceivedTimeouted;

        protected void OnSended(Socket tcpSocket,long takttime)
        {
            Sended?.Invoke(this, new TcpSendArgs(tcpSocket,takttime));
        }
        protected void OnReceived(Socket tcpSocket, byte[] data, long takttime)
        {
            Received?.Invoke(this, new TcpReceiveArgs(tcpSocket,data, takttime));
        }
        protected void OnSendTimeouted()
        {
            SendTimeouted?.Invoke(this, EventArgs.Empty);
        }
        protected void OnReceiveTimeouted()
        {
            ReceivedTimeouted?.Invoke(this, EventArgs.Empty);
        }
        public TcpBase()
        {

        }
        public void Send(Socket tcpSocket, byte[] senddata)
        {
            //Flag Status
            bool _sendsuccess = false;
            int _offset = 0;
            int _count = 0;

            //Estimate the time send process left
            long takttime = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            Thread _sendthread = new Thread(() =>
            {
                int _senddatalength = senddata.Length;
                byte[] byte_senddatalength = BitConverter.GetBytes(_senddatalength);
                tcpSocket.Send(byte_senddatalength);
                Thread.Sleep(10);
                while (true)
                {
                    int readable = tcpSocket.Send(senddata, _offset, _senddatalength - _offset, SocketFlags.None);
                    _offset += readable;
                    if (_offset == _senddatalength) break;
                }
                _sendsuccess = true;
            });
            _sendthread.IsBackground = true;
            _sendthread.Start();
            while (_count < this.SendTimeout / 20 && !_sendsuccess)
            {
                Thread.Sleep(5);
                _count++;
            }
            if (!_sendsuccess)
            {
                if (_sendthread.IsAlive)
                {
                    _sendthread.Abort();
                }
                throw new TimeoutException("Send Processing");
            }
            takttime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            OnSended(tcpSocket, takttime);
        }
        public void Send(Socket tcpSocket, byte[] senddata, out long takttime)
        {
            takttime = -99;
            //Flag Status
            bool _sendsuccess = false;
            int _offset = 0;
            int _count = 0;

            //Estimate the time send process left
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            Thread _sendthread = new Thread(() =>
            {
                int _senddatalength = senddata.Length;
                byte[] byte_senddatalength = BitConverter.GetBytes(_senddatalength);
                tcpSocket.Send(byte_senddatalength);
                Thread.Sleep(10);
                while (true)
                {
                    int readable = tcpSocket.Send(senddata, _offset, _senddatalength - _offset, SocketFlags.None);
                    _offset += readable;
                    if (_offset == _senddatalength) break;
                }
                _sendsuccess = true;
            });
            _sendthread.IsBackground = true;
            _sendthread.Start();
            while(_count<this.SendTimeout/20 && !_sendsuccess)
            {
                Thread.Sleep(5);
                _count++;
            }
            if (!_sendsuccess)
            {
                if (_sendthread.IsAlive)
                {
                    _sendthread.Abort();
                }
                throw new TimeoutException("Send Processing");
            }
            takttime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            OnSended(tcpSocket, takttime);
        }
        public byte[] Receive(Socket tcpSocket)
        {
            long takttime = -99;
            //Flag Status
            bool _sendsuccess = false;
            int _offset = 0;
            int _count = 0;

            //Estimate the time send process left
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            byte[] receivedata = null;
            Thread _receivethread = new Thread(() =>
            {
                byte[] byte_receivedatalength = new byte[4];
                tcpSocket.Receive(byte_receivedatalength);
                int _receivedatalength = BitConverter.ToInt32(byte_receivedatalength, 0);
                receivedata = new byte[_receivedatalength];
                while (true)
                {
                    int readable = tcpSocket.Receive(receivedata, _offset, _receivedatalength - _offset, SocketFlags.None);
                    _offset += readable;
                    if (_offset == _receivedatalength) break;
                }
                _sendsuccess = true;
            });
            _receivethread.IsBackground = true;
            _receivethread.Start();
            while (_count < this.SendTimeout / 20 && !_sendsuccess)
            {
                Thread.Sleep(5);
                _count++;
            }
            if (!_sendsuccess)
            {
                if (_receivethread.IsAlive)
                {
                    _receivethread.Abort();
                }
                throw new TimeoutException("Receive Processing");
            }
            takttime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            OnReceived(tcpSocket, receivedata, takttime);
            return receivedata;
        }
        public byte[] Receive(Socket tcpSocket, out long takttime)
        {
            takttime = -99;
            //Flag Status
            bool _sendsuccess = false;
            int _offset = 0;
            int _count = 0;

            //Estimate the time send process left
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            byte[] receivedata = null;
            Thread _receivethread = new Thread(() =>
            {
                byte[] byte_receivedatalength = new byte[4];
                tcpSocket.Receive(byte_receivedatalength);
                int _receivedatalength = BitConverter.ToInt32(byte_receivedatalength, 0);
                receivedata = new byte[_receivedatalength];
                while (true)
                {
                    int readable = tcpSocket.Receive(receivedata, _offset, _receivedatalength - _offset, SocketFlags.None);
                    _offset += readable;
                    if (_offset == _receivedatalength) break;
                }
                _sendsuccess = true;
            });
            _receivethread.IsBackground = true;
            _receivethread.Start();
            while (_count < this.SendTimeout / 20 && !_sendsuccess)
            {
                Thread.Sleep(5);
                _count++;
            }
            if (!_sendsuccess)
            {
                if (_receivethread.IsAlive)
                {
                    _receivethread.Abort();
                }
                throw new TimeoutException("Receive Processing");
            }
            takttime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            OnReceived(tcpSocket, receivedata, takttime);
            return receivedata;
        }
    }
}
