﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdgt.BookApi.Contracts;
using Pdgt.BookApi.Contracts.Examples;
using Pdgt.BookApi.Services;
using Swashbuckle.AspNetCore.Examples;

namespace Pdgt.BookApi.Controllers
{

    [Route("v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
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

        /// <summary>
        /// Ricerca libri con testo libero
        /// </summary>
        /// <param name="searchText">I parametri di ricerca</param>
        /// <returns>Ritorna tutti i libri che hanno un match con il criterio di ricerca</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookListItem>), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(SearchBooksResponseExample))]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<BookListItem>>> SearchBooksAsync([Required]string searchText)
        {
            searchText = searchText.Trim().Replace(" ", "+");
            var openLibraryResult = await _openLibraryService.GetSearchResultAsync(searchText);
            var mappedResult = new List<BookListItem>();
            openLibraryResult.Items.ToList().ForEach(item => mappedResult.Add(_mapper.Map<BookListItem>(item)));
            return Ok(mappedResult);
        }

        /// <summary>
        /// I dettagli di un libro
        /// </summary>
        /// <param name="key">La chiave del libro</param>
        /// <returns>Ritorna i dettagli di un libro</returns>
        [HttpGet]
        [Route("{key}")]
        [ProducesResponseType(typeof(IEnumerable<BookListItem>), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetBookDetailsResponseExample))]
        public async Task<ActionResult<BookItem>> GetBookDetailsAsync([FromRoute]string key)
        {
            var openLibraryResultTask = _openLibraryService.GetBookInfoAsync(key);
            var reviewsTask = _bookReviewService.GetReviews(key);

            await Task.WhenAll(openLibraryResultTask, reviewsTask);

            var mappedResult = _mapper.Map<BookItem>(await openLibraryResultTask);
            mappedResult.Reviews = await reviewsTask;

            return Ok(mappedResult);
        }

        /// <summary>
        /// Aggiunge una recensione a un libro
        /// </summary>
        /// <param name="key">La chiave del libro</param>
        /// <param name="request">I paraemtri della richiesta</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{key}")]
        [ProducesResponseType(typeof(IEnumerable<BookListItem>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<BookItem>> PostReviewAsync([FromRoute]string key, [FromBody]BookReviewRequest request)
        {
            await _bookReviewService.AddReviewAsync(key, request.Username, request.ReviewText, request.BookRating);
            return Created($"/books/{key}", null);
        }
    }
}