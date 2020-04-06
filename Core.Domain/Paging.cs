namespace Core.Domain
{
    public class Paging
    {
        public string OrderBy { get; set; }
        public string OrderDirection { get; set; }
        public int Skip { get; set; }
        public int Top { get; set; }
    }
}
