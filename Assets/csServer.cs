using UnityEngine;
using System.Collections;

using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace serverForRpi{
	public class csServer : MonoBehaviour {

		public static string val = "N";

		// Use this for initialization
		void Start () {
			TcpListener listener = new TcpListener(IPAddress.Any, 5000);
			//Console.WriteLine("waiting for client");
			listener.Start();


			TcpClient client = listener.AcceptTcpClient();


			NetworkStream nwStream = client.GetStream();
			byte[] buffer = new byte[client.ReceiveBufferSize];


			int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);


			string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
			//Console.WriteLine("Primljeno : " + dataReceived);
			val = dataReceived;

			client.Close();
			listener.Stop();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}