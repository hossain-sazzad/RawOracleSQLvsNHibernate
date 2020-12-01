namespace NhibernateTest.Domain
{
    public class PostHistory
    {
        public virtual long postHistoryId { get; set; }
        public virtual int postHistoryTypeId { get; set; }
        public virtual long postId { get; set; }
        public virtual string revisionGuid { get; set; }
        public virtual string creationDate { get; set; }
        public virtual long userId { get; set; }
        public virtual string userDisplayName { get; set; }
        public virtual string postHistoryComment { get; set; }
        public virtual string text { get; set; }
       
    }
}
