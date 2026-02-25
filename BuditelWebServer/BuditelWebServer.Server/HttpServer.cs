using BuditelWebServer.Server.Contracts;
using BuditelWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server
{
	public class HttpServer
	{
		private readonly IPAddress ipAddress;
		private readonly int port;
		private readonly TcpListener serverListener;

		private readonly RoutingTable routes;

		public HttpServer(string ipAddress, int port
			,Action<IRoutingTable> routingTableConfigurtion)
		{
			this.ipAddress = IPAddress.Parse(ipAddress);
			this.port = port;
			this.serverListener = new TcpListener(this.ipAddress,this.port);


			routingTableConfigurtion(routes = new RoutingTable());
		}

		public HttpServer(int port, Action<IRoutingTable> routes)
			:this("127.0.0.1",port,routes)
		{
			
		}
		public HttpServer(Action<IRoutingTable> routes)
			:this(8080,routes)
		{
			
		}

		public async Task Start()
		{
			this.serverListener.Start();

			Console.WriteLine($"Server started on port {port}");
			Console.WriteLine($"Listening for requests...");
			while (true)
			{
				var connection = await serverListener.AcceptTcpClientAsync();

				_ = Task.Run(async () =>
				{
					var networkStream = connection.GetStream();

					var requestText = await ReadRequest(networkStream);
					Console.WriteLine(requestText);
					var request = Request.Parse(requestText);
					var response = routes.MatchRequest(request);
					if (response.PreRnderAction != null)
					{
						response.PreRnderAction(request, response);
					}

					await WriteResponse(networkStream, response);
					connection.Close();
				});
			
            }
		}

		

		private async Task WriteResponse(NetworkStream networkStream, Response response)
		{
			var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
			await networkStream.WriteAsync(responseBytes);
		}

		private async Task<string> ReadRequest(NetworkStream networkStream)
		{
			var bufferLength = 1024;
			var buffer = new byte[bufferLength];

			var totalBytes = 0;

			var requestBuilder = new StringBuilder();

			do
			{
				var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
				totalBytes+= bytesRead;
				if (totalBytes > 10 * 1024)
				{
					throw new InvalidDataException("Request is too large.");
				}
				requestBuilder.Append(Encoding.UTF8.GetString(buffer,0,bytesRead));
			}
			while (networkStream.DataAvailable);

			return requestBuilder.ToString();
		}
	}
}
