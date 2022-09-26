using System;
using System.Collections.Generic;

namespace DBFirstLibrary
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
