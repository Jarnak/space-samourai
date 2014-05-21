using UnityEngine;
using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;



public class ServerHandler : MonoBehaviour
{
    private TcpListener tcpListener;
    private Thread listenThread;
    public DATA data = new DATA();
    private GameObject gameHandler;
    private TcpClient client;
    private ASCIIEncoding encoder = new ASCIIEncoding();
    private NetworkStream clientStream;
    private XmlSerializer XMLseri = new XmlSerializer(typeof(DATA));
    private GameHandler gameHandlerScript;
    private Thread clientThread;
    private bool disconect = false;



    public void Start()
    {

        this.tcpListener = new TcpListener(IPAddress.Any, 3000);
        this.listenThread = new Thread(new ThreadStart(ListenForClients));
        this.listenThread.Start();
        gameHandler = GameObject.FindGameObjectWithTag("GameController");
        gameHandlerScript = gameHandler.GetComponent<GameHandler>();
        Debug.Log("Serveur UP");
    }

    private void ListenForClients()
    {
        this.tcpListener.Start();

        while (true)
        {
            //blocks until a client has connected to the server
            client = this.tcpListener.AcceptTcpClient();
            gameHandlerScript.connectionUP();
            Debug.Log("Client Connected");
            //create a thread to handle communication 
            //with connected client
            clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
            clientThread.Start(client);
        }
    }
    private void HandleClientComm(object client)
    {
        TcpClient tcpClient = (TcpClient)client;
        tcpClient.NoDelay = true;
        clientStream = tcpClient.GetStream();

        encoder = new ASCIIEncoding();
        byte[] buffer = encoder.GetBytes("Hello Client!");

        clientStream.Write(buffer, 0, buffer.Length);
        clientStream.Flush();


        String xmlSheet;
        byte[] message = new byte[4096];
        int bytesRead;

        while (true)
        {
            bytesRead = 0;

            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(message, 0, 4096);
            }
            catch
            {
                //a socket error has occured
                break;
            }

            if (bytesRead == 0 || disconect == true)
            {
                //the client has disconnected from the server
                break;
            }


            //message has successfully been received
            xmlSheet = encoder.GetString(message, 0, bytesRead);
              
             String[] split = xmlSheet.Split(new String[] { "</DATA>" }, StringSplitOptions.None);
              
             String toDeserialize =split[0]+"</DATA>";
            

            StringReader sReader = new StringReader(toDeserialize);
            data = (DATA)XMLseri.Deserialize(sReader);
			//Debug.Log("x");
			//Debug.Log(data.x);
			//Debug.Log("y");
			//Debug.Log(data.y);
			//Debug.Log("z");
			//Debug.Log(data.z);
			//Debug.Log("w");
            //Debug.Log(data.w);

            //Debug.Log(data.go); 
			//Debug.Log(data.shield);
                
        }

        tcpClient.Close();
        Debug.Log("Disconnected");
    }
    public DATA getData()
    {
        return data;
    }

    public void Quit()
    {
        disconect = true;
        //clientThread.Abort();
        tcpListener.Stop();
        listenThread.Abort();
        clientStream.Close();
        
    }

    public void sendHit()
    {
        byte[] buffer = encoder.GetBytes("Hit");
        Debug.Log("hit");
        clientStream.Write(buffer, 0, buffer.Length);
        clientStream.Flush();
    }

    public void sendPause()
    {
        byte[] buffer = encoder.GetBytes("Pause");
        Debug.Log("pause");
        clientStream.Write(buffer, 0, buffer.Length);
        clientStream.Flush();
    }

    public void sendEndPause()
    {
        byte[] buffer = encoder.GetBytes("Endpause");
        Debug.Log("End Pause");
        clientStream.Write(buffer, 0, buffer.Length);
        clientStream.Flush();
    }
}