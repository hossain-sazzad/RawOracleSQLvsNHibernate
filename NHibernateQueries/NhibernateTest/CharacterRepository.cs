using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NhibernateTest.Domain;

namespace NhibernateTest
{
    public class CharacterRepository
    {
        public void Add(Character newCharacter)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newCharacter);
                    transaction.Commit();
                }
            }
        }

        public Character GetCharacterByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var result = session.QueryOver<Character>().Where(x => x.Name == name).SingleOrDefault();
                return result ?? new Character();
            }
        }

        public void Update(Character newCharacter)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(newCharacter);
                    transaction.Commit();
                }
            }
        }

        public void Delete(Character newCharacter)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(newCharacter);
                    transaction.Commit();
                }
            }
        }

    }
}
