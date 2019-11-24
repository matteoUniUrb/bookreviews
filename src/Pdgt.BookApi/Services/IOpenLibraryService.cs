using System.Threading.Tasks;
using Pdgt.BookApi.Services.Contracts;

namespace Pdgt.BookApi.Services
{
    public interface IOpenLibraryService
    {
        Task<SearchResult> GetSearchResultAsync(string text);

        Task<BookInfo> GetBookInfoAsync(string key);
    }

    /*
     * {
    "ISBN:9780980200447": {
        "info_url": "https://openlibrary.org/books/OL22853304M/Slow_reading",
        "bib_key": "ISBN:9780980200447",
        "preview_url": "https://openlibrary.org/books/OL22853304M/Slow_reading",
        "thumbnail_url": "https://covers.openlibrary.org/b/id/5546156-S.jpg",
        "preview": "noview",
        "details": {
            "number_of_pages": 80,
            "table_of_contents": [
                {
                    "title": "The personal nature of slow reading",
                    "type": {
                        "key": "/type/toc_item"
                    },
                    "level": 0
                },
                {
                    "title": "Slow reading in an information ecology",
                    "type": {
                        "key": "/type/toc_item"
                    },
                    "level": 0
                },
                {
                    "title": "The slow movement and slow reading",
                    "type": {
                        "key": "/type/toc_item"
                    },
                    "level": 0
                },
                {
                    "title": "The psychology of slow reading",
                    "type": {
                        "key": "/type/toc_item"
                    },
                    "level": 0
                },
                {
                    "title": "The practice of slow reading.",
                    "type": {
                        "key": "/type/toc_item"
                    },
                    "level": 0
                }
            ],
            "weight": "1 grams",
            "covers": [
                5546156
            ],
            "lc_classifications": [
                "Z1003 .M58 2009"
            ],
            "latest_revision": 14,
            "source_records": [
                "marc:marc_loc_updates/v37.i01.records.utf8:4714764:907",
                "marc:marc_loc_updates/v37.i24.records.utf8:7913973:914",
                "marc:marc_loc_updates/v37.i30.records.utf8:11406606:914"
            ],
            "title": "Slow reading",
            "languages": [
                {
                    "key": "/languages/eng"
                }
            ],
            "subjects": [
                "Books and reading",
                "Reading"
            ],
            "publish_country": "mnu",
            "by_statement": "by John Miedema.",
            "oclc_numbers": [
                "297222669"
            ],
            "type": {
                "key": "/type/edition"
            },
            "physical_dimensions": "1 x 1 x 1 inches",
            "revision": 14,
            "publishers": [
                "Litwin Books"
            ],
            "description": "\"A study of voluntary slow reading from diverse angles\"--Provided by publisher.",
            "physical_format": "Paperback",
            "last_modified": {
                "type": "/type/datetime",
                "value": "2010-08-07T19:35:52.482887"
            },
            "key": "/books/OL22853304M",
            "authors": [
                {
                    "name": "John Miedema",
                    "key": "/authors/OL6548935A"
                }
            ],
            "publish_places": [
                "Duluth, Minn"
            ],
            "pagination": "80p.",
            "classifications": {},
            "created": {
                "type": "/type/datetime",
                "value": "2009-01-07T22:16:11.381678"
            },
            "lccn": [
                "2008054742"
            ],
            "notes": "Includes bibliographical references and index.",
            "identifiers": {
                "amazon": [
                    "098020044X"
                ],
                "google": [
                    "4LQU1YwhY6kC"
                ],
                "project_gutenberg": [
                    "14916"
                ],
                "goodreads": [
                    "6383507"
                ],
                "librarything": [
                    "8071257"
                ]
            },
            "isbn_13": [
                "9780980200447"
            ],
            "dewey_decimal_class": [
                "028/.9"
            ],
            "isbn_10": [
                "1234567890"
            ],
            "publish_date": "2009",
            "works": [
                {
                    "key": "/works/OL13694821W"
                }
            ]
        }
    }
}
     */
}