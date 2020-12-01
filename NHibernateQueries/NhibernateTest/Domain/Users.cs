namespace NhibernateTest.Domain
{
    public class Users
    {
        public virtual long userId { get; set; }
        public virtual int communityId { get; set; }
        public virtual long accountId { get; set; }
        public virtual int localId { get; set; }
        public virtual int reputation { get; set; }
        public virtual string creationDate { get; set; }
        public virtual string lastAccessDate { get; set; }
        public virtual int views { get; set; }
       
    }
}
