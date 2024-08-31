using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientForScanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, I am listen!");
            var program = new Program();
            Task.Run(ReceiveMessageAsync);
            Console.ReadKey();

        }

        public static async Task ReceiveMessageAsync()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int remotePort = 5600;

            byte[] data = new byte[65535]; 
            using Socket receiver = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            if (ipAddress != null && remotePort != null)
            {
                receiver.Bind(new IPEndPoint(ipAddress, remotePort));
            }
            
            while (true)
            {
                var result = await receiver.ReceiveFromAsync(data, new IPEndPoint(IPAddress.Any, 0));
                var message = Encoding.UTF8.GetString(data, 0, result.ReceivedBytes);
                Console.WriteLine(message);
            }
        }
    }
}
