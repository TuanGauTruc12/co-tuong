using BanCov1.Models;
using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography;
using System.Text.Json;

public class ChessHub : Hub
{
    private static Dictionary<string, int> playerCounts = new Dictionary<string, int>();

    public async Task JoinGameRoom(string roomName, bool currentPlayer)
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
        await Clients.Group(roomName).SendAsync("UpdatePlayerCount", roomName, playerCounts[roomName], currentPlayer);

    }

    public override Task OnConnectedAsync()
    {
        string str = Context.ConnectionId;
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        string str = Context.ConnectionId;
        return base.OnDisconnectedAsync(exception);
    }

    public async Task MoveChess(string roomName, string id, int fromi, int fromj, int toi, int toj, bool currentPlayer, bool player)
    {
        List<MoveChess> moveChesses = new List<MoveChess>();
        MoveChess moveChess = new MoveChess();
        moveChess.id = id;
        moveChess.fromi = fromi;
        moveChess.fromj = fromj;
        moveChess.toi = toi;
        moveChess.toj = toj;
        moveChess.currentPlayer = !currentPlayer;
        moveChess.player = player;
        moveChesses.Add(moveChess);
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        await Clients.All.SendAsync("ReceiveChessMove", JsonSerializer.Serialize(moveChesses));
    }
}