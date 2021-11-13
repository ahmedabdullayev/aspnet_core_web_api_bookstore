using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BookStoreApi.Models;
using BookStoreApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api")]
    // [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }
        [HttpGet("book/{id}")]
        public async Task<IActionResult> GetBookId([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost("books")]
        public async Task<IActionResult> AddNewBook([FromBody]BookModel bookModel)
        {
            
            var id = await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookId), new {id = id, controller = "books"}, "Added product with id: " + id);
        }
        
        [HttpPut("book/{id}")]
        public async Task<IActionResult> UpdateBook([FromBody]BookModel bookModel, [FromRoute]int id)
        {
            await _bookRepository.UpdateBookAsync(id,bookModel);
            return Ok("updated");
        }
    }
}