using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreApi.Data;
using BookStoreApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            // var records = await _context.Books.Select(i => new BookModel()
            // {
            //     Id = i.Id,
            //     Title = i.Title,
            //     Description = i.Description
            // }).ToListAsync();
            //
            // return records;

            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }
        
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            // var oneRecord = await _context.Books.Where(x=> x.Id == bookId).Select(i => new BookModel()
            // {
            //     Id = i.Id,
            //     Title = i.Title,
            //     Description = i.Description
            // }).FirstOrDefaultAsync();
            //
            // return oneRecord;

            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
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
            // var book = await _context.Books.FindAsync(bookId);
            // if (book != null)
            // {
            //     book.Title = bookModel.Title;
            //     book.Description = bookModel.Description;
            //
            //     await _context.SaveChangesAsync();
            // }
            var book = new Books()
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        //also can remove column(make it null)
        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { Id = bookId };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}