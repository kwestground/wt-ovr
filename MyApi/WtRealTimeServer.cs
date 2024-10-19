using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MyApi;

public class WtRealTimeServer
{
    private UdpClient udpListener;
    private UdpClient udpSender;
    private IPEndPoint listenerEndPoint;
    private bool working = true;

    public WtRealTimeServer(int listenPort) // , string broadcastIp, int writePort
    {
        listenerEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
        udpListener = new UdpClient(listenerEndPoint);

        // Broadcast setup
        //udpSender = new UdpClient();
        //udpSender.EnableBroadcast = true;
        //udpSender.Connect(broadcastIp, writePort);
    }

    public async Task Start()
    {
        Console.WriteLine("UDP server started. Waiting for messages...");
        while (working)
        {
            UdpReceiveResult receivedResult = await udpListener.ReceiveAsync();
            string receivedMessage = Encoding.UTF8.GetString(receivedResult.Buffer);
            Console.WriteLine($"Received message: {receivedMessage.Trim()} from {receivedResult.RemoteEndPoint}");

            string responseMessage = ProcessRequest(receivedMessage.Trim());
            if (responseMessage != null)
            {
                SendResponse(receivedResult.RemoteEndPoint, responseMessage);
            }
        }
    }

    private string ProcessRequest(string request)
    {

        return null;
    }

    private void SendResponse(IPEndPoint clientEndPoint, string response)
    {
        try
        {
            byte[] responseBytes = Encoding.UTF8.GetBytes(response + "\r\n");
            udpSender.Send(responseBytes, responseBytes.Length, clientEndPoint);
            Console.WriteLine($"Sent response: {response} to {clientEndPoint}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending response: {ex.Message}");
        }
    }

    public void Stop()
    {
        working = false;
        udpListener.Close();
        udpSender.Close();
        Console.WriteLine("UDP server stopped.");
    }
}