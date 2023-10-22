using BanCov1.Models;
using Microsoft.AspNetCore.SignalR;

public class ChessHub : Hub
{
    private static Dictionary<string, int> playerCounts = new Dictionary<string, int>();

    public async Task JoinGameRoom(string roomName)
    {
        if (!playerCounts.ContainsKey(roomName))
        {
            playerCounts[roomName] = 1;
        }
        else
        {
            playerCounts[roomName]++;
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        await Clients.Group(roomName).SendAsync("UpdatePlayerCount", roomName, playerCounts[roomName]);

    }

    public async Task MoveChess(string roomName, string id, int fromi, int fromj, int toi, int toj)
    {
        await Clients.Group(roomName).SendAsync("ReceiveChessMove", id, fromi, fromj, toi, toj);
    }
}