namespace OracleRaw15.Models
{
    public class Votes
    {
        public virtual long voteId { get; set; }
        public virtual long postId { get; set; }
        public virtual int voteTypeId { get; set; }
        public virtual long voterUserId { get; set; }
        public virtual string creationDate { get; set; }
        public virtual int bountyAmount { get; set; }
    }
}
