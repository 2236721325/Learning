namespace Secord_API.Models
{
    public class FirstEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondEntityName { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
    }
}
