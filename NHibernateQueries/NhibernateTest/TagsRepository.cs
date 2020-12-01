using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NhibernateTest.Domain;

namespace NhibernateTest
{
    public class TagsRepository
    {
        
        public IList<Tags> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var result = session.CreateCriteria<Tags>().List<Tags>();
                return result;
            }
        }
  

    }
}
