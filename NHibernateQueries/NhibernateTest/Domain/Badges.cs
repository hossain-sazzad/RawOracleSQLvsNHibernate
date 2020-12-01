namespace NhibernateTest.Domain
{
    public class Badges
    {
        public virtual long badgesId { get; set; }
        public virtual long userId { get; set; }
        public virtual int communityId { get; set; }
        public virtual string badgesName { get; set; }
        public virtual string badgesdate { get; set; }
        public virtual int badgesClass { get; set; }
        public virtual string tagbased { get; set; }
    }
}
