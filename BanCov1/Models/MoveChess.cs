namespace BanCov1.Models
{
    public class MoveChess
    {
        public string id { get; set; }

        public int fromi { get; set; }
        public int fromj { get; set; }
        public int toi { get; set; }
        public int toj { get; set; }
        public bool currentPlayer { get; set; }
        public bool player { get; set; }
    }
}
