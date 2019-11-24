using System;
using System.Collections.Generic;

namespace Pdgt.BookApi.Contracts
{
    public class BookItem
    {
        public string Title { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public int NumberOfPages { get; set; }

        public IEnumerable<string> Subjects { get; set; }

        public string Key { get; set; }

        public string PublishDate { get; set; }

    }
}