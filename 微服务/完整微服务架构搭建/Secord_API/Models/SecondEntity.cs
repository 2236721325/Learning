namespace Secord_API.Models
{
    public class SecondEntity
    {
        public int Id { get; set; }
        public int FirstEntityId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
    }
}
