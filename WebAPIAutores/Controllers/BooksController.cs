using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Entities;

namespace WebAPIAutores.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public BooksController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return await context.Books
                .Include(book => book.Author)
                .ToListAsync();
        }

        [HttpGet("{urlId:int}")]
        public async Task<ActionResult<Book>> Get(int urlId)
        { 
            return await context.Books
                .Include(book => book.Author)
                .FirstOrDefaultAsync(book => book.Id == urlId);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
            // Check if author exists
            var authorExists = await context.Authors.AnyAsync(author => author.Id == book.AuthorId);

            if (!authorExists)
            {
                return BadRequest($"Author with Id: {book.AuthorId} not found.");
            }

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return Ok(book);
        }
    }
}
