using UnityEngine;
using System.Collections;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace samplechat1{
public class pythonServer : MonoBehaviour {

	IPEndPoint ipep,sender;
	UdpClient newsock;
	byte[] data = new byte[1024];
	public static string val = "N";

		ThreadStart recivingThread;
		Thread childRecive;
	// Use this for initialization
	void Start () {

			recivingThread = new ThreadStart(CallToChildThread);
			childRecive = new Thread (recivingThread);


		ipep = new IPEndPoint(IPAddress.Any, 9050);
		newsock = new UdpClient(ipep);
		sender = new IPEndPoint (IPAddress.Any, 0);
		data = newsock.Receive(ref sender);
     
        string welcome = "Welcome to my test server";
        data = Encoding.ASCII.GetBytes(welcome);
        newsock.Send(data, data.Length, sender);

			childRecive.Start();
			if(val.Equals("quit")) childRecive.Abort ();

		}
	
	
	// Update is called once per frame
	void Update () {
		   // data = newsock.Receive(ref sender);
			//	val = Encoding.ASCII.GetString(data);
	}
	
		public void CallToChildThread(){
			while (!val.Equals("quit")) {
				data = newsock.Receive(ref sender);
				val = Encoding.ASCII.GetString(data);
			}
		}

}
}