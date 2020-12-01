using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhibernateTest.Domain
{
    public class Character
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int HealthPoints { get; set; }
        public virtual int Mana { get; set; }
        public virtual string Profession { get; set; }
    }
}
