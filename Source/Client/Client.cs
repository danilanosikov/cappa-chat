using System.Net;

namespace App.Client;
public class Client(IPAddress? address, int port, System.Net.Sockets.ProtocolType protocol, int buffer_size = 1024)
{
	Socket socket = new(address, port, protocol, buffer_size);
	public void Start() => socket.Open();
}