namespace NhibernateTest.Domain
{
    public class Posts
    {
        public virtual long postId { get; set; }
        public virtual int communityId { get; set; }
        public virtual int localId { get; set; }
        public virtual int postTypeId { get; set; }
        public virtual long acceptedAnswerId { get; set; }
        public virtual long parentId { get; set; }
        public virtual string creationDate { get; set; }
        public virtual int score { get; set; }
        public virtual int viewCount { get; set; }
        public virtual string postBody { get; set; }
        public virtual long ownerUserId { get; set; }
        public virtual string ownerDisplayName { get; set; }
        public virtual long lastEditorUserId { get; set; }
        public virtual string lastEditorDisplayName { get; set; }
        public virtual string lastEditDate { get; set; }
        public virtual string lastActivityDate { get; set; }
        public virtual string title { get; set; }
        public virtual int answerCount { get; set; }
        public virtual int commentCount { get; set; }
        public virtual int favoriteCount { get; set; }
        public virtual string closedDate { get; set; }
        public virtual string communityOwnedDate { get; set; }
    }
}
