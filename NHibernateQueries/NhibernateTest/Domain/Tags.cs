namespace NhibernateTest.Domain
{
    public class Tags 
    {
        public virtual int tagId { get; set; }
        public virtual string TagName { get; set; }
        public virtual int Count { get; set; }
        public virtual int ExcerptPostId { get; set; }
        public virtual int WikiPostId { get; set; }
    }
}
