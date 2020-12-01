namespace OracleRaw15.Models
{
    public class PostLinks
    {
        public virtual long postLinkId { get; set; }
        public virtual string creationDate { get; set; }
        public virtual long postId { get; set; }
        public virtual long releatedPostId { get; set; }
        public virtual int linkTypeId { get; set; }
    }
}
