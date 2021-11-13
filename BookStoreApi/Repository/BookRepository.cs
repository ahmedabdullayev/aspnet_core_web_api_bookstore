using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApi.Data;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.Select(i => new BookModel()
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description
            }).ToListAsync();

            return records;
        }
        
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var oneRecord = await _context.Books.Where(x=> x.Id == bookId).Select(i => new BookModel()
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description
            }).FirstOrDefaultAsync();

            return oneRecord;
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }
        
        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;

                await _context.SaveChangesAsync();
            }

        }
    }
}