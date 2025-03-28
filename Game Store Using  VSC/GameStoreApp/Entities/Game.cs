namespace GameStoreApp.Entities
{
    public class Game
    {
       public  int Id { get; set; }
       public  string? Name { get; set; }
        public int GenerID { get; set; }
        public Gener Gener { get; set; }
        public decimal Price { get; set; }
        public DateOnly ReleasDate { get; set; }
    }
}
