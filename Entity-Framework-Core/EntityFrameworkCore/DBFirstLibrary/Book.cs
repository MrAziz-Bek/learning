using System;
using System.Collections.Generic;

namespace DBFirstLibrary
{
    public partial class Book
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public long YearOfPublication { get; set; }
        public long AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
    }
}
