namespace akbank_bootcamp.Model
{
    public class Result
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public List<Game> GameList { get; set; }
    }
}
