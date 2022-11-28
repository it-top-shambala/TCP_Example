using System.Net;
using System.Net.Sockets;

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
