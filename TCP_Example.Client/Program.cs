using System.Net;
using System.Net.Sockets;
using System.Text;

var serverIp = IPAddress.Parse("127.0.0.1");
const int PORT = 8005;
var endPoint = new IPEndPoint(serverIp, PORT);

var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Connect(endPoint);

while (true)
{
    Console.Write("Введите сообщение: ");
    var message = Console.ReadLine();
    Send(message, socket);

    message = Recive(socket);
    Console.WriteLine($"Ответ сервера: {message}");
}

Console.ReadKey();

string Recive(Socket socket)
{
    var message = new StringBuilder();
    var buffer = new byte[256];
    var bytes = 0;
    do
    {
        bytes = socket.Receive(buffer);
        message.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
    } while (socket.Available > 0);

    return message.ToString();
}

void Send(string message, Socket socket)
{
    var bytes = Encoding.UTF8.GetBytes(message);
    socket.Send(bytes);
}
