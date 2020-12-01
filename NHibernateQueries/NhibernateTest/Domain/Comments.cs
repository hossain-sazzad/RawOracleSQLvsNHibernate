namespace NhibernateTest.Domain
{
    public class Comments
    {
        public virtual long commentId { get; set; }
        public virtual long postId { get; set; }
        public virtual int score { get; set; }
        public virtual string text { get; set; }
        public virtual string creationDate { get; set; }
        public virtual string userDisplayName { get; set; }
        public virtual long userId { get; set; }
    }
}
