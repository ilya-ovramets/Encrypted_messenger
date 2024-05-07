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
    class WebSocketClient
    {
        private TcpClient client;
        private const int ReceiveChunkSize = 1024;
        private NetworkStream stream;

        public WebSocketClient()
        {
            client = new TcpClient();
        }

        public async Task ConnectAsync(string host, int port)
        {
            try
            {
                await client.ConnectAsync(IPAddress.Parse(host), port);
                stream = client.GetStream();
                
            } catch(Exception e) {
                
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
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    
                    ;
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
                Console.WriteLine("TCP connection is not open");
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

