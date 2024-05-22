using System.Net;
using System.Net.Sockets;
using App.Core.IO;


namespace App.Core.Net;
public abstract class Socket(IPAddress? address, int port, ProtocolType protocol, Reader reader, Writer writer)
{
	public bool Connected => Body.Connected;
	protected IPEndPoint Endpoint { get; } = new(address ?? IPAddress.Loopback, port);
	protected System.Net.Sockets.Socket Body { get; } = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);
	protected List<IRunnable> Proccesses { get; } = [];


	
	public Reader Reader { get; } = reader;
	public Writer Writer { get; } = writer;
	
	

	protected abstract void Init();
	public void Open (){
		Init();
		Proccesses.Add(Reader);
		Proccesses.Add(Writer);

		foreach(var proccess in Proccesses) proccess.Start();
	}
	public void Close () 
	{
		try
		{
			foreach (var proccess in Proccesses) proccess.Stop();
			Body.Shutdown(SocketShutdown.Both); 
			Body.Close();
		}
		catch
		{
			Console.WriteLine("Socket Shutdown Failure");
		}
	}
}