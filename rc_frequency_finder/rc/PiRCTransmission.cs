using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace rc_frequency_finder.rc
{
    public class PiRCTransmission
    {
        private readonly NetworkStream _stream;

        public PiRCTransmission(string ip, int port)
        {
            var tcpClient = new TcpClient(ip, port);
            _stream = tcpClient.GetStream();
        }

        public void Send(string command)
        {
            var cleaned = command.Replace("\r\n", "").Replace(" ", "");
            var data = Encoding.ASCII.GetBytes(cleaned);
            _stream.Write(data, 0, data.Length);
        }
    }
}