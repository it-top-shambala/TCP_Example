using System.Net;

var ip = IPAddress.Parse("127.0.0.1");
const int PORT = 8005;
var endPoint = new IPEndPoint(ip, PORT);