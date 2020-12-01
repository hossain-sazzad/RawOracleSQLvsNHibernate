namespace NhibernateTest.Domain
{
    public class GlobalUsers
    {
        public virtual long accountId { get; set; }
        public virtual string displayName { get; set; }
        public virtual string websiteUrl { get; set; }
        public virtual string userLocation { get; set; }
        public virtual string aboutMe { get; set; }
        public virtual string profileImageUrl { get; set; }
        public virtual int age { get; set; }
    }
}
