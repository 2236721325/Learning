namespace FreeSqlDemo.Models
{
    public class PagedDto<T>
    {
        public long totalCount { get; set; }
        public List<T> Items { get; set; }
        public PagedDto(List<T> Items, long totalCount)
        {
            this.Items = Items;
            this.totalCount = totalCount;
        }
    }
}
