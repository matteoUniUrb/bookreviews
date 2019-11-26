using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Examples;

namespace Pdgt.BookApi.Contracts.Examples
{
    public class SearchBooksResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<BookListItem>
            {
                new BookListItem()
                {
                    Author = "Stephen King",
                    Key = Guid.NewGuid().ToString("N"),
                    Title = "IT",
                    AuthorKey = Guid.NewGuid().ToString("N"),
                    PublicationYear = "1978"
                },
                new BookListItem()
                {
                    Author = "Dante Alighieri",
                    Key = Guid.NewGuid().ToString("N"),
                    Title = "La Divina Commedia",
                    AuthorKey = Guid.NewGuid().ToString("N"),
                    PublicationYear = "1992"
                }
            };
        }
    }
}