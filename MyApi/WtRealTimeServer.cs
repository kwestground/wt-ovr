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

    // Simulate the last sent packets for each type
    private string lastRoundCountdownPacket = "clk;";
    private string lastRestCountdownPacket = "brk;";
    private string lastRoundPacket = "rnd;1";
    private string lastAthletesPacket = "at1;Blue;John;USA;at2;Red;Doe;KOR";
    private string lastScorePacket = "sc1;3;sc2;5";
    private string lastPenaltiesPacket = "wg1;1;wg2;2";
    private string lastMatchLoadedPacket = "mch;1234;QuarterFinal;Heavyweight;A;#0000ff;#ff0000;#FFFFFF";
    private string lastMatchResultPacket = "wmh;John Doe;5-3 Win by decision";

    public WtRealTimeServer(int listenPort, string broadcastIp, int writePort)
    {
        listenerEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
        udpListener = new UdpClient(listenerEndPoint);

        // Broadcast setup
        udpSender = new UdpClient();
        udpSender.EnableBroadcast = true;
        udpSender.Connect(broadcastIp, writePort);
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
        // Handle different requests similarly to how they are handled in the Java implementation
        switch (request.ToLower())
        {
            case "clock":
                Console.WriteLine("Requested for CLOCK");
                return lastRoundCountdownPacket;

            case "break":
                Console.WriteLine("Requested for REST");
                return lastRestCountdownPacket;

            case "period":
                Console.WriteLine("Requested for ROUND");
                return lastRoundPacket;

            case "scores":
                Console.WriteLine("Requested for SCORES");
                return lastScorePacket;

            case "gam-jeom":
                Console.WriteLine("Requested for PENALTIES");
                return lastPenaltiesPacket;

            case "informations":
                Console.WriteLine("Requested for MATCH");
                return lastMatchLoadedPacket;

            case "athletes":
                Console.WriteLine("Requested for ATHLETES");
                return lastAthletesPacket;

            case "winmatch":
                Console.WriteLine("Requested for WINNER");
                return lastMatchResultPacket;

            default:
                Console.WriteLine("Unknown request");
                return null;
        }
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