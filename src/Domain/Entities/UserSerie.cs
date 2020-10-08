namespace Domain.Entities
{
    public class UserSerie
    {
        public int Id { get; set; }
        public int Episode { get; set; }
        public int Score { get; set; }
        public Serie Serie { get; set; }
        public User User { get; set; }
        
    }
}