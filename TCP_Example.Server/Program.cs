using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Запуск сервера...");

var ip = IPAddress.Parse("127.0.0.1");
const int PORT = 8005;
var endPoint = new IPEndPoint(ip, PORT);

var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(endPoint);
Console.WriteLine("Привязка сокета к ip-адресу сервера");

socket.Listen(10);
Console.WriteLine("Ожидание подключения от клиента...");

var socketOperator = socket.Accept();
Console.WriteLine($"Подключился клиент {socketOperator.RemoteEndPoint}");

while (true)
{
    var message = Recive(socketOperator);
    Console.WriteLine($"Сообщение от пользователя: {message}");

    Send("Сообщение получено", socketOperator);
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
