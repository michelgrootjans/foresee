using System.Collections.Generic;
using System.Linq;

namespace Foo
{
    public class Registration
    {
        public IList<AltDotNetter> Members { get; private set; }

        public int Count
        {
            get { return Members.Count; }
        }

        public Registration()
        {
            Members = new List<AltDotNetter>();
        }

        public void Add(string firstName, string lastName)
        {
            Members.Add(new AltDotNetter(firstName, lastName));
        }

        public bool Contains(string firstName, string lastName)
        {
            var member = from altDotNetter in Members 
                         where altDotNetter.FirstName == firstName 
                         && altDotNetter.LastName == lastName
                         select  altDotNetter;
            return member.LongCount() > 0;
        }
    }
}