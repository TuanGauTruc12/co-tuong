namespace BanCov1.Models
{
    public class User
    {

        public User(List<MoveChess> moveChess, string id, string name)
        {
            this.moveChess = moveChess;
            this.id = id;
            this.name = name;
        }

        public List<MoveChess> moveChess { get; set; }
        public string id { get; set; }

        public string name { get; set; }

    }
}
