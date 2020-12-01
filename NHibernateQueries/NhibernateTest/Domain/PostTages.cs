using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateTest.Domain
{
    class PostTages
    {
        public virtual int tagId { get; set; }
        public virtual int postId { get; set; }

        public override bool Equals(object obj)
        {
            PostTages other = obj as PostTages;
            if (other == null)
            {
                return false;
            }
            else
            {
                return this.tagId == other.tagId && this.postId == other.postId;
            }
        }

        public override int GetHashCode()
        {
            return (tagId.ToString() + "|" + postId.ToString()).GetHashCode();
        }
    }
}
