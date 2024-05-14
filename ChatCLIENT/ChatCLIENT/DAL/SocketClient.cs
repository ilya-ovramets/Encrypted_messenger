using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using Microsoft.Maui;
using System.Text;
using System.Threading.Tasks;

namespace ChatCLIENT.DAL
{
    class SocketClient
    {
        private TcpClient client;
        private const int ReceiveChunkSize = 1024;
        private NetworkStream stream;

        public event Action<string> MessageReceived;
        public event Action ConectionLost;

        public SocketClient()
        {
            client = new TcpClient();
        }

        


        public async Task ConnectAsync(string host, int port)
        {
            try
            {
                IPAddress[] addresses = await Dns.GetHostAddressesAsync(host);
                if (addresses.Length == 0)
                {
                    // Сервера з таким ім'ям або IP-адресою не існує
                    this.ConectionLost?.Invoke();
                    return;
                }

                await client.ConnectAsync(addresses[0], port);
                stream = client.GetStream();
            }
            catch (Exception e)
            {
                this.ConectionLost?.Invoke();
            }

            // Запускаємо задачу для отримання повідомлень від сервера
            _ = ReceiveMessagesAsync();
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[ReceiveChunkSize];

            while (client.Connected)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                

                if (bytesRead > 0)
                {
                    string message = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                    this.MessageReceived?.Invoke(message);
                    
                }
            }
        }

        


        public async Task SendMessageAsync(string message)
        {
            if (client.Connected)
            {
                var buffer = Encoding.UTF8.GetBytes(message);
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(buffer, 0, buffer.Length);
            }
            else
            {
                this.ConectionLost?.Invoke();
            }
        }

        public async Task CloseAsync()
        {
            if (client.Connected)
            {
                client.Close();
                Console.WriteLine("TCP connection closed");
            }
        }
    }
}

