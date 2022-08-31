namespace EFCORE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Log> Logs { get; set; }
    }
}
