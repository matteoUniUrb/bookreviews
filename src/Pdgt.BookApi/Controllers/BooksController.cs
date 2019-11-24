using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdgt.BookApi.Contracts;
using Pdgt.BookApi.Services;

namespace Pdgt.BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IOpenLibraryService _openLibraryService;
        private readonly IBookReviewService _bookReviewService;
        private readonly IMapper _mapper;

        public BooksController(IOpenLibraryService openLibraryService, IBookReviewService bookReviewService, IMapper mapper)
        {
            _openLibraryService = openLibraryService;
            _bookReviewService = bookReviewService;
            _mapper = mapper;
        }

        [HttpGet("/search")]
        public async Task<ActionResult<IEnumerable<BookListItem>>> SearchBooksAsync(string searchText)
        {
            var openLibraryResult = await _openLibraryService.GetSearchResultAsync(searchText);
            var mappedResult = new List<BookListItem>();
            openLibraryResult.Items.ToList().ForEach(item => mappedResult.Add(_mapper.Map<BookListItem>(item)));
            return Ok(mappedResult);
        }

        [HttpGet("/{key}")]
        public async Task<ActionResult<BookItem>> GetBookAsync([FromRoute]string key)
        {
            var openLibraryResult = await _openLibraryService.GetBookInfoAsync(key);
            var mappedResult = _mapper.Map<BookItem>(openLibraryResult);
            return Ok(mappedResult);
        }

        [HttpPost("/{key}")]
        public async Task<ActionResult<BookItem>> PostReviewAsync([FromRoute]string key, [FromBody]BookReviewRequest bookReviewRequest)
        {
            await _bookReviewService.AddReviewAsync(key, bookReviewRequest.ReviewText, bookReviewRequest.BookRating);
            return Created((string)null, null);
        }


    }
}