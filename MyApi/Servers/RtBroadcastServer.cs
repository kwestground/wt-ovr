using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SmoothStrike.Servers;

public static class RtBroadcastServer
{
    public static void UseRtBroadcastServer(this IApplicationBuilder app)
    {
        Task.Run(() => new ServerRunner().Start());
    }
}

public class ServerRunner
{
    private static TcpListener listener;

    public async Task Start()
    {
        string serverIp = "127.0.0.1"; // Use your server's IP here
        int serverPort = 8080;

        listener = new TcpListener(IPAddress.Parse(serverIp), serverPort);
        listener.Start();
        Console.WriteLine($"Server listening on {serverIp}:{serverPort}");

        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
            Console.WriteLine("Client connected.");

            Task.Run(() => HandleClient(client));
        }
    }
    private static async Task HandleClient(TcpClient client)
    {
        try
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {message}");

                // Process the incoming message and send appropriate responses
                string response = ProcessMessage(message);
                //byte[] responseBytes = Encoding.ASCII.GetBytes(response);

                //await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                //Console.WriteLine($"Sent: {response}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            client.Close();
            Console.WriteLine("Client disconnected.");
        }
    }

    private static string ProcessMessage(string fullMessage)
    {
        var data = fullMessage[7..];

        var command = data.Split(':')[0].Trim();
        // 005601NewMatch:1-3,Bl?,,R?d,,MALE,NYB?RJARE / HERR / -55 KG

        if (command.Equals("NewMatch"))
        {
            return "New Match";
        }
        if (command.Equals("MatchStart"))
        {
            return "Match started successfully";
        }
        else if (command.Equals("RoundStart"))
        {
            return "Round started successfully";
        }
        else if (command.Equals("Timeout"))
        {
            return "Timeout processed";
        }
        else if (command.Equals("Resume"))
        {
            return "Match resumed";
        }
        else if (command.Equals("RoundEnd"))
        {
            return "Round ended";
        }
        else if (command.Equals("MatchEnd"))
        {
            return "Match ended";
        }
        else if (command.Equals("Score"))
        {
            return "Score updated";
        }
        else
        {
            return $"Unknown message command: {command}";
        }
    }

}