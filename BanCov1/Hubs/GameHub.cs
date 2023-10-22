using Microsoft.AspNetCore.SignalR;

public class GameHub : Hub
{
    public void player1Pressed()
    {
        Clients.All.SendAsync("player1Pressed");
    }

    public void player2Pressed()
    {
        Clients.All.SendAsync("player2Pressed");
    }
}
