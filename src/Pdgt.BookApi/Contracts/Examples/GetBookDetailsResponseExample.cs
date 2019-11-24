using System;
using Pdgt.BookApi.Contracts;
using Swashbuckle.AspNetCore.Examples;

namespace Pdgt.BookApi.Controllers
{
    public class GetBookDetailsResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new BookItem
            {
                Title = "IT",
                Authors = new[] {"Stephen King"},
                Key = Guid.NewGuid().ToString("N"),
                NumberOfPages = 890,
                PublishDate = "1978-02-12",
                Subjects = new[] {"Horror"}
            };
        }
    }
}