namespace OracleRaw15.Models
{
    public class Tags 
    {
        public int Id { get; set; }
        public int communityId { get; set; }
        public string TagName { get; set; }
        public int Count { get; set; }
        public int ExcerptPostId { get; set; }
        public int WikiPostId { get; set; }
    }
}
